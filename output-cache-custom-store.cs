// Program.cs

services.AddOutputCache(x =>
{
});

builder.Services.AddSingleton<IOutputCacheStore, MyOutputCacheStore>();


// MyOutputCacheStore.cs
public class MyOutputCacheStore : IOutputCacheStore
{
    // todo
}

