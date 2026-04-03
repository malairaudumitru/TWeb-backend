using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/medici")]
public class MedicController : ControllerBase
{
    private readonly BusinessLogic _businessLogic;

    public MedicController()
    {
        _businessLogic = new BusinessLogic(new UserDbContext());
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_businessLogic.GetMedicLogic().GetALL());
    }
}