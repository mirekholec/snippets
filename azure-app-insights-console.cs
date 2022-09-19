// Csproj
<PackageReference Include="Microsoft.ApplicationInsights.WorkerService" Version="2.21.0" />

// Program.cs
TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
configuration.ConnectionString = "---";
var telemetryClient = new TelemetryClient(configuration);

// Program.cs (config file)
TelemetryConfiguration configuration = TelemetryConfiguration.Active; // read ApplicationInsights.config
TelemetryConfiguration configuration = TelemetryConfiguration.CreateFromConfiguration(File.ReadAllText("C:\\ApplicationInsights.config"));
var telemetryClient = new TelemetryClient(configuration);