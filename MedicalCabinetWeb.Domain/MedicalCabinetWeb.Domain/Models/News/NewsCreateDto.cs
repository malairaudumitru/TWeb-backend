using System.ComponentModel.DataAnnotations;
using MedicalCabinetWeb.Domain.Entities.News;

namespace MedicalCabinetWeb.Domain.Models.News;

public class NewsCreateDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(400)]
    public string Description { get; set; } = string.Empty;
    
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
}