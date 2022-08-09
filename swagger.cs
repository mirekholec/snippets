// Projekt.csproj
<PackageReference Include="Swashbuckle.AspNetCore" Version="5.0.0"/>

// WebApplicationBuilder (builder.Services)
Services.AddEndpointsApiExplorer(); // pro minimal APIs
Services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "API Documentation",
    Version = "v1",
}));

// WebApplication
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
    // x.RoutePrefix = string.Empty;
});