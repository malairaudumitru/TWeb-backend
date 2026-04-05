using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Reviews;
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
    public IActionResult CreateReview([FromBody] ReviewsCreateDto reviewInfo)
    {
        var result = _reviewsLogic.CreateReview(reviewInfo);
        if (result.IsSuccess == false)
            return BadRequest(result.Message);
        return Ok(result.Message);
    }
    
}