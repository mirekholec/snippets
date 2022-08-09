// Projekt.csproj
<Project Sdk="Microsoft.NET.Sdk.Web">

  <ItemGroup>
    <PackageReference Include="Autofac.AspNetCore.Extensions" Version="1.0.7" />
  </ItemGroup>


// WebApplicationBuilder
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())

// WebApplication
builder.Host.ConfigureContainer<ContainerBuilder>(x =>
{
    x.RegisterType<OrderService>().InstancePerLifetimeScope();
    x.RegisterType<OrderHandler>().InstancePerLifetimeScope();
    x.RegisterType<TimeService>().InstancePerLifetimeScope();
});


