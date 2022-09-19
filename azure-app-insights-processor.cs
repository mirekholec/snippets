// Program.cs
builder.Services.AddApplicationInsightsTelemetryProcessor<DependencyProcessor>();

// DependencyProcessor.cs
public class DependencyProcessor : ITelemetryProcessor
{
    private ITelemetryProcessor Next { get; set; }

    public DependencyProcessor(ITelemetryProcessor next)
    {
        Next = next;
    }

    public void Process(ITelemetry item)
    {
        if (item is DependencyTelemetry request && request.Duration.TotalMilliseconds < 5)
        {
            return;
        }
        
        Next.Process(item);
    }
}