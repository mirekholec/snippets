// Projekt.csproj
<PackageReference Include="Microsoft.Extensions.Hosting.WindowsServices" Version="6.0.0" />

<OutputType>exe</OutputType>
<PublishSingleFile>true</PublishSingleFile>
<RuntimeIdentifier>win-x64</RuntimeIdentifier>
<PlatformTarget>x64</PlatformTarget>


// Program.cs
IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .Build();

await host.RunAsync();