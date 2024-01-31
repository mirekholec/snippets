services.AddRateLimiter(x =>
{
    x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    x.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(ct =>
        RateLimitPartition.GetFixedWindowLimiter(ct.Connection.RemoteIpAddress.ToString(),
            p => new FixedWindowRateLimiterOptions()
            {
                AutoReplenishment = true,
                PermitLimit = 5,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            })
    );
    x.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var after))
        {
            await context.HttpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Title = "Too many requests",
                Status = 429,
                Detail = $"Rate limit is {after} seconds"
            }, token);
        }
    };
});


app.UseRateLimiter();