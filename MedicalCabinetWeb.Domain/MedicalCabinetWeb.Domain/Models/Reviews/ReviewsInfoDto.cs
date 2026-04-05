namespace MedicalCabinetWeb.Domain.Models.Reviews;

public class ReviewsInfoDto
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVerifiedPatient { get; set; }
}