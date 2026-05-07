using System.ComponentModel.DataAnnotations;
using MedicalCabinetWeb.Domain.Entities.Reviews;

namespace MedicalCabinetWeb.Domain.Models.Reviews;

public class ReviewsCreateDto
{
    [Required]
    [StringLength(50)]
    public string AuthorName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(400)]
    public string ReviewText { get; set; } = string.Empty;
    
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    public bool IsVerifiedPatient { get; set; } = true;
    
}