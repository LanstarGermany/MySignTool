Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.ComponentModel







Public Class Sign

    ' #define CRYPTUI_WIZ_NO_UI     1
    Public Const CRYPTUI_WIZ_NO_UI As Int32 = 1

    ' #define CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE     0x01
    Public Const CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE As Int32 = 1

    ' #define CRYPTUI_WIZ_DIGITAL_SIGN_CERT                    0x01
    Public Const CRYPTUI_WIZ_DIGITAL_SIGN_CERT As Int32 = 1

   
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CRYPTUI_WIZ_DIGITAL_SIGN_INFO
        Public dwSize As Int32
        Public dwSubjectChoice As Int32
        <MarshalAs(UnmanagedType.LPWStr)> Public pwszFileName As String
        Public dwSigningCertChoice As Int32
        Public pSigningCertContext As IntPtr
        <MarshalAs(UnmanagedType.LPWStr)>
        Public pwszTimestampURL As String
        Public dwAdditionalCertChoice As Int32
        Public pSignExtInfo As IntPtr
    End Structure

   
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT
        Public dwSize As Int32
        Public cbBlob As Int32
        Public pbBlob As IntPtr
    End Structure

   
    <DllImport("Cryptui.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Public Shared Function CryptUIWizDigitalSign( _
        ByVal dwFlags As Int32, _
        ByVal hwndParent As IntPtr, _
        ByVal pwszWizardTitle As String, _
        ByRef pDigitalSignInfo As CRYPTUI_WIZ_DIGITAL_SIGN_INFO, _
        ByRef ppSignContext As IntPtr _
    ) As Boolean
    End Function

  
    <DllImport("Cryptui.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function CryptUIWizFreeDigitalSignContext( _
        ByVal pSignContext As IntPtr _
    ) As Boolean
    End Function

End Class
