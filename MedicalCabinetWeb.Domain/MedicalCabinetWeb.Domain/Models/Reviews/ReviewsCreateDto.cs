using MedicalCabinetWeb.Domain.Entities.Reviews;

namespace MedicalCabinetWeb.Domain.Models.Reviews;

public class ReviewsCreateDto
{
    
    public string AuthorName { get; set; } = string.Empty;
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool IsVerifiedPatient { get; set; } = true;
    
}