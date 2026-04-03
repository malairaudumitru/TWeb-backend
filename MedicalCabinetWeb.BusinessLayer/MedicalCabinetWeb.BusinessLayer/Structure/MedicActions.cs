using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicActions
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public MedicSpeciality Speciality { get; set; }
}