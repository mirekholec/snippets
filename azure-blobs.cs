// Program.cs
builder.Services.AddSingleton<AzureConnectors>();

// AzureConnectors.cs
public class AzureConnectors
{
    private readonly Lazy<BlobServiceClient> _blobServiceClient;

    public BlobServiceClient BlobServiceClient => _blobServiceClient.Value;
    public BlobContainerClient GetBlobContainer(string name) => BlobServiceClient.GetBlobContainerClient(name);

    public AzureConnectors(IConfiguration configuration, ILogger<AzureConnectors> logger)
    {
        _blobServiceClient = new(() =>
        {
            logger.LogInformation("Initialized BlobServiceClient");
            return new BlobServiceClient(configuration.GetConnectionString("Storage"));
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}

// BlobUploadService.cs
public class BlobUploadService
{
    private readonly AzureConnectors _azureConnectors;
    
    public BlobUploadService(AzureConnectors azureConnectors)
    {
        _azureConnectors = azureConnectors;
    }

    public async Task UploadFile(Stream stream, string container, string blob, CancellationToken ctn)
    {
        var client = _azureConnectors.GetBlobContainer(container).GetBlockBlobClient(blob);
        await client.UploadAsync(stream, new BlobHttpHeaders()
        {
            CacheControl = "max-age=4000",
            ContentType = "image/jpg"
        }, cancellationToken: ctn);
    }
}

// appsettings.json
"ConnectionStrings": {
    "Storage" : "DefaultEndpointsProtocol=https;AccountName=webinariolocalst;AccountKey=2mX0cYkeCnFhWg7QWaGRe4dcTSo8je+B8H25Y/oErS7aB2x34bBLwfWMkOeVsSA+/YmAMRIAaCZ++AStvMTjew==;EndpointSuffix=core.windows.net"
}