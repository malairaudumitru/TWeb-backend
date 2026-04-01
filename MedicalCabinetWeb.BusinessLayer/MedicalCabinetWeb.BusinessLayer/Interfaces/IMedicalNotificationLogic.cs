
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicalNotificationLogic
{
    ActionResponse CreateMedicalNotification(MedicalNotificationCreateDto data);
    ActionResponse DeleteMedicalNotification(int id);
    ActionResponse UpdateReadStatus(int id);
    //ActionResponse MarkAllAsRead(int userId);
    //ActionResponse GetMedicalNotificationList();
    //ActionResponse GetMedicalNotificationById(int id);
    //ActionResponse GetMedicalNotificationByUserId(int userId);
}