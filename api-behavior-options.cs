mvcBuilder.ConfigureApiBehaviorOptions(options =>
{
    // nevalidní ModelState je v pořádku
    options.SuppressModelStateInvalidFilter = true;
    
    options.InvalidModelStateResponseFactory = p =>
    {
        return new UnprocessableEntityObjectResult(new ValidationProblemDetails(p.ModelState));
    };
});