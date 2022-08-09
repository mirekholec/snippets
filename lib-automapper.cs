// Projekt.csproj
<PackageReference Include="Automapper" Version="10.1.1" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="8.1.0" />

// WebApplicationBuilder (builder.Services)
Services.AddAutoMapper(typeof(IApplicationAssembly));

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