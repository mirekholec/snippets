// Projekt.csproj
<PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="11.0.0" />

// WebApplicationBuilder (builder.Services)
Services.AddMediatR(typeof(IWorkshopperApi));