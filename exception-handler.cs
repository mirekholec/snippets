// Program.cs

builder.Services.AddExceptionHandler<ApiValidationExceptionHandler>();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

app.UseExceptionHandler();


// ApiValidationExceptionHandler.cs

public class ApiValidationExceptionHandler(IHostEnvironment env) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ValidationException)
        {
            ValidationProblemDetails pd = new ValidationProblemDetails();
            pd.Title = "Internal Server Error";
            pd.Status = StatusCodes.Status400BadRequest;
            pd.Detail = env.IsDevelopment() ? exception.Message : string.Empty;
            pd.Extensions.Add("trace_Id", "XOXOOOX");

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(pd);

            return true; // konec pipeline
        }

        return false; // umožní propad do dalšího handleru
    }
}