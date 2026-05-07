using System.ComponentModel.DataAnnotations;

namespace MedicalCabinetWeb.Domain.Entities.User;

public class UserAccount
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;

    public Patient? Patient { get; set; }
    public Medic?   Medic   { get; set; }
    public Admin?   Admin   { get; set; }
}