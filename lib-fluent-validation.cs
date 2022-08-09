// doc: https://docs.fluentvalidation.net/en/latest/aspnet.html

// dotnet add package FluentValidation.AspNetCore

// WebApplicationBuilder (builder.Services)
Services.AddMvc().AddFluentValidation(fv => {
    fv.DisableDataAnnotationsValidation = true;     // vypne ostatní validace po Fluent Val.
    fv.RegisterValidatorsFromAssemblyContaining...  // auto registrace
});

Services.AddTransient<IValidator<Person>, PersonValidator>();


public class PersonValidator : AbstractValidator<Person> 
{
	public PersonValidator() 
    {
		RuleFor(x => x.Name).Length(0, 10);
	}
}