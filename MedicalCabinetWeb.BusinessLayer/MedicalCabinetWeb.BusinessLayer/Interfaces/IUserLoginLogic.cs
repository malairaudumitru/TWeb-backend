using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.Domain.Models.User;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IUserLoginLogic
{
   public ActionResponse UserLoginDataValidation(UserLoginDto udata);
   public ActionResponse ResetPassword(string email, string newPassword);
}