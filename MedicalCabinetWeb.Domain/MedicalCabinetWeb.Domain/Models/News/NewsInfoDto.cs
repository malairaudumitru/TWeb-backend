using System.ComponentModel.DataAnnotations;
using MedicalCabinetWeb.Domain.Entities.News;

namespace MedicalCabinetWeb.Domain.Models.News;

public class NewsInfoDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(400)]
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
}