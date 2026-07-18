Option Strict On


Public Class license



    Private kstrRegSubKeyName As String = "LPS\\dst"
    Private kstrRegSecondKey As String = "Cookie\\stool\\dst"
    Private mintUsedTrialDays As Integer
    Private mblnInTrial As Boolean = True
    Private mblnFullVersion As Boolean = False
    Private PassPhrase As String = "/)/&GVT%&fvtr"

    Public statusMessage As String
    Public trialExpired As Boolean = False
    Public mintTrialPeriod As Integer = 30



    Private Structure CurrentDate
        Dim Day As String
        Dim Month As String
        Dim Year As String
    End Structure



    Private Function DisplayApplicationStatus(ByVal pDaysUsed As Integer, ByVal pTotalDays As Integer) As String
        If pTotalDays < 0 Then
            Return "An error has occurred! Please contact info@lanstar.info"
        End If
        If pDaysUsed >= pTotalDays Then
            Return "Your trial has expired!"
        End If
        Return "You have " + (pTotalDays - pDaysUsed).ToString + " days remaining in your free trial period."
    End Function



    Private Sub CreateRegKeys(ByVal pPassPhrase As String)
        Try
            Dim Current As CurrentDate
            Current.Day = DateTime.Now.Day.ToString
            Current.Month = DateTime.Now.Month.ToString
            Current.Year = DateTime.Now.Year.ToString
            Current.Day = Encrypt(pPassPhrase, Current.Day)
            Current.Month = Encrypt(pPassPhrase, Current.Month)
            Current.Year = Encrypt(pPassPhrase, Current.Year)

            Dim oReg As Microsoft.Win32.RegistryKey
            oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
            oReg = oReg.CreateSubKey(kstrRegSubKeyName)
            oReg.SetValue("UserSettings", Current.Day)
            oReg.SetValue("operatingsystem", Current.Month)
            oReg.SetValue("GUID", Current.Year)
            oReg.Close()
        Catch
        End Try
    End Sub



    Private Function DiffDate(ByVal OrigDay As String, ByVal OrigMonth As String, ByVal OrigYear As String) As Integer
        Try
            Dim D1 As Date = New Date(Convert.ToInt32(OrigYear), Convert.ToInt32(OrigMonth), Convert.ToInt32(OrigDay))
            Return Convert.ToInt32(DateDiff(DateInterval.Day, D1, DateTime.Now))
        Catch
            Return 0
        End Try
    End Function



    Private Function Encrypt(ByRef pPassPhrase As String, ByVal pTextToEncrypt As String) As String
        If pPassPhrase.Length > 16 Then
            pPassPhrase = pPassPhrase.Substring(0, 16)
        End If

        If pTextToEncrypt.Trim.Length = 0 Then
            Return String.Empty
        End If

        Dim skey As New Encryption.Data(pPassPhrase)
        Dim sym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
        Dim objEncryptedData As Encryption.Data
        objEncryptedData = sym.Encrypt(New Encryption.Data(pTextToEncrypt), skey)
        Return objEncryptedData.ToHex
    End Function



    Private Function Decrypt(ByRef pPassPhrase As String, ByVal pHexStream As String) As String
        Try
            Dim objSym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
            Dim encryptedData As New Encryption.Data
            encryptedData.Hex = pHexStream
            Dim decryptedData As Encryption.Data
            decryptedData = objSym.Decrypt(encryptedData, New Encryption.Data(pPassPhrase))
            Return decryptedData.Text
        Catch
            Return Nothing
        End Try
    End Function



    Private Sub license_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opacity = 20

        Dim oReg As Microsoft.Win32.RegistryKey
        oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
        oReg = oReg.CreateSubKey(kstrRegSubKeyName)
        oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\" & kstrRegSubKeyName)
        Dim strOldDay As String = oReg.GetValue("UserSettings", "").ToString
        Dim strOldMonth As String = oReg.GetValue("operatingsystem", "").ToString
        Dim strOldYear As String = oReg.GetValue("GUID", "").ToString
        Dim strRegName As String = oReg.GetValue("USERID", "").ToString
        Dim strRegCode As String = oReg.GetValue("LOCALPATH", "").ToString
        Dim strCompID As String = oReg.GetValue("CompID", "").ToString
        Dim strTrialDone As String = oReg.GetValue("Enable", "").ToString
        oReg.Close()


        If strOldDay = "" Then
            CreateRegKeys(PassPhrase)

            Try
                If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Lanstar\SigningTool") Is Nothing Then
                    CreateSecondRegKey()
                End If
            Catch ex As Exception
            End Try
        End If

      
        strOldDay = Decrypt(PassPhrase, strOldDay)
        strOldMonth = Decrypt(PassPhrase, strOldMonth)
        strOldYear = Decrypt(PassPhrase, strOldYear)



        mintUsedTrialDays = DiffDate(strOldDay, strOldMonth, strOldYear)


        lblApplicationStatus.Text = DisplayApplicationStatus(DiffDate(strOldDay, strOldMonth, strOldYear), mintTrialPeriod)
        statusMessage = "Digital Signatures Tool - trial edition   " & lblApplicationStatus.Text


        If DiffDate(strOldDay, strOldMonth, strOldYear) > mintTrialPeriod Then
            trialExpired = True
            mblnInTrial = False
            oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
            oReg = oReg.CreateSubKey(kstrRegSubKeyName)
            oReg.SetValue("Enable", "1")
            oReg.Close()
        End If


        If strOldMonth = "" Then
        Else
            Dim dtmOldDate As Date = New Date(Convert.ToInt32(strOldYear), Convert.ToInt32(strOldMonth), Convert.ToInt32(strOldDay))
            If Date.Compare(DateTime.Now, dtmOldDate) < 0 Then

                trialExpired = True
                mblnInTrial = False
                oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
                oReg = oReg.CreateSubKey(kstrRegSubKeyName)
                oReg.SetValue("Enable", "1")
                oReg.Close()
            End If
        End If



        If strTrialDone = "1" Then

            trialExpired = True
            mblnInTrial = False
            lblApplicationStatus.Text = "The system clock has been manually changed, and the application has been locked out to prevent unauthorized access!"
            statusMessage = "Digital Signatures Tool - system clock has been manually changed, application has been locked!"
        End If


        If strRegName = "" Then
        Else
            Dim strRN As String = Decrypt(PassPhrase, strRegName)
            Dim strRC As String = Decrypt(PassPhrase, strRegCode)
            Dim UserName As String = strRegName
            UserName = UserName.Remove(16, (UserName.Length - 16))
            If UserName = Decrypt(PassPhrase, strRegCode) Then
                If Encrypt(PassPhrase, System.Net.Dns.GetHostName.ToString) = strCompID Then
                    mblnInTrial = False
                    mblnFullVersion = True

                    strRC = strRC.Insert(4, "-")
                    strRC = strRC.Insert(8, "-")
                    strRC = strRC.Insert(12, "-")

                    lblApplicationStatus.Text = "Licensed version to " + strRN + " with the key " + strRC
                    statusMessage = lblApplicationStatus.Text
                    oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
                    oReg = oReg.CreateSubKey(kstrRegSubKeyName)
                    oReg.SetValue("Enable", "")
                    oReg.Close()
                End If

            End If
        End If

    End Sub



    Private Sub CreateSecondRegKey()
        Try
            Dim Current As CurrentDate
            Current.Day = DateTime.Now.Day.ToString
            Current.Month = DateTime.Now.Month.ToString
            Current.Year = DateTime.Now.Year.ToString

            Dim oReg As Microsoft.Win32.RegistryKey
            oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
            oReg = oReg.CreateSubKey(kstrRegSecondKey)
            oReg.SetValue("StartD", Current.Day)
            oReg.SetValue("StartM", Current.Month)
            oReg.SetValue("StartY", Current.Year)
            oReg.Close()
        Catch
        End Try
    End Sub








End Class
