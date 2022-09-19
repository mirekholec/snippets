// Program.cs
builder.Services.AddSingleton<AzureConnectors>();

// AzureConnectors.cs
public class AzureConnectors
{
    private readonly Lazy<TableServiceClient> _tableServiceClient;

    public TableServiceClient TableServiceClient => _tableServiceClient.Value;
    public TableClient GetTableClient(string tableName) => TableServiceClient.GetTableClient(tableName);

    public AzureConnectors(IConfiguration configuration, ILogger<AzureConnectors> logger)
    {
        _tableServiceClient = new(() =>
        {
            logger.LogInformation("Initialized TableServiceClient");
            return new TableServiceClient(configuration.GetConnectionString("Storage"));
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}

// AuditTableStorage.cs
public class AuditTableStorage
{
    private readonly AzureConnectors _azureConnectors;
    
    public AuditTableStorage(AzureConnectors azureConnectors)
    {
        _azureConnectors = azureConnectors;
    }

    public async Task Add(AuditLogItem log)
    {
        var tableClient = _azureConnectors.GetTableClient(TableName);
        await tableClient.AddEntityAsync(log);
    }
}

// appsettings.json
"ConnectionStrings": {
    "Storage" : "DefaultEndpointsProtocol=https;AccountName=webinariolocalst;AccountKey=2mX0cYkeCnFhWg7QWaGRe4dcTSo8je+B8H25Y/oErS7aB2x34bBLwfWMkOeVsSA+/YmAMRIAaCZ++AStvMTjew==;EndpointSuffix=core.windows.net"
}