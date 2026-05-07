using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;



namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{

    public BusinessLogic(){}
    
    
    public IPatientLogic GetPatientLogic()
    {
        return new PatientLogic();


    }
    
    
    public IMedicLogic GetMedicLogic()
    {
        return new MedicLogic();
    }

    public IAdminLogic GetAdminLogic()
    {
        return new AdminLogic();
    }
    
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

