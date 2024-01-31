builder.Services.AddProblemDetails(x =>
{
    x.CustomizeProblemDetails = (y) =>
    {
        if (y.Exception is ValidationException)
        {
            y.ProblemDetails = new ValidationProblemDetails()
            {
                Title = "Validation Error: " + y.ProblemDetails.Title,
                Status = 400
            };
            y.HttpContext.Response.StatusCode = 400;
        }
    };
});