// Projekt.csproj
<PackageReference Include="Microsoft.AspNetCore.HeaderPropagation" Version="6.0.0"/>

// WebApplicationBuilder (builder.Services)
Services.AddHeaderPropagation(x =>
{
    // propaguj hlavičku dále
    x.Headers.Add("X-Correlation-ID");

    // propaguj hlavičku dále s novým názvem (klíčem)
    x.Headers.Add("X-Correlation-ID", "Correlation-Id");
});

// propaguje hlavičky do requestů (delegating handler)
Services.AddHttpClient<GitHubClient>(c =>
{
}).AddHeaderPropagation();


// WebApplication
app.UseHeaderPropagation();