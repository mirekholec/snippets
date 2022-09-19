// Program.cs
builder.Services.AddSingleton<AzureConnectors>();

// AzureConnectors.cs
public class AzureConnectors
{
    private readonly Lazy<ServiceBusClient> _serviceBusClient;

    public ServiceBusClient ServiceBusClient => _serviceBusClient.Value;

    public AzureConnectors(IConfiguration configuration, ILogger<AzureConnectors> logger)
    {
        _serviceBusClient = new(() =>
        {
            logger.LogInformation("Initialized ServiceBusClient");
            return new ServiceBusClient(configuration.GetConnectionString("ServiceBus"),
                new ServiceBusClientOptions()
                {
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        MaxRetries = 3,
                        MaxDelay = TimeSpan.FromSeconds(1)
                    }
                });
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}

// ServiceBusEmailingQueue.cs
public class ServiceBusEmailingQueue
{
    private const string QueueName = "emailing";
    private readonly AzureConnectors _azureConnectors;
    private ServiceBusSender _sender;
    private ServiceBusReceiver _receiver;
    
    public ServiceBusEmailingQueue(AzureConnectors azureConnectors)
    {
        _azureConnectors = azureConnectors;
    }

    public async Task Enqueue(Registration registration)
    {
        var client = GetSender();
        await client.SendMessageAsync(new ServiceBusMessage()
        {
            TimeToLive = TimeSpan.FromDays(1),
            Body = BinaryData.FromObjectAsJson(registration, _jsonSerializerOptions)
        });
    }

    public async Task<Registration> Dequeue()
    {
        var client = GetReceiver();
        var message = await client.ReceiveMessageAsync();
        var result = message.Body.ToObjectFromJson<Registration>(_jsonSerializerOptions);
        await client.CompleteMessageAsync(message);

        return result;
    }

    private ServiceBusSender GetSender()
    {
        if (_sender == null || _sender.IsClosed)
        {
            _sender = _azureConnectors.ServiceBusClient.CreateSender(QueueName");
        }

        return _sender;
    }

    private ServiceBusReceiver GetReceiver()
    {
        if (_receiver == null || _receiver.IsClosed)
        {
            _receiver =_azureConnectors.ServiceBusClient.CreateReceiver(QueueName");
        }

        return _receiver;
    }
}

// appsettings.json
"ConnectionStrings": {
    "ServiceBus" : "Endpoint=sb://webinarioprodsb.servicebus.windows.net/;SharedAccessKeyName=WebinarioProcessors;SharedAccessKey=dJFAt41SQKivwiKLAYkgQqoiEgOr9QI0SRdAYBsOtbI="
}