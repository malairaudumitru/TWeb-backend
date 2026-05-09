using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[Route("api/session")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IUserLoginLogic _userLogin;

    public AuthController()
    {
        var bl = new BusinessLogic();
        _userLogin = bl.GetUserLoginLogic();
    }

    [HttpPost("Auth")]
    public IActionResult Auth([FromBody] UserLoginDto udata)
    {
        var result = _userLogin.UserLoginDataValidation(udata);

        if (!result.IsSuccess)
            return Unauthorized(result.Message);

        return Ok(new { token = result.Message });
    }
}