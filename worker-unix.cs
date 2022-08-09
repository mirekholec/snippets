// Projekt.csproj
<PackageReference Include="Microsoft.Extensions.Hosting.Systemd" Version="6.0.0" />

<OutputType>exe</OutputType>
<PublishSingleFile>true</PublishSingleFile>

// Program.cs
IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .Build();

await host.RunAsync();