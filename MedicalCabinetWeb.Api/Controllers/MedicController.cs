using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Medic;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public IActionResult CreateMedic([FromBody] MedicCreateDto medic)
    {
        var result = _medicLogic.CreateMedic(medic);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetMedicById([FromRoute] int id)
    {
        var result = _medicLogic.GetMedicById(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("list")]
    [AllowAnonymous]
    public IActionResult GetMedicList()
    {
        var result = _medicLogic.GetMedicList();
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateMedic([FromRoute] int id, [FromBody] MedicCreateDto medicCreate)
    {
        var result = _medicLogic.UpdateMedic(id, medicCreate);
        if (result.IsSuccess  == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteMedic([FromRoute] int id)
    {
        var result = _medicLogic.DeleteMedic(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
}