// WebApplicationBuilder (builder.Services)
Services.AddAuthentication(x =>
{
    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

Services.AddAuthorization(x =>
{
    x.AddPolicy("mirek", policyBuilder => policyBuilder.RequireUserName("mirek"));
    x.AddPolicy("admin", policyBuilder => policyBuilder.RequireRole("admin"));
});

Services.Configure<CookiePolicyOptions>(options =>
{
	options.CheckConsentNeeded = context => true;
	options.MinimumSameSitePolicy = SameSiteMode.None;
});

// WebApplication
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();


// Controller - Login
[HttpGet("login")]
[AllowAnonymous]
public IActionResult Login()
{
    var identity = new ClaimsIdentity(new []
    {
        new Claim(ClaimTypes.Name, "mirek"),
        new Claim(ClaimTypes.NameIdentifier, "mirek"),
        new Claim(ClaimTypes.Role, "admin")
    }, CookieAuthenticationDefaults.AuthenticationScheme);
    
    var principal = new ClaimsPrincipal(identity);
    
    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
    {
        IsPersistent = true
    });
    
    return Ok();
}