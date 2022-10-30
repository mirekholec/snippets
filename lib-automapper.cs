// Projekt.csproj
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0" />

// WebApplicationBuilder (builder.Services)
Services.AddAutoMapper(x => x.AddMaps(typeof(IWorkshopperApi)));

// - nebo když je potřeba inject více services z DI
 Services.AddSingleton(sp => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<RegistrationProfile>();
    cfg.AddProfile(new WebinarProfile(sp.CreateScope().ServiceProvider.GetRequiredService<FilePaths>()));
}).CreateMapper());

// MappingProfile.cs
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Registration, RegistrationModel>()
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.FirstName + " " + x.LastName))
            .ForMember(dest => dest.EventName, src => src.MapFrom(x => x.Event.Title));

        CreateMap<RegistrationModelCreate, Registration>();
    }
}