using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/appointment")]
[Authorize]
public class MedicalAppointmentController : ControllerBase
{
    private readonly IMedicalAppointmentLogic _medicalAppointmentLogic;
    
    public MedicalAppointmentController()
    {
        var bl = new BusinessLogic();
        _medicalAppointmentLogic = bl.GetAppointmentLogic();
    }
    
    [HttpPost("create")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult CreateMedicalAppointment([FromBody] MedicalAppointmentCreateDto medicalAppointmentInfo)
    {
        var result = _medicalAppointmentLogic.CreateMedicalAppointment(medicalAppointmentInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult DeleteMedicalAppointment([FromRoute] int id)
    {
        var result = _medicalAppointmentLogic.DeleteMedicalAppointment(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    
    
    [HttpGet("list")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult GetMedicalAppointmentList()
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }
    
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult GetMedicalAppointmentById([FromRoute] int id)
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentById(id);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
        
    }
    
    [HttpGet("byEmail/{email}")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult GetMedicalAppointmentByEmail([FromRoute] string email)
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentByEmail(email);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    [HttpPut("update/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateMedicalAppointment([FromRoute] int id, [FromBody] MedicalAppointmentCreateDto medicalAppointmentCreate)
    {
        var result = _medicalAppointmentLogic.UpdateMedicalAppointment(id, medicalAppointmentCreate);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
       
        return Ok(result.Message);
    }
    
    [HttpGet("by-date/{date}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetMedicalAppointmentByDate([FromRoute] DateOnly date)
    {
        var result = _medicalAppointmentLogic.GetMedicalAppointmentByDate(date);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }
    
    [HttpPatch("{id}/status")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult UpdateAppointmentsStatus([FromRoute] int id, [FromBody] UpdateAppointmentStatusDto dto)
    {
        var result = _medicalAppointmentLogic.UpdateAppointmentStatus(id, dto.Status);

        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    
}