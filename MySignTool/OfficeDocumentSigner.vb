Imports System.IO
Imports System.IO.Packaging
Imports System.Security.Cryptography.X509Certificates
Imports System.Collections.Generic

'added 23.07.2026

Module OfficeDocumentSigner

    Sub Main()
        Dim documentPath As String = "C:\Documents\Contract.docx"
        Dim pfxPath As String = "C:\Certificates\MySigningCert.pfx"
        Dim pfxPassword As String = "YourPassword123"

        Try
            SignOfficeDocument(documentPath, pfxPath, pfxPassword)
            Console.WriteLine("Office document signed successfully!")
        Catch ex As Exception
            Console.WriteLine($"Error signing document: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Digitally signs an Office OpenXML package (.docx, .xlsx, .pptx).
    ''' </summary>
    ''' <param name="filePath">Path to the Office document</param>
    ''' <param name="certPath">Path to the PFX certificate file</param>
    ''' <param name="certPassword">PFX password</param>
    Public Sub SignOfficeDocument(filePath As String, certPath As String, certPassword As String)
        If Not File.Exists(filePath) Then Throw New FileNotFoundException("Document not found.", filePath)
        If Not File.Exists(certPath) Then Throw New FileNotFoundException("Certificate not found.", certPath)

        ' 1. Load the X.509 Certificate with private key
        Dim cert As New X509Certificate2(certPath, certPassword, X509KeyStorageFlags.Exportable)

        ' 2. Open the OpenXML Document Package
        Using package As Package = Package.Open(filePath, FileMode.Open, FileAccess.ReadWrite)

            Dim dsm As New PackageDigitalSignatureManager(package) With {
                .CertificateOption = CertificateEmbeddingOption.InSignaturePart
            }

            ' 3. Collect all package parts (XML files, media, headers) except existing signatures
            Dim partsToSign As New List(Of Uri)()
            For Each part As PackagePart In package.GetParts()
                If Not part.Uri.ToString().Contains("package/2006/digital-signature") Then
                    partsToSign.Add(part.Uri)
                End If
            Next

            ' 4. Include structural relationship parts to ensure document structure is protected
            For Each rel As PackageRelationship In package.GetRelationships()
                partsToSign.Add(PackUriHelper.GetRelationshipPartUri(rel.SourceUri))
            Next

            ' 5. Compute signature and embed into the package
            dsm.Sign(partsToSign, cert)
        End Using
    End Sub

End Module

