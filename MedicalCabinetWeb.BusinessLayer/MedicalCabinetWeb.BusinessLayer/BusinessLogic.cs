using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;



namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic(){ }
    
    public IMedicalServiceLogic GetServiceLogic()
    {
        return new MedicalServiceLogic();
    }
    
    public IMedicalAppointmentLogic GetAppointmentLogic()
    {
        return new MedicalAppointmentLogic();
    }

    public IMedicalNotificationLogic GetNotificationLogic()
    {
        return new MedicalNotificationLogic();
    }
    
    
}