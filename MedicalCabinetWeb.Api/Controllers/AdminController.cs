using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Medic;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminLogic _adminLogic;

    public AdminController()
    {
        var bl = new BusinessLogic();
        _adminLogic = bl.GetAdminLogic();
    }
    
    [HttpPost("Create")]
    public IActionResult CreateAdmin([FromBody] AdminCreateDto admin)
    {
        var result = _adminLogic.CreateAdmin(admin);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
}