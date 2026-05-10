using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/promote")]
[Authorize(Roles = "Admin")]
public class PromoteUserController : ControllerBase
{
    [HttpPost("doctor/{userId}")]
    public IActionResult PromoteToDoctor(int userId, [FromQuery] string speciality)
    {
        var logic = new UserRegLogic();
        var result = logic.PromoteToMedic(userId, speciality);
        return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpPost("admin/{userId}")]
    public IActionResult PromoteToAdmin(int userId)
    {
        var logic = new UserRegLogic();
        var result = logic.PromoteToAdmin(userId);
        return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
    }
}