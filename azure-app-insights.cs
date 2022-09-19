// Csproj
<PackageReference Include="Microsoft.ApplicationInsights.AspNetCore" Version="2.21.0" />

// appsettings.json (SDK 2.15+)
{
    "ApplicationInsights": {
        "ConnectionString": "---",
        "EnableAdaptiveSampling": false,
        "EnablePerformanceCounterCollectionModule": false
    }
}

// Program.cs
builder.Logging.AddApplicationInsights();

var aiOptions = new ApplicationInsightsServiceOptions();
aiOptions.EnableAdaptiveSampling = false;
aiOptions.EnableQuickPulseMetricStream = false;
builder.Services.AddApplicationInsightsTelemetry(aiOptions);

// Index.cshtml
@inject Microsoft.ApplicationInsights.AspNetCore.IJavaScriptSnippet JavaScriptSnippet
<head>
    @Html.Raw(JavaScriptSnippet.FullScript)
</head>

// ExampleMiddleware.cs
public class WwwRedirectMiddleware
{
    private readonly RequestDelegate _next;
    private readonly TelemetryClient _telemetryClient;

    public WwwRedirectMiddleware(RequestDelegate next, TelemetryClient telemetryClient)
    {
        _next = next;
        _telemetryClient = telemetryClient;
    }
}