// Greeter.proto
service Greeter {
  rpc SayHellosClientStream (stream HelloRequest) returns(HelloReply);
}

// SERVER - GreeterService
public override async Task<HelloReply> SayHellosClientStream(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
{
    var counter1 = 0;
    var counter2 = 0;
    
    await foreach (var message in requestStream.ReadAllAsync())
    {
        counter1++;
    }
    
    while (await requestStream.MoveNext())
    {
        HelloRequest item = requestStream.Current;
        counter2++;
    }
    
    return new HelloReply(){ Message = $"Counter1: {counter1} a Counter2: {counter2}"};
}

// CLIENT
private static async Task ClientStreamingCallExample(Greeter.GreeterClient client)
{
    using var call = client.SayHellosClientStream();
        
    for (int i = 0; i < 10; i++)
    {
        await call.RequestStream.WriteAsync(new HelloRequest() {Name = "Mirek"});
    }

    await call.RequestStream.CompleteAsync();
    var result = await call;
    Console.WriteLine("Stream finished with response: " + result.Message);
}