using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.Domain.Models.Medic;

public class MedicInfoDto
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public MedicSpeciality Specialty { get; set; }
}