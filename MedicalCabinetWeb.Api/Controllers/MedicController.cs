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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var medic = _businessLogic.GetMedicLogic().GetById(id);
        if (medic == null)
            return NotFound("Medic cu id {id} nu a fost gasit");
        return Ok(medic);
    }
    
    
    
    [HttpGet("speciality/{speciality}")]
    public IActionResult GetBySpeciality(MedicSpeciality speciality)
    {
        var medici = _businessLogic.GetMedicLogic().GetBySpeciality(speciality);
        if (medici.Count == 0)
            return NotFound(" Nu exista medici cu specialitatea {speciality}.");
        return Ok(medici);
    }
    
}