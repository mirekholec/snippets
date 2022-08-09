// Projekt.csproj
<PackageReference Include="Microsoft.AspNetCore.HealthChecks" Version="1.0.0" />
<PackageReference Include="AspNetCore.HealthChecks.UI" Version="5.0.0" />
<PackageReference Include="AspNetCore.HealthChecks.UI.InMemory.Storage" Version="5.0.0" />
<PackageReference Include="AspNetCore.HealthChecks.Uris" Version="5.0.0" />

// WebApplicationBuilder builder.Services
Services
    .AddHealthChecks()
    .AddUrlGroup(new Uri("https://www.miroslavholec.cz"))
    .AddSqlite("DataSource=database.db");

Services
    .AddHealthChecksUI()
    .AddInMemoryStorage();

// WebApplication
app.MapControllers();
app.MapHealthChecks("health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(x =>
{
    x.UIPath = "/health-ui";
});
