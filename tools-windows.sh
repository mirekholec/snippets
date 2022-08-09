# publikace aplikace
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:GenerateRuntimeConfigurationFiles=true -o output

# registrace
sc.exe create ".NET Service" binpath="C:\Path\To\dotnet.exe C:\Path\To\App.WindowsService.dll"

# start
sc.exe start ".NET Service"

# stop
sc.exe stop ".NET Service"

# delete
sc.exe delete ".NET Service"