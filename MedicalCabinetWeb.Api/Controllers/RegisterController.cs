using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[Route("api/register")]
[ApiController]
[AllowAnonymous]
public class RegisterController : ControllerBase
{
    private readonly IUserRegLogic _userReg;

    public RegisterController()
    {
        var bl = new BusinessLogic();
        _userReg = bl.GetUserRegLogic();
    }

    [HttpPost]
    public IActionResult Register([FromBody] UserRegisterDto uRegData)
    {
        var result = _userReg.UserRegDataValidation(uRegData);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }
}