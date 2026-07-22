This GUI application makes it easy to sign all kind of scripts, executables, PDF documents, RDP connection files...
Select the folders with the files you want to get signed and run the code-signing process.
Ideal for people who know what code signing is, but don’t know how to put it into practice.

Requirements:
a valid Code Signing certificate, either from a Public CA like Digicert or from your own CA

Compile: 
load the source, choose Release X64, then copy the files to a directory of your choice.
no installation neccessary afterwards. After compilation, save all files in a folder, then just start signtool.exe.

Make sure to open a direct outbound connection if you intend to run the tool in a restricted environment: allow connections at least to following URL's
http://timestamp.digicert.com
http://timestamp.sectigo.com
http://timestamp.acs.microsoft.com
http://www.msftconnecttest.com/connecttest.txt


Supported file extensions can be signed:
* .application
* .appx
* .appxbundle
* .cab
* .cat
* .cdxml
* .cpl
* .dll
* .exe
* .manifest
* .msi
* .msix
* .msixbundle
* .msp
* .mst
* .ocx
* .pdf
* .ps1
* .ps1xml
* .psd1
* .psm1
* .pssc
* .rdp
* .scr
* .sys
* .xaml

be aware that signed RDP connection files do not have a timestamp, hence the signature will be not valid when the certificate is expired, then they must be signed again.
PDF files are stored in folder C:\soft\Signing\PDF-Files-signed after they have been signed.

