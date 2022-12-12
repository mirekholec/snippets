// NuGet
<PackageReference Include="Microsoft.AspNetCore.Grpc.JsonTranscoding" Version="7.0.0" />

// Program.cs
builder.Services.AddGrpc().AddJsonTranscoding();


// Proto file
import "google/api/annotations.proto";

rpc GetProduct (GetProductRequest) returns (ProductReply){
option (google.api.http) = {
    get: "/products/{id}"
};
}