using System.ComponentModel.DataAnnotations;

namespace MedicalCabinetWeb.Domain.Models.User;

public class UserRegisterDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }

    [Required]
    [Phone]
    [StringLength(15)]
    public string Phone { get; set; }

    [Required]
    [StringLength(10)]
    public string Sex { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }
}