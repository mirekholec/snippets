// Projekt.csproj
<PackageReference Include="Swashbuckle.AspNetCore.Filters" Version="5.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="5.0.0" />

// WebApplicationBuilder (builder.Services)
Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo());
    x.ExampleFilters();
});

Services.AddSwaggerExamplesFromAssemblyOf<CreateCourseModel>();

// CreateCourseModel
public class CreateCourseModelExample : IExamplesProvider<CreateCourseModel>
{
    public CreateCourseModel GetExamples()
    {
        return new CreateCourseModel()
        {
            Title = "Ahoj"
        };
    }
}