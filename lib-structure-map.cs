// StructureMapProviderFactory.cs
public class StructureMapProviderFactory : IServiceProviderFactory<Container>
{
    public Container CreateBuilder(IServiceCollection services)
    {
        var container = new Container();

        container.Configure(config =>
        {
            config.Populate(services);
        });

        return container;
    }

    public IServiceProvider CreateServiceProvider(Container containerBuilder)
    {
        return containerBuilder.GetInstance<IServiceProvider>();
    }
}

// MyStructuremapRegistry.cs
public class MyStructuremapRegistry : Registry
{
    public MyStructuremapRegistry()
    {
        For<MyService>().LifecycleIs(Lifecycles.Transient)
            .Use<MyService>();
    }
}

// WebApplicationBuilder (builder.Services)
builder.Host.ConfigureContainer<Container>(x =>
{
    x.AddRegistry<MyStructuremapRegistry>();
}