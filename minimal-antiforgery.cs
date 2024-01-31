// Program.cs

builder.Services.AddAntiforgery();


routes.MapGet("orders", (IAntiforgery af, HttpContext httpContext) =>
{
    var token = af.GetAndStoreTokens(httpContext);
    return Results.Ok(token);
});


app.UseAntiforgery();



// example response z /orders
// nutné odeslat v postmanu
{
  "requestToken": "CfDJ8M67giFFBdJIiDgNxVv-4R0ythRbOl5GYqApY0xnE4kCSQwcI4N4rh3Lp-XYGq3jMzz-D9qmuJ0KWi7l8uhNgd64Icqn9mYJf3vesdP_8zXwz4yw96tS7NWkzbK9jNghdwIzcx9yTDI8qgev3zCUMQ0",
  "formFieldName": "__RequestVerificationToken",
  "headerName": "RequestVerificationToken",
  "cookieToken": null
}