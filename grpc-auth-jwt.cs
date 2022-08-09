// Server.csproj
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.1"/>

// GreetingService.cs
[Authorize]
public override async Task<HelloReply> SayUserHello(HelloRequest request, ServerCallContext context)
{
    var httpContext = context.GetHttpContext();
    
    return await Task.FromResult(
        new HelloReply
        {
            Message = "Přihlášen uživatel " + httpContext.User.Identity?.Name
        }
    );
}

// WebApplicationBuilder (builder.Services)
Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateLifetime = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dsjkds866žáasžřsá8čsaáddgaasj"))
            };
    });

Services.AddAuthorization(options =>
{
    options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireClaim(ClaimTypes.Name);
    });
});

// WebApplication
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/auth/token", async context =>
{
    var name = context.Request.Query["name"];
    
    if (string.IsNullOrEmpty(name))
    {
        throw new InvalidOperationException("Name is not specified.");
    }

    var claims = new[] { new Claim(ClaimTypes.Name, name) };
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken("ExampleServer", "ExampleClients", claims, expires: DateTime.Now.AddSeconds(60), signingCredentials: credentials);
    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

    await context.Response.WriteAsync(tokenString);
});


// Client - Program.cs
private static async Task<string> Auth()
{
    var httpClient = new HttpClient();
    var request = new HttpRequestMessage
    {
        RequestUri = new Uri($"http://localhost:5000/auth/token?name={HttpUtility.UrlEncode(Environment.UserName)}"),
        Method = HttpMethod.Get,
        Version = new Version(2, 0)
    };
    var tokenResponse = await httpClient.SendAsync(request);
    tokenResponse.EnsureSuccessStatusCode();

    string token = await tokenResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Successfully authenticated.");
    Console.WriteLine("Auth token test: " + token); // !! demo, nikdy nelogovat klíče

    return token;
}