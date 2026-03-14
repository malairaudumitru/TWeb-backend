namespace MedicalCabinetWeb.Domain.Models.Service;

public class ServiceInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
}