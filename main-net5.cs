public static void Main(string[] args)
{
    var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((host, builder) =>
        {
            builder.AddJsonFile("appsettings.json", false, false);
            builder.AddIniFile("appsettings.ini", true, false);
            
            builder.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", false, false);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

    try
    {
        hostBuilder.Build().Run();
    }
    catch (Exception e)
    {
        string key = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build()["applicationinsights_fallbackKey"];
        
        throw;
    }
}