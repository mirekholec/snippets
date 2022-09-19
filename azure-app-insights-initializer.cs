// Program.cs
buidler.Services.AddSingleton<ITelemetryInitializer, UserTelemetryInitializer>();

// UserTelemetryInitializer.cs
public class UserTelemetryInitializer : ITelemetryInitializer
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Initialize(ITelemetry telemetry)
    {
        var email = _httpContextAccessor?.HttpContext?.User.Identity?.Name;
        var id = _httpContextAccessor?.HttpContext?.User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).Select(x=> x.Value).FirstOrDefault();
        if (!string.IsNullOrEmpty(id) && telemetry is RequestTelemetry reqTelemetry)
        {
            reqTelemetry.Properties.Add("UserId", id);
            reqTelemetry.Properties.Add("UserEmail", email);
        }
    }
}