using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
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
    
    
    
}