services.AddOutputCache(x =>
{
    x.AddBasePolicy(x => x.Expire(TimeSpan.FromSeconds(10)));
    x.AddPolicy("Bulbs", builder => builder.Tag("bulb").Expire(TimeSpan.FromSeconds(120)));
    x.AddPolicy("MyPolicy", new MyCustomPolicy());
});


app.UseOutputCache();


app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
}).CacheOutput("MyPolicy");


public async Task<IActionResult> Evict(IOutputCacheStore store)
{
    await store.EvictByTagAsync("bulb", default);

    return Ok();
}