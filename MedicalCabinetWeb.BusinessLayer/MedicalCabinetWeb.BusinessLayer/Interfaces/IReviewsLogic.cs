using MedicalCabinetWeb.Domain.Models.Reviews;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IReviewsLogic
{
    ActionResponse CreateReview(ReviewsCreateDto data);
    ActionResponse GetReviewsList();
    ActionResponse GetReviewById(int id);
    ActionResponse UpdateReview(int id, ReviewsCreateDto data);
}