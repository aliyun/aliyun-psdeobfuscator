@echo off

cd %~dp0
set "profilePath=%USERPROFILE%\Documents\WindowsPowerShell\Microsoft.PowerShell_profile.ps1"
if not exist "%profilePath%" (
    mkdir "%USERPROFILE%\Documents\WindowsPowerShell"
    echo "" > "%profilePath%"
)

echo "" > "%profilePath%"

cd %~dp0
regsvr32 /u /s DeviareLiteCOM64.dll
REG ADD "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /v "__PSLockdownPolicy" /t REG_DWORD /d 0 /f

echo "PSDeObfuscator uninstall success"
pause