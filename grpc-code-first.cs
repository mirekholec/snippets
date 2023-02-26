// Server.csproj
<PackageReference Include="protobuf-net.Grpc.AspNetCore" Version="1.0.179" />
<PackageReference Include="protobuf-net.Grpc.AspNetCore.Reflection" Version="1.0.179" />

// Contracts.csproj
<PackageReference Include="protobuf-net.Grpc" Version="1.0.179" />
<PackageReference Include="System.ServiceModel.Primitives" Version="4.10.0" />

      [ServiceContract]
      [OperationContract]
      [ProtoContract]
      [ProtoMember(1)]

// Klient.csproj
<PackageReference Include="protobuf-net.Grpc.ClientFactory" Version="1.0.179" />
<PackageReference Include="Grpc.Net.ClientFactory" Version="2.50.0" /> // standardní extenze pro AddCallCredentials...