using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/patients")]
[Authorize]
public class PatientController : ControllerBase
{
    private readonly IPatientLogic _patientLogic;

    public PatientController()
    {
        var bl = new BusinessLogic();
        _patientLogic = bl.GetPatientLogic();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Patient")]
    public IActionResult GetPatientById([FromRoute] int id)
    {
        var result = _patientLogic.GetPatientById(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);

    }

    [HttpGet("list")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetPatientList()
    {
        var result = _patientLogic.GetPatientList();
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }

    [HttpPost("Create")]
    [Authorize(Roles = "Patient")]
    public IActionResult CreatePatient([FromBody] PatientCreateDto patient)
    {
        var result = _patientLogic.CreatePatient(patient);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpPut("Update/{id}")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult UpdatePatient([FromRoute] int id, [FromBody] PatientCreateDto patientCreate)
    {
        var result = _patientLogic.UpdatePatient(id, patientCreate);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeletePatient([FromRoute] int id)
    {
        var result = _patientLogic.DeletePatient(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
}
   
    
    

  