using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.Domain.Models.User;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class UserRegLogic : UserActions, IUserRegLogic
{
    public ActionResponse UserRegDataValidation(UserRegisterDto uReg)
    {
        return UserRegDataValidationAction(uReg);
    }
    
    public ActionResponse PromoteToMedic(int userId, string speciality)
    {
        return PromoteToMedicAction(userId, speciality);
    }

    public ActionResponse PromoteToAdmin(int userId)
    {
        return PromoteToAdminAction(userId);
    }
    
}