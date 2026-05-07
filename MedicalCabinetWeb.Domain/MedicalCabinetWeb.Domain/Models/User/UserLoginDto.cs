using System.ComponentModel.DataAnnotations;

namespace MedicalCabinetWeb.Domain.Models.User;

public class UserLoginDto
{
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}