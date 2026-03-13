
using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/service")]
public class ServiceController: ControllerBase
{
    private readonly IServiceLogic _serviceLogic;
    public ServiceController()
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
    public IActionResult CreateService([FromBody] ServiceCreateDto service)
    {
        var result = _serviceLogic.CreateService(service);
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