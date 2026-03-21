
using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/service")]
public class MedicalServiceController: ControllerBase
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
    public IActionResult GetMedicalProductList()
    {
        var result = _medicalServiceLogic.GetMedicalServiceList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }


    [HttpPost("create")]
    public IActionResult CreateMedicalService([FromBody] MedicalServiceDto medicalService)
    {
        var result = _medicalServiceLogic.CreateMedicalService(medicalService);
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

    [HttpPut("update")]
    public IActionResult UpdateMedicalService([FromBody] MedicalServiceDto medicalService)
    {
       var result = _medicalServiceLogic.UpdateMedicalService(medicalService);
       if (result.IsSuccess == false)
           return StatusCode((int)result.StatusCode, result.Message);
       
       return Ok(result.Message);
    }
    
    
    //daca modifici de pe front adaug
    //HttpPut / HttpPatch
    //HttpDelete
}