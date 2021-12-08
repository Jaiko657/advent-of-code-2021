echo off
SET name=day%1
mkdir %name%
cd %name%
dotnet new console
tasklist /FI "IMAGENAME eq VSCodium.exe" 2>NUL | find /I /N "VSCodium.exe">NUL
if "%ERRORLEVEL%"=="1" codium.cmd ..