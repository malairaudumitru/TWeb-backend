using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.Domain.Models.User;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class UserAuthActions : UserActions, IUserLoginLogic
{
    public UserAuthActions() { }
    
    public ActionResponse UserLoginDataValidation(UserLoginDto udata)
    {
        var user = UserLoginDataValidationExecution(udata);

        if (user == null)
        {
            return ActionResponse.BadRequest("Email sau parola incorecta.");
        }

        var token = UserTokenGeneration(user);

        return ActionResponse.Ok(token);
    }
    
    public ActionResponse ResetPassword(string email, string newPassword)
    {
        return ResetPasswordAction(email, newPassword);
    }
    
}