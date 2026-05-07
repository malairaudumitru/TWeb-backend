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
        return ActionResponse.Ok("Review created successfully");
    }

    public ActionResponse GetReviewById(int id)
    {
        var result = GetReviewByIdAction(id);
        if (result == null)
            return ActionResponse.BadRequest("Review not found");
        return  ActionResponse.Ok("Review found successfully");
    }

    public ActionResponse GetReviewsList()
    {
        var result = GetReviewsListAction();
        if (result == null)
            return ActionResponse.BadRequest("Error getting reviews");
        return  ActionResponse.Ok("Reviews found successfully");
    }

    public ActionResponse UpdateReview(int id, ReviewsCreateDto data)
    {
        var result = UpdateReviewAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating review");
        return ActionResponse.Ok("Review updated successfully");
    }

    public ActionResponse DeleteReview(int id)
    {
        var result = DeleteReviewAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting review");
        return ActionResponse.Ok("Review deleted successfully");
    }
}