using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IAdminLogic
{
    ServiceResponse CreateAdmin(AdminCreateDto data);
    ServiceResponse GetAdminList();
    ServiceResponse GetAdminById(int id);
   
    
    
    
}
    