namespace MedicalCabinetWeb.Domain.Entities.User;

public class Medic
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Specialty { get; set; }
}