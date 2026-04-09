@echo off
cd /d "%~dp0"
echo Compiling AudioTray...
echo.
"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe" /target:winexe /platform:anycpu /out:"WOW-MrBeast.exe" /reference:System.dll /reference:System.Core.dll /reference:System.Windows.Forms.dll /reference:System.Drawing.dll /reference:System.dll AudioTray.cs
if %ERRORLEVEL% EQU 0 (
    echo.
    echo Compilation successful!
    echo Executable: AudioTray.exe
) else (
    echo.
    echo Compilation failed! Please ensure .NET Framework 3.5 is installed.
)
echo.
pause
