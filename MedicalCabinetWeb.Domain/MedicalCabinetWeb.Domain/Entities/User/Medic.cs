using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCabinetWeb.Domain.Entities.User;

public class Medic
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public MedicSpeciality Speciality { get; set; }
    public bool IsDeleted { get; set; }
    
    [Required]
    public int UserAccountId { get; set; }

    [ForeignKey(nameof(UserAccountId))]
    public UserAccount UserAccount { get; set; } = null!;
}

