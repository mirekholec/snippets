public class MyExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public MyExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        // tady

        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            httpContext.Response.Clear();
            // httpContext
        }
        
        // tady
    }
}