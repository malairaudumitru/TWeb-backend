using MedicalCabinetWeb.Domain.Entities.MedicalNotification;

namespace MedicalCabinetWeb.Domain.Models.MedicalNotification;

public class MedicalNotificationCreateDto
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
}