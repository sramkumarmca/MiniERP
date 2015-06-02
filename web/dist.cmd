@echo off

:: prepare environment
setlocal enableextensions
set "tempFile=%temp%\%~nx0.%random%.grunt.tmp"

:: run grunt
call grunt dist --no-color > "%tempFile%"

:: Keep the grunt exit code
set "exitCode=%ERRORLEVEL%"

:: Print the grunt output
type "%tempFile%"

:: cleanup and exit with adecuated value
del /q "%tempFile%" >nul 2>nul
endlocal & exit /b %exitCode%
