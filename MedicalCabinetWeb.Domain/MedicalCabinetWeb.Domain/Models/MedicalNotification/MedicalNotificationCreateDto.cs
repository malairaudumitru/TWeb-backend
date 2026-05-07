using System.ComponentModel.DataAnnotations;
using MedicalCabinetWeb.Domain.Entities.MedicalNotification;

namespace MedicalCabinetWeb.Domain.Models.MedicalNotification;

public class MedicalNotificationCreateDto
{
    public int UserId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(400)]
    public string Message { get; set; }
}