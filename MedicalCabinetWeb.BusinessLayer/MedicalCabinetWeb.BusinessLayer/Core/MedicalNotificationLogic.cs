using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicalNotificationLogic : MedicalNotificationActions, IMedicalNotificationLogic
{
    public ActionResponse CreateMedicalNotification(MedicalNotificationCreateDto notificationInfo)
    {
        var result = CreateMedicalNotificationAction(notificationInfo);
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
    
    public ActionResponse GetMedicalNotificationById(int id)
    {
        var result = GetMedicalNotificationByIdAction(id);
        if (result == null)
            return ActionResponse.BadRequest("Notification not found");

        return ActionResponse.Ok(data: result);
    }
    
    public ActionResponse GetMedicalNotificationByUserId(int userId)
    {
        var result = GetMedicalNotificationByUserIdAction(userId);
        if (result == null)
            return ActionResponse.BadRequest("Error getting notifications by user id");

        return ActionResponse.Ok(data: result);
    }
    
}