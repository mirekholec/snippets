// NuGet Package 
Microsoft.AspNetCore.Mvc.Testing

// Program.cs visibility
<ItemGroup>
     <InternalsVisibleTo Include="Web.Tests" />
</ItemGroup>

public partial class Program { }

// Test
public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        // zde se provede příprava databáze (ens dele, ens crea, add seed)
    }
}

// Custom factory
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            services.Remove(dbContextDescriptor);
            var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType ==typeof(DbConnection));
            services.Remove(dbConnectionDescriptor);

            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=tests.sqlite");
                connection.Open();
                return connection;
            });

            services.AddDbContext<ApplicationDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });
        });

        builder.UseEnvironment("Development");
    }
}