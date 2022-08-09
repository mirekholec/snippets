// Client.csproj
<ItemGroup>
    <PackageReference Include="Google.Protobuf" Version="3.14.0" />
    <PackageReference Include="Grpc.Tools" Version="2.33.1" />
    <PackageReference Include="Grpc.Net.ClientFactory" Version="2.33.1" />
</ItemGroup>

<ItemGroup>
    <Protobuf Include="..\GrpcServer\Protos\greet.proto" GrpcServices="Client" />
</ItemGroup>

// Program.cs
GrpcChannel channel = GrpcChannel.ForAddress(new Uri("http://localhost:5000"));                
var client = new Greeter.GreeterClient(channel);
client.SayHello(new HelloRequest { Name = "Mirek" });