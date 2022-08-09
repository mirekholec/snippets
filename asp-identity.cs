// NuGet packages
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.5" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="6.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.5" />
<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="6.0.5" />

// Tooling
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet aspnet-codegenerator identity --dbContext AppDbContext

// DbContext - Table Names
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users"); });
    modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
    modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
    modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
    modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
    modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
    modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
}

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Lockout.MaxFailedAccessAttempts = 5;
    o.Password.RequireDigit = false;
    o.Password.RequiredLength = 5;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequiredUniqueChars = 0;
    o.Password.RequireNonAlphanumeric = false;
    o.User.RequireUniqueEmail = true;
});