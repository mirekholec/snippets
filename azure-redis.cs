// Program.cs
builder.Services.AddSingleton<AzureConnectors>();

// AzureConnectors.cs
public class AzureConnectors
{
    private readonly Lazy<IConnectionMultiplexer> _connectionMultiplexer;

    public IConnectionMultiplexer ConnectionMultiplexer => _connectionMultiplexer.Value;
    public IDatabase GetRedisDatabase(int id = -1) => ConnectionMultiplexer.GetDatabase(id);

    public AzureConnectors(IConfiguration configuration, ILogger<AzureConnectors> logger)
    {
        _connectionMultiplexer = new(() =>
        {
            logger.LogInformation("Initialized ConnectionMultiplexer");
            return StackExchange.Redis.ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}

// RedisCache.cs
public class RedisCache
{
    private readonly AzureConnectors _azureConnectors;
    
    public RedisCache(AzureConnectors azureConnectors)
    {
        _azureConnectors = azureConnectors;
    }

    public void Remove(string key)
    {
        _azureConnectors.GetRedisDatabase().KeyDelete(key, CommandFlags.FireAndForget);
    }
}

// appsettings.json
"ConnectionStrings": {
    "Redis" : "webinario-prod-redis.redis.cache.windows.net:6380,password=EAyTGRpw5syogbTUWtjWA72Mz66do1aMoAzCaBVPaJw=,ssl=True,abortConnect=False"
}