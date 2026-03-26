using MedicalCabinetWeb.Domain.Entities.News;

namespace MedicalCabinetWeb.Domain.Models.News;

public class NewsInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
}