@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

echo Restoring packages
%nuget% restore src\ShuffleBag.sln

echo Building
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\ShuffleBag.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

echo Creating directories
mkdir Build
mkdir Build\lib

echo Creating package
%nuget% pack "src\ShuffleBag.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"