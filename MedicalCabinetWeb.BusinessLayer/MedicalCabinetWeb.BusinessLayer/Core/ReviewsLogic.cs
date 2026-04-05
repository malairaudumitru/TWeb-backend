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

    public ActionResponse GetReviewById(int id)
    {
        var review = GetReviewByIdAction(id);
        if (review == null)
            return ActionResponse.BadRequest("Review not found");
        return new ActionResponse { IsSuccess = true, Message = "Success", Data = review };
    }

    public ActionResponse GetReviewsList()
    {
        var list = GetReviewsListAction();
        if (list == null)
            return ActionResponse.BadRequest("Error getting reviews");
        return new ActionResponse { IsSuccess = true, Message = "Success", Data = list };
    }

    public ActionResponse UpdateReview(int id, ReviewsCreateDto data)
    {
        var result = UpdateReviewAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating review");
        return ActionResponse.Ok(message: "Review updated successfully");
    }

    public ActionResponse DeleteReview(int id)
    {
        var result = DeleteReviewAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting review");
        return ActionResponse.Ok(message: "Review deleted successfully");
    }
}