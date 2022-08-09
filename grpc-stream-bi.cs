// Greeter.proto
service Greeter {
  rpc SayBiDirectionalHello(stream HelloRequest) returns (stream HelloReply);
}

// SERVER - GreeterService
public override async Task SayBiDirectionalHello(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream,
    ServerCallContext context)
{
    while (await requestStream.MoveNext())
    {
        HelloRequest item = requestStream.Current;
        await responseStream.WriteAsync(new HelloReply(){Message = "I got " + item.Name});
    }
}

// CLIENT
private static async Task BiDirectionalCallExample(Greeter.GreeterClient client)
{
    using var call = client.SayBiDirectionalHello();

    for (int i = 0; i < 10; i++)
    {
        await call.RequestStream.WriteAsync(new HelloRequest() {Name = "Mirek " + i});
    }
    
    while (await call.ResponseStream.MoveNext())
    {
        Console.WriteLine(call.ResponseStream.Current.Message);
    }
    
    await call.RequestStream.CompleteAsync();
}