services.AddMemoryCache(options =>
{
    options.TrackStatistics = true;
});

public async Task<IActionResult> GetStats(IMemoryCache cache)
{
    return Ok(new
    {
        Stats = cache.GetCurrentStatistics()
    });
}