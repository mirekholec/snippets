// CSPROJ
<PackageReference Include="Microsoft.AspNetCore.OutputCaching.StackExchangeRedis" Version="8.0.1" />

services.AddOutputCache(x =>
{
}).AddStackExchangeRedisOutputCache(redis =>
{
    redis.Configuration = "localhost:6379";
    redis.InstanceName = "prefix";
});


app.UseOutputCache();