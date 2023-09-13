// Projekt.csproj - pro web i konzolovku se přidává AspNetCore
<PackageReference Include="Serilog.AspNetCore" Version="7.0.0" />

// WebApplicationBuilder (builder)
builder.Services.AddSerilog((provider, configuration) =>
{
    configuration.MinimumLevel.Information();
    configuration.WriteTo.Console();
    configuration.WriteTo.File("./log.txt");
});