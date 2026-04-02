namespace MedicalCabinetWeb.Domain.Models.Admin;

public class AdminCreateDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}