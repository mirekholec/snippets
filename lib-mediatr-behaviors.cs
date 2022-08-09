// WebApplicationBuilder (builder.Services)
Services
    .AddMediatR(typeof(IApplicationAssembly).Assembly)
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>))
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheBehavior
    {}

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {}