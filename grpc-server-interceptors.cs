// WebApplicationBuilder (builder.Services)
Services.AddGrpc(x =>
{
    // globální registrace
    x.Interceptors.Add<LoggingInterceptor>();
})
.AddServiceOptions<GreeterService>(x=> x.Interceptors.Add<LoggingInterceptor>()); // registrace pro službu


// Interceptor.cs
public class LoggingInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception e)
        {
        }
        
        throw new RpcException(new Status(StatusCode.Internal, "GENERAL ERROR"));
    }
}