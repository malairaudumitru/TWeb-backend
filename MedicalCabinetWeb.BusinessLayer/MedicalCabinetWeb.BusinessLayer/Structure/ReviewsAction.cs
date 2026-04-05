using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.Reviews;
using MedicalCabinetWeb.Domain.Models.Reviews;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class ReviewsAction
{
    private readonly ReviewsDbContext _context = new ReviewsDbContext();

    protected bool CreateReviewAction(ReviewsCreateDto reviewInfo)
    {
        var validate = ValidateReview(reviewInfo);
        if (!validate.IsSuccess)
            return false;

        var reviewEntity = new ReviewsEntity
        {
            AuthorName = reviewInfo.AuthorName,
            ReviewText = reviewInfo.ReviewText,
            Rating = reviewInfo.Rating,
            IsVerifiedPatient = reviewInfo.IsVerifiedPatient
        };

        try
        {
            _context.Add(reviewEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    private ActionResponse ValidateReview(ReviewsCreateDto data)
    {
        if (string.IsNullOrEmpty(data.AuthorName))
            return new ActionResponse { IsSuccess = false, Message = "AuthorName is empty" };
        if (string.IsNullOrEmpty(data.ReviewText))
            return new ActionResponse { IsSuccess = false, Message = "ReviewText is empty" };
        if (data.Rating < 1 || data.Rating > 5)
            return new ActionResponse { IsSuccess = false, Message = "Rating must be between 1 and 5" };

        return new ActionResponse { IsSuccess = true };
    }
    
    protected ReviewsEntity? GetReviewByIdAction(int id)
    {
        return _context.Reviews.Find(id);
    }

    protected List<ReviewsEntity> GetReviewsListAction()
    {
        return _context.Reviews.ToList();
    }

    protected bool UpdateReviewAction(int id, ReviewsCreateDto reviewInfo)
    {
        var reviewEntity = _context.Reviews.Find(id);
        if (reviewEntity == null) return false;
        if (reviewEntity.IsDeleted == true) return false;

        reviewEntity.AuthorName = reviewInfo.AuthorName;
        reviewEntity.ReviewText = reviewInfo.ReviewText;
        reviewEntity.Rating = reviewInfo.Rating;
        reviewEntity.IsVerifiedPatient = reviewInfo.IsVerifiedPatient;

        try
        {
            _context.Reviews.Update(reviewEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}  