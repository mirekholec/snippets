# publikace aplikace
dotnet publish -c Release -r osx-arm64 -p:PublishSingleFile=true -p:GenerateRuntimeConfigurationFiles=true -o output

# seznam daemonů
launchctl list
launchctl list | grep -i Nazev