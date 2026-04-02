namespace MedicalCabinetWeb.Domain.Entities.Reviews;

public class ReviewsEntity
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsVerifiedPatient { get; set; } = true;
}