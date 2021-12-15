echo off
SET name=day%1
mkdir %name%
cd %name%
dotnet new console
SET input=string[] input = File.ReadAllLines("./input");
echo %input%> Program.cs
tasklist /FI "IMAGENAME eq code.exe" 2>NUL | find /I /N "code.exe">NUL
if "%ERRORLEVEL%"=="1" code.cmd ..