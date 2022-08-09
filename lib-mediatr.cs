// Projekt.csproj
<PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="9.0.0" />

// WebApplicationBuilder (builder.Services)
Services.AddMediatR(typeof(Startup).Assembly);