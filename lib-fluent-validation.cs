// doc: https://docs.fluentvalidation.net/en/latest/aspnet.html

// Project.csproj
<PackageReference Include="FluentValidation.AspNetCore" Version="11.2.2" />
<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.2.2" />

// WebApplicationBuilder (builder.Services)
Services.AddFluentValidationAutoValidation(x =>
{
    x.DisableDataAnnotationsValidation = true;
});
Services.AddValidatorsFromAssemblyContaining(typeof(IWorkshopperApi));
Services.AddTransient<IValidator<Person>, PersonValidator>();


public class PersonValidator : AbstractValidator<Person> 
{
	public PersonValidator() 
    {
		RuleFor(x => x.Name).Length(0, 10);
	}
}