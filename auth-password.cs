// Password Hasher
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.Configure<PasswordHasherOptions>(x =>
{
    x.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
    x.IterationCount = 310000;
});

var hashedPass = _passwordHasher.HashPassword(null, "password");
var result = _passwordHasher.VerifyHashedPassword(null, "dbPass", "formPass");

// Password Validator
builder.Services.AddSingleton<IPasswordValidator<User>, PasswordValidator>();
builder.Services.Configure<PasswordOptions>(x =>
{
    x.RequireDigit = false;
    x.RequiredLength = 8;
    x.RequireLowercase = false;
    x.RequireUppercase = false;
    x.RequiredUniqueChars = 0;
    x.RequireNonAlphanumeric = false;
});

// přeimplementace s ignorací UserManager<>
public class PasswordValidator : PasswordValidator<User>
{
    private readonly IOptions<PasswordOptions> _options;

    public PasswordValidator(IOptions<PasswordOptions> options)
    {
        _options = options;
    }

    public override Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        var errors = new List<IdentityError>();
        var options = _options.Value;

        if (string.IsNullOrWhiteSpace(password) || password.Length < options.RequiredLength)
        {
            errors.Add(Describer.PasswordTooShort(options.RequiredLength));
        }
        if (options.RequireNonAlphanumeric && password.All(IsLetterOrDigit))
        {
            errors.Add(Describer.PasswordRequiresNonAlphanumeric());
        }
        if (options.RequireDigit && !password.Any(IsDigit))
        {
            errors.Add(Describer.PasswordRequiresDigit());
        }
        if (options.RequireLowercase && !password.Any(IsLower))
        {
            errors.Add(Describer.PasswordRequiresLower());
        }
        if (options.RequireUppercase && !password.Any(IsUpper))
        {
            errors.Add(Describer.PasswordRequiresUpper());
        }
        if (options.RequiredUniqueChars >= 1 && password.Distinct().Count() < options.RequiredUniqueChars)
        {
            errors.Add(Describer.PasswordRequiresUniqueChars(options.RequiredUniqueChars));
        }
        return
            Task.FromResult(errors.Count == 0
                ? IdentityResult.Success
                : IdentityResult.Failed(errors.ToArray()));
    }
}