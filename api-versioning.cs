// Projekt.csproj
<PackageReference Include="Microsoft.AspNetCore.Mvc.Versioning" Version="4.0.0"/>

// WebApplicationBuilder (builder.Services)
Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});


// RegistrationsController.cs
[ApiVersion("1.0")] // [ApiVersionNeutral]
[Route("api/v{1:apiVersion}")]
public class RegistrationsController : ApiControllerBase
{
}

// RegistrationsController.cs
namespace RestApi.ControllersV2
{
    [ApiVersion("2.0")]
    [Route("api/v{2:apiVersion}")]
    public class RegistrationsController : ApiControllerBase
    {
        [HttpGet, HttpHead]
        [ResponseCache(Duration = 30)]
        [Route("events/{eventId:int}/registrations")]
        public ActionResult<List<RegistrationModel>> GetRegistrations(int eventId, [FromQuery]RegistrationFilter fitler)
        {
            return Ok(new { Name = "Mirek"});
        }
    }
}