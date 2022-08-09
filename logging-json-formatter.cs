Microsoft.Extensions.Logging.Console
- ConsoleFormatterNames.Json        ConsoleLoggerExtensions.AddJsonConsole()
- ConsoleFormatterNames.Simple      ConsoleLoggerExtensions.AddSimpleConsole()
- ConsoleFormatterNames.Systemd     ConsoleLoggerExtensions.AddSystemdConsole()

// Program.cs
builder.Logging.AddJsonConsole(options =>
{
    options.UseUtcTimestamp = true;
});
    
builder.Logging.AddConsole(options => options.FormatterName = ConsoleFormatterNames.Simple);


// appsettings.json (alternativa)
{
    "Logging": {
        "Console": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft": "Warning",
                "Microsoft.Hosting.Lifetime": "Information"
            },
            "FormatterName": "json",
            "FormatterOptions": {
                "Timestamp": "09:08:33 ",
                "EventId": 0,
                "LogLevel": "Information",
                "Category": "Microsoft.Hosting.Lifetime",
                "Message": "Now listening on: https://localhost:5001",
                "State": {
                    "Message": "Now listening on: https://localhost:5001",
                    "address": "https://localhost:5001",
                    "{OriginalFormat}": "Now listening on: {address}"
                }
            }
        }
    },
    "AllowedHosts": "*"
}