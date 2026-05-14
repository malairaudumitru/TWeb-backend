using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/notification")]
[Authorize]
public class MedicalNotificationController : ControllerBase
{
    private readonly IMedicalNotificationLogic _medicalNotificationLogic;

    public MedicalNotificationController()
    {
        var bl = new BusinessLogic();
        _medicalNotificationLogic = bl.GetNotificationLogic();
            
    }
    
    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateMedicalNotification([FromBody] MedicalNotificationCreateDto medicalNotificationInfo)
    {
        var result = _medicalNotificationLogic.CreateMedicalNotification(medicalNotificationInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }
    
    [HttpDelete("{id}/delete")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult DeleteMedicalNotification([FromRoute] int id)
    {
        var result = _medicalNotificationLogic.DeleteMedicalNotification(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    [HttpPut("{id}/read-status")]
    [Authorize(Roles = "Patient")]
    public IActionResult UpdateReadStatus([FromRoute] int id)
    {
        var result = _medicalNotificationLogic.UpdateReadStatus(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    [HttpPut("{userId}/mark-all-read")]
    [Authorize(Roles = "Patient")]
    public IActionResult MarkAllAsRead([FromRoute] int userId)
    {
        var result = _medicalNotificationLogic.MarkAllAsRead(userId);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    [HttpGet("list")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetMedicalNotificationList()
    {
        var result = _medicalNotificationLogic.GetMedicalNotificationList();
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    [HttpGet("{id}/by-id")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetMedicalNotificationById([FromRoute] int id)
    {
        var result = _medicalNotificationLogic.GetMedicalNotificationById(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    [HttpGet("{userId}/by-user-id")]
    [Authorize(Roles = "Patient,Admin")]
    public IActionResult GetMedicalNotificationByUserId([FromRoute] int userId)
    {
        var result = _medicalNotificationLogic.GetMedicalNotificationByUserId(userId);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Data);
    }
    
    
}