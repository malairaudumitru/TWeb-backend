using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/health")]
[AllowAnonymous]
public class HealthController : ControllerBase
{
    [HttpGet("check")]
    public IActionResult Check()
    {
        return Ok("Server is up and running");
    }
}