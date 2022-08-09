// WebApplicationBuilder (builder.Services)
Services.AddHttpLogging(x => { x.LoggingFields = HttpLoggingFields.All; });


// WebApplication
app.UseHttpLogging();


// Namespace pro logování
Microsoft.AspNetCore.HttpLogging