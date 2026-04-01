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
    
    
    
}