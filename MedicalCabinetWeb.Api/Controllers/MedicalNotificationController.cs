using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/notification")]
public class MedicalNotificationController : ControllerBase
{
    private readonly IMedicalNotificationLogic _medicalNotificationLogic;

    public MedicalNotificationController()
    {
        var bl = new BusinessLogic();
        _medicalNotificationLogic = bl.GetNotificationLogic();
            
    }
    
    [HttpPost("create")]
    public IActionResult CreateMedicalNotification([FromBody] MedicalNotificationCreateDto medicalNotificationInfo)
    {
        var result = _medicalNotificationLogic.CreateMedicalNotification(medicalNotificationInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteMedicalNotification([FromRoute] int id)
    {
        var result = _medicalNotificationLogic.DeleteMedicalNotification(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
}