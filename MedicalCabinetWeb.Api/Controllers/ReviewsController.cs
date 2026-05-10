using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewsLogic _reviewsLogic;

    public ReviewsController()
    {
        var bl = new BusinessLogic();
        _reviewsLogic = bl.GetReviewsLogic();
    }

    [HttpPost("create")]
    [Authorize(Roles = "Patient")]
    public IActionResult CreateReview([FromBody] ReviewsCreateDto reviewInfo)
    {
        var result = _reviewsLogic.CreateReview(reviewInfo);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        return Ok(result.Message);
    }
    
    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetReviewById([FromRoute] int id)
    {
        var result = _reviewsLogic.GetReviewById(id);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpGet("list")]
    [AllowAnonymous]
    public IActionResult GetReviewsList()
    {
        var result = _reviewsLogic.GetReviewsList();
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Patient,Admin")]
    public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewsCreateDto reviewInfo)
    {
        var result = _reviewsLogic.UpdateReview(id, reviewInfo);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        return Ok(result.Message);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    public IActionResult DeleteReview([FromRoute] int id)
    {
        var result = _reviewsLogic.DeleteReview(id);
        if (result.IsSuccess == false)
            return StatusCode((int)result.StatusCode, result.Message);
        return Ok(result.Message);
    }
}