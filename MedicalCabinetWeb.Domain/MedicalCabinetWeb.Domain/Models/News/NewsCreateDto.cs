using MedicalCabinetWeb.Domain.Entities.News;

namespace MedicalCabinetWeb.Domain.Models.News;

public class NewsCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
}