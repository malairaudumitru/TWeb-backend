using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicalNotificationLogic : MedicalNotificationActions, IMedicalNotificationLogic
{
    public ActionResponse CreateMedicalNotification(MedicalNotificationCreateDto serviceInfo)
    {
        var result = CreateMedicalNotificationAction(serviceInfo);
        if (result == false)
            return ActionResponse.BadRequest("Error creating notification");
        
        return ActionResponse.Ok("Notification created successfully");

    }
    
    public ActionResponse DeleteMedicalNotification(int id)
    {
        var result = DeleteMedicalNotificationAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting notification");

        return ActionResponse.Ok("Notification deleted successfully");
        
    }
    
    public ActionResponse UpdateReadStatus(int id)
    {
        var result = UpdateReadStatusAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error updating read status");

        return ActionResponse.Ok("Updated successfully");
    }
    
    public ActionResponse MarkAllAsRead(int userId)
    {
        var result = MarkAllAsReadAction(userId);
        if (result == false)
            return ActionResponse.BadRequest("Error marking notifications as read");

        return ActionResponse.Ok("All notifications marked as read");
    }
    
    public ActionResponse GetMedicalNotificationList()
    {
        var notificationList = GetMedicalNotificationListAction();
        
        return ActionResponse.Ok(data: notificationList);
    }
    
}