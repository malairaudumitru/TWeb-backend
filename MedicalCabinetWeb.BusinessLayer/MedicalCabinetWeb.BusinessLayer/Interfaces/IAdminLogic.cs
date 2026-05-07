using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IAdminLogic
{
    ActionResponse CreateAdmin(AdminCreateDto data);
    ActionResponse GetAdminList();
    ActionResponse GetAdminById(int id);
    ActionResponse UpdateAdmin (int id, AdminCreateDto data);
    ActionResponse DeleteAdmin(int id);
    
   
    
    
    
}
    