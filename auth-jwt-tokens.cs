// Projekt.csproj
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.2"/>
<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="5.6.0"/>

// Generování tokenu včetně claimů
var tokenHandler = new JwtSecurityTokenHandler();
var key = Encoding.ASCII.GetBytes("asdfghjklasdfghjkl");
var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[] 
        {
            new Claim(ClaimTypes.Name, "username"),
            new Claim(ClaimTypes.Role, "admin")
    }),
    Expires = DateTime.UtcNow.AddDays(1),
    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
};
var token = tokenHandler.CreateToken(tokenDescriptor);

return new TokenInfo()
{
    Token = tokenHandler.WriteToken(token),
    Expires = token.ValidTo
};

// WebApplicationBuilder (builder.Services)
Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    var key = Encoding.ASCII.GetBytes("asdfghjklasdfghjkl");
    
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});