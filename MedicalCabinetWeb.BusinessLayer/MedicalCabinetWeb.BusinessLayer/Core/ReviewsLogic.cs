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
        return result == false
            ? ActionResponse.BadRequest("Error creating review")
            : ActionResponse.Ok(message: "Review created successfully");
    }

    public ActionResponse GetReviewById(int id)
    {
        var review = GetReviewByIdAction(id);
        return review == null
            ? ActionResponse.BadRequest("Review not found")
            : new ActionResponse { IsSuccess = true, Message = "Success", Data = review };
    }

    public ActionResponse GetReviewsList()
    {
        var list = GetReviewsListAction();
        return new ActionResponse { IsSuccess = true, Message = "Success", Data = list };
    }

    public ActionResponse UpdateReview(int id, ReviewsCreateDto data)
    {
        var result = UpdateReviewAction(id, data);
        return result == false
            ? ActionResponse.BadRequest("Error updating review")
            : ActionResponse.Ok(message: "Review updated successfully");
    }
}