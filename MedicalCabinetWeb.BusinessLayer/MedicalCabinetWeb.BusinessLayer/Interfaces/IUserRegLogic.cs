using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.Domain.Models.User;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IUserRegLogic
{ 
    public ActionResponse UserRegDataValidation(UserRegisterDto uReg);
}