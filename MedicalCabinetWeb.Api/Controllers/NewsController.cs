using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly INewsLogic _newsLogic;

    public NewsController()
    {
        var bl = new BusinessLogic();
        _newsLogic = bl.GetNewsLogic();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetNewsById([FromRoute] int id)
    {
        var result = _newsLogic.GetNewsById(id);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("list")]
    [AllowAnonymous]
    public IActionResult GetNewsList()
    {
        var result = _newsLogic.GetNewsList();
        if (result.IsSuccess == false)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateNews([FromBody] NewsCreateDto news)
    {
        var result = _newsLogic.CreateNews(news);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteNews([FromRoute] int id)
    {
        var result = _newsLogic.DeleteNews(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateNews([FromRoute] int id, [FromBody] NewsCreateDto newsCreateDto)
    {
        var result = _newsLogic.UpdateNews(id, newsCreateDto);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);

        return Ok(result.Message);
    }
}