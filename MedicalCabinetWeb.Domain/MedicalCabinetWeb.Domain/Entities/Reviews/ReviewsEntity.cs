using System.ComponentModel.DataAnnotations;

namespace MedicalCabinetWeb.Domain.Entities.Reviews;

public class ReviewsEntity
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string AuthorName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(400)]
    public string ReviewText { get; set; } = string.Empty;
    
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsVerifiedPatient { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}