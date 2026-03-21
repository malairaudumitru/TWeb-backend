namespace MedicalCabinetWeb.Domain.Models.MedicalService;

public class MedicalServiceDto
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }
    public string ServiceDescription { get; set; }
    public int ServiceDuration { get; set; }
}