using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class AdminLogic : AdminActions, IAdminLogic
{
    public ServiceResponse CreateAdmin(AdminCreateDto admin)
    {
        var result = CreateAdminAction(admin);
        if (result == false)
            return ServiceResponse.BadRequest("Error creating Medic");

        return ServiceResponse.Ok("Medic created successfully");

    }

    public ServiceResponse GetAdminList()
    {
        var adminList = GetAdminListAction();
        
        return ServiceResponse.Ok(data: adminList);
    }

    public ServiceResponse GetAdminById(int id)
    {
        var admin = GetAdminByIdAction(id);
        if (admin == null)
            return ServiceResponse.NotFound("Admin not found");
        
        return ServiceResponse.Ok(data: admin);
    }

    public ServiceResponse UpdateAdmin(int id, AdminCreateDto data)
    {
        var result = UpdateAdminAction(id, data);
        if (result == false)
            return ServiceResponse.BadRequest("Error updating  Admin");
        
        return ServiceResponse.Ok("Admin updated successfully");
    }

    public ServiceResponse DeleteAdmin(int id)
    {
        var result = DeleteAdminAction(id);
            if (result == false)
                return ServiceResponse.BadRequest("Error deleting Admin");
            
            return ServiceResponse.Ok("Admin deleted successfully");
            
    }
    
}