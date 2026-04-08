using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Medic;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/medic")]
public class MedicController : ControllerBase
{
    private readonly IMedicLogic _medicLogic;

    public MedicController()
    {
        var bl = new BusinessLogic();
        _medicLogic = bl.GetMedicLogic();
    }

    [HttpPost("Create")]
    public IActionResult CreateMedic([FromBody] MedicCreateDto medic)
    {
        var result = _medicLogic.CreateMedic(medic);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpGet("{id}")]
    public IActionResult GetMedicById([FromRoute] int id)
    {
        var result = _medicLogic.GetMedicById(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }
}