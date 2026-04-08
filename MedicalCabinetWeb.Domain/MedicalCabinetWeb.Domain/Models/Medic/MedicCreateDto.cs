using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.Domain.Models.Medic;

public class MedicCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public MedicSpeciality Speciality { get; set; }
}