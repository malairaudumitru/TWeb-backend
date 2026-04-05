using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Reviews;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class ReviewsLogic : ReviewsAction, IReviewsLogic
{
    public ActionResponse CreateReview(ReviewsCreateDto data)
    {
        var result = CreateReviewAction(data);
        if (result == false)
            return ActionResponse.BadRequest("Error creating review");
        return ActionResponse.Ok(message: "Review created successfully");
    }
}
