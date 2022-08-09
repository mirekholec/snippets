// Greeter.proto
service Greeter {
  rpc SayHelloStream (HelloRequest) returns (stream HelloReply);
}

// SERVER - GreeterService
public override async Task SayHelloStream(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
{
    // posílání zpráv, dokud klient nepošle cancel request
    while (!context.CancellationToken.IsCancellationRequested)
    {
        var message = $"How are you {request.Name}?";
        await responseStream.WriteAsync(new HelloReply { Message = message });
        await Task.Delay(1000);
    }
}

// CLIENT
private static async Task ServerStreamingCallExample(Greeter.GreeterClient client)
{
    // nastavení cancellation tokenu
    var cts = new CancellationTokenSource();
    cts.CancelAfter(TimeSpan.FromSeconds(6));

    using (AsyncServerStreamingCall<HelloReply> replies = client.SayHelloStream(new HelloRequest { Name = "Aggregate hello" }, cancellationToken: cts.Token))
    {
        try
        {
            await foreach (HelloReply message in replies.ResponseStream.ReadAllAsync(cts.Token))
            {
                Console.WriteLine("Greeting: " + message.Message);
            }
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled) 
        {
            Console.WriteLine("Stream cancelled.");
        }
    }
}