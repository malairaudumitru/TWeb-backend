
using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Entities.MedicalService;
using MedicalCabinetWeb.Domain.Models.MedicalService;
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
    public IActionResult GetMedicalServiceById([FromRoute] int id)
    {
        var result = _medicalServiceLogic.GetMedicalServiceById(id);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
        
    }

    [HttpGet("list")]
    public IActionResult GetMedicalServiceList()
    {
        var result = _medicalServiceLogic.GetMedicalServiceList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }


    [HttpPost("create")]
    public IActionResult CreateMedicalService([FromBody] MedicalServiceCreateDto medicalServiceInfo)
    {
        var result = _medicalServiceLogic.CreateMedicalService(medicalServiceInfo);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMedicalService([FromRoute] int id)
    {
        var result = _medicalServiceLogic.DeleteMedicalService(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateMedicalService([FromRoute] int id, [FromBody] MedicalServiceCreateDto medicalServiceCreate)
    {
       var result = _medicalServiceLogic.UpdateMedicalService(id, medicalServiceCreate);
       if (result.IsSuccess == false)
           return StatusCode((int)result.StatusCode, result.Message);
       
       return Ok(result.Message);
    }
    
    [HttpPatch("{id}/category")]
    public IActionResult UpdateMedicalServiceCategory(int id, [FromBody] ServiceCategory category)
    {
        var result = _medicalServiceLogic.UpdateMedicalServiceCategory(id, category);

        if (!result.IsSuccess)
            return NotFound("Category not found");

        return Ok("Category updated successfully");
    }

    [HttpGet("by-category/{category}")]
    public IActionResult GetMedicalServiceByCategory(ServiceCategory category)
    {
        var result = _medicalServiceLogic.GetMedicalServiceByCategory(category);

        if (!result.IsSuccess)
            return NotFound("No services found for this category");

        return Ok(result.Data);
    }
    
}