<PackageReference Include="Microsoft.Extensions.Http.Polly" Version="6.0.0"/>

builder.Services.AddHttpClient<MyHttpService>(c =>
{
    c.BaseAddress = new Uri("https://www.miroslavholec.cz/api/");
})
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddPolicyHandler(_ =>
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                retryAttempt)));
    });