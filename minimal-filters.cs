var coursesGroup = app.MapGroup("api").WithTags("Kurzy")
    .AddEndpointFilter((ctx, next) =>
    {
        using var scope = ctx.HttpContext.RequestServices.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation("TRACING IDENTIFIER: " + ctx.HttpContext.TraceIdentifier);

        return next(ctx);
    });