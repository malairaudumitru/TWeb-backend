using MedicalCabinetWeb.Domain.Entities.MedicalService;

namespace MedicalCabinetWeb.Domain.Models.MedicalService;

public class MedicalServiceCreateDto
{
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }
    public string ServiceDescription { get; set; }
    public int ServiceDuration { get; set; }
    
    public ServiceCategory Category { get; set; }
}