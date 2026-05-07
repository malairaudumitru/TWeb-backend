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
    

        public INewsLogic GetNewsLogic()
        {
            return new NewsLogic();
        }
        
    public IReviewsLogic GetReviewsLogic()
    {
        return new ReviewsLogic();
    }   
    
    public IUserLoginLogic GetUserLoginLogic()
    {
        return new UserAuthActions();
    }
    
    public IUserRegLogic GetUserRegLogic()
    {
        return new UserRegLogic();
    }
    
}

