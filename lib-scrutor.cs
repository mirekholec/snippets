// Projekt.csproj
<PackageReference Include="Scrutor" Version="3.3.0" /> 

// WebApplicationBuilder (builder.Services)
Services.Scan(selector => selector
    .FromAssemblyOf<IApiException>()
    .AddClasses(x => x.AssignableTo<IApiException>())
    .AsImplementedInterfaces()
    .WithTransientLifetime());

Services.Scan(selector => selector
    .FromAssemblyOf<CustomerFacade>()
    .AddClasses(x => x.WithAttribute<ScopedServiceAttribute>())
    .AsMatchingInterface()
    .WithScopedLifetime());

Services.Scan(selector => selector
    .FromAssemblyOf<CustomerRepository>()
    .AddClasses(x => x.WithAttribute<ScopedServiceAttribute>())
    .AsMatchingInterface()
    .WithScopedLifetime());