using MedicalCabinetWeb.Domain.Entities.MedicalNotification;

namespace MedicalCabinetWeb.Domain.Models.MedicalNotification;

public class MedicalNotificationAdminInfoDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}