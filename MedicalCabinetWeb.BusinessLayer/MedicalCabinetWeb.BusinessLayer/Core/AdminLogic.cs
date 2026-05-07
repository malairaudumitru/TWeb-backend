using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class AdminLogic : AdminActions, IAdminLogic
{
    public ActionResponse CreateAdmin(AdminCreateDto admin)
    {
        var result = CreateAdminAction(admin);
        if (result == false)
            return ActionResponse.BadRequest("Error creating Medic");

        return ActionResponse.Ok("Medic created successfully");

    }

    public ActionResponse GetAdminList()
    {
        var adminList = GetAdminListAction();
        
        return ActionResponse.Ok(data: adminList);
    }

    public ActionResponse GetAdminById(int id)
    {
        var admin = GetAdminByIdAction(id);
        if (admin == null)
            return ActionResponse.NotFound("Admin not found");
        
        return ActionResponse.Ok(data: admin);
    }

    public ActionResponse UpdateAdmin(int id, AdminCreateDto data)
    {
        var result = UpdateAdminAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating  Admin");
        
        return ActionResponse.Ok("Admin updated successfully");
    }

    public ActionResponse DeleteAdmin(int id)
    {
        var result = DeleteAdminAction(id);
            if (result == false)
                return ActionResponse.BadRequest("Error deleting Admin");
            
            return ActionResponse.Ok("Admin deleted successfully");
            
    }
    
}