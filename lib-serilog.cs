// Projekt.csproj - pro web i konzolovku se přidává AspNetCore
<PackageReference Include="Serilog.AspNetCore" Version="4.1.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="4.0.1" />
<PackageReference Include="Serilog.Sinks.Debug" Version="2.0.0" />

// WebApplicationBuilder (builder)
builder.Host.UseSerilog((h, l) =>
{
    l.ReadFrom.Configuration(h.Configuration);
    l.WriteTo.Console();
    l.WriteTo.Debug();
})