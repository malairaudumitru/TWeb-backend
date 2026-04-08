using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.Domain.Models.Medic;

public class MedicCreateDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public MedicSpeciality Speciality { get; set; }
}