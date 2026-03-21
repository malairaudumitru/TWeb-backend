
using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/service")]
public class MedicalServiceController: ControllerBase
{
    private readonly IServiceLogic _serviceLogic;
    public MedicalServiceController()
    {
        var bl = new BusinessLogic();
        _serviceLogic = bl.GetServiceLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetServiceById([FromRoute] int id)
    {
        var result = _serviceLogic.GetServiceById(id);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
        
    }

    [HttpGet("list")]
    public IActionResult GetProductList()
    {
        var result = _serviceLogic.GetServiceList();
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Data);
    }


    [HttpPost("create")]
    public IActionResult CreateService([FromBody] MedicalServiceDto medicalService)
    {
        var result = _serviceLogic.CreateService(medicalService);
        if(result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        
        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteService([FromRoute] int id)
    {
        var result = _serviceLogic.DeleteService(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
    
    
    //daca modifici de pe front adaug
    //HttpPut / HttpPatch
    //HttpDelete
}