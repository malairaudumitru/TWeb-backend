using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/appointment")]

public class MedicalAppointmentController : ControllerBase
{
    private readonly IMedicalAppointmentLogic _medicalAppointmentLogic;
    
    public MedicalAppointmentController()
    {
        var bl = new BusinessLogic();
        _medicalAppointmentLogic = bl.GetAppointmentLogic();
    }
    
    [HttpPost("create")]
    public IActionResult CreateMedicalAppointment([FromBody] MedicalAppointmentCreateDto medicalAppointmentInfo)
    {
        var result = _medicalAppointmentLogic.CreateMedicalAppointment(medicalAppointmentInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteMedicalAppointment([FromRoute] int id)
    {
        var result = _medicalAppointmentLogic.DeleteMedicalAppointment(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    
    
    [HttpGet("list")]
    public IActionResult GetMedicalAppointmentList()
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }
    
    
    [HttpGet("{id}")]
    public IActionResult GetMedicalAppointmentById([FromRoute] int id)
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentById(id);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
        
    }
    
    [HttpPut("update/{id}")]
    public IActionResult UpdateMedicalAppointment([FromRoute] int id, [FromBody] MedicalAppointmentCreateDto medicalAppointmentCreate)
    {
        var result = _medicalAppointmentLogic.UpdateMedicalAppointment(id, medicalAppointmentCreate);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
       
        return Ok(result.Message);
    }
    
    [HttpGet("by-date/{date}")]
    public IActionResult GetMedicalAppointmentByDate([FromRoute] DateOnly date)
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentByDate(date);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }
    
    [HttpPatch("{id}/status")]
    public IActionResult UpdateAppointmentsStatus([FromRoute] int id, [FromBody] UpdateAppointmentStatusDto dto)
    {
        var result = _medicalAppointmentLogic.UpdateAppointmentStatus(id, dto.Status);

        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    
}