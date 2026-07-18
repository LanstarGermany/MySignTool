pushd %1
copy %2\makecert.exe
makecert -r -pe -n %3 -e %4 -ss My -sr CurrentUser
popd
