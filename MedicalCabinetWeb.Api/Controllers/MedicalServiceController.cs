
using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Entities.MedicalService;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/service")]
public class MedicalServiceController : ControllerBase
{
    private readonly IMedicalServiceLogic _medicalServiceLogic;
    public MedicalServiceController()
    {
        var bl = new BusinessLogic();
        _medicalServiceLogic = bl.GetServiceLogic();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetMedicalServiceById([FromRoute] int id)
    {
        var result = _medicalServiceLogic.GetMedicalServiceById(id);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
        
    }

    [HttpGet("list")]
    [AllowAnonymous]
    public IActionResult GetMedicalServiceList()
    {
        var result = _medicalServiceLogic.GetMedicalServiceList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }


    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateMedicalService([FromBody] MedicalServiceCreateDto medicalServiceInfo)
    {
        var result = _medicalServiceLogic.CreateMedicalService(medicalServiceInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteMedicalService([FromRoute] int id)
    {
        var result = _medicalServiceLogic.DeleteMedicalService(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateMedicalService([FromRoute] int id, [FromBody] MedicalServiceCreateDto medicalServiceCreate)
    {
       var result = _medicalServiceLogic.UpdateMedicalService(id, medicalServiceCreate);
       if (result.IsSuccess == false)
           return StatusCode((int)result.StatusCode, result.Message);
       
       return Ok(result.Message);
    }
    
    [HttpPatch("{id}/category")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateMedicalServiceCategory(int id, [FromBody] ServiceCategory category)
    {
        var result = _medicalServiceLogic.UpdateMedicalServiceCategory(id, category);

        if (!result.IsSuccess)
            return NotFound("Category not found");

        return Ok("Category updated successfully");
    }

    [HttpGet("by-category/{category}")]
    [AllowAnonymous]
    public IActionResult GetMedicalServiceByCategory(ServiceCategory category)
    {
        var result = _medicalServiceLogic.GetMedicalServiceByCategory(category);

        if (!result.IsSuccess)
            return NotFound("No services found for this category");

        return Ok(result.Data);
    }
    
}