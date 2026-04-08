using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Patient;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController: ControllerBase
{
    private readonly IPatientLogic _patientLogic;

    public PatientController()
    {
        var bl = new BusinessLogic();
        _patientLogic = bl.GetPatientLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientById([FromRoute] int id)
    {
        var result = _patientLogic.GetPatientById(id);
        if (result.IsSuccess == false)
            return  BadRequest(result.Message);
        
        return Ok(result.Data);
        
    }

    [HttpGet("list")]
    public IActionResult GetPatientList()
    {
        var result = _patientLogic.GetPatientList();
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPost("Create")]
    public IActionResult CreatePatient([FromBody] PatientCreateDto patient)
    {
        var result = _patientLogic.CreatePatient(patient);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        
        return Ok(result.Message);
        {
            
        }
    }
}