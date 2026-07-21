Imports System.IO
Imports Org.BouncyCastle.Pkcs
Imports Org.BouncyCastle.X509
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.security


'added 21.07.2026

Public Class PdfSigner

    ''' <summary>
    ''' Digitally signs a PDF document using a .pfx certificate.
    ''' </summary>
    ''' <param name="srcPdf">Path to the original unsigned PDF file.</param>
    ''' <param name="destPdf">Path where the signed PDF should be saved.</param>
    ''' <param name="pfxPath">Path to your .pfx / .p12 certificate file.</param>
    ''' <param name="pfxPassword">Password for the certificate.</param>
    ''' <param name="reason">Reason for signing (optional).</param>
    ''' <param name="location">Location of signing (optional).</param>
    Public Shared Sub SignPdf(srcPdf As String,
                             destPdf As String,
                             pfxPath As String,
                             pfxPassword As String,
                             errorlog As String,
                             log As String,
                             Optional reason As String = "Document Approval",
                             Optional location As String = "Office")

        ' 1. Load the PFX/P12 Certificate using BouncyCastle (included with iTextSharp)
        Dim certStore As New Pkcs12Store(New FileStream(pfxPath, FileMode.Open, FileAccess.Read), pfxPassword.ToCharArray())

        Dim certAlias As String = Nothing
        For Each a As String In certStore.Aliases
            If certStore.IsKeyEntry(a) Then
                certAlias = a
                Exit For
            End If
        Next

        If String.IsNullOrEmpty(certAlias) Then
            My.Computer.FileSystem.WriteAllText(errorlog, "PDFSigner: No private key found in the certificate file" & vbCrLf, True)
            Throw New Exception("No private key found in the certificate file.")
        End If

        ' Extract the private key and certificate chain
        Dim pk As Org.BouncyCastle.Crypto.AsymmetricKeyParameter = certStore.GetKey(certAlias).Key
        Dim chain() As X509CertificateEntry = certStore.GetCertificateChain(certAlias)
        Dim x509Chain(chain.Length - 1) As X509Certificate

        For i As Integer = 0 To chain.Length - 1
            x509Chain(i) = chain(i).Certificate
        Next

        ' 2. Read input PDF and setup the Stamper for signing
        Using reader As New PdfReader(srcPdf)
            Using outputStream As New FileStream(destPdf, FileMode.Create, FileAccess.Write)

                ' Create the signing stamper (the 'True' argument enables incremental updates)
                Dim stamper As PdfStamper = PdfStamper.CreateSignature(reader, outputStream, "0"c, Nothing, True)
                Dim appearance As PdfSignatureAppearance = stamper.SignatureAppearance

                ' Configure metadata shown in signature details
                appearance.Reason = reason
                appearance.Location = location

                ' Option A: Invisible Signature (Default)
                ' No additional lines needed.

                ' Option B: Visible Signature (Uncomment lines below if you want a visible box)
                ' Dim rect As New iTextSharp.text.Rectangle(36, 36, 200, 100) ' X, Y, Width, Height
                ' appearance.SetVisibleSignature(rect, 1, "SignatureField") ' Page 1

                ' 3. Create the Signature Standard (Detached PKCS#7 / CMS)
                Dim externalSignature As IExternalSignature = New PrivateKeySignature(pk, DigestAlgorithms.SHA256)

                MakeSignature.SignDetached(
                    appearance,
                    externalSignature,
                    x509Chain,
                    Nothing,
                    Nothing,
                    Nothing,
                    0,
                    CryptoStandard.CMS
                )
            End Using
        End Using
        My.Computer.FileSystem.WriteAllText(log, "PDFSigner: " & destPdf & " signed successfully" & vbCrLf, True)
    End Sub

End Class
