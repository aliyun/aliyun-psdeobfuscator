@echo off

cd %~dp0
powershell Set-ExecutionPolicy RemoteSigned
regsvr32 /s DeviareLiteCOM64.dll
REG ADD "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /v "__PSLockdownPolicy" /t REG_DWORD /d 8 /f

set "profilePath=%USERPROFILE%\Documents\WindowsPowerShell\Microsoft.PowerShell_profile.ps1"
if not exist "%profilePath%" (
    mkdir "%USERPROFILE%\Documents\WindowsPowerShell"
    echo "" > "%profilePath%"
)

set "current_path=%~dp0"
set "replacement_path=%current_path%"
set "command=Add-Type -Path "%replacement_path%PSDeObfuscator.dll";[PSDeObfuscator.PowershellApiHookHelper]::EnableAllhook()"
echo %command% > "%profilePath%"

echo "PSDeObfuscator install success"