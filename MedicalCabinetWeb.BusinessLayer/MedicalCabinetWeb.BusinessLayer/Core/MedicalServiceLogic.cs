using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.BusinessLayer.Structure;


namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicalServiceLogic: MedicalServiceActions, IMedicalServiceLogic
{
    public ActionResponse CreateMedicalService(MedicalServiceDto service)
    {
        var result = CreateMedicalServiceAction(service);
        if (result == false)
            return ActionResponse.BadRequest("Error creating service");
        
        return ActionResponse.Ok("Service created successfully");

    }

    public ActionResponse DeleteMedicalService(int id)
    {
        var result = DeleteMedicalServiceAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting service");

        return ActionResponse.Ok("Service deleted successfully");
        
    }
    

    public ActionResponse GetMedicalServiceById(int id)
    {
        var service = GetMedicalServiceByIdAction(id);
        if (service == null)
            return ActionResponse.NotFound("Service not found");
        
        return ActionResponse.Ok(data: service);
    }

    public ActionResponse GetMedicalServiceList()
    {
        var serviceList = GetMedicalServiceListAction();
        return ActionResponse.Ok(data: serviceList);
    }
    
    public ActionResponse UpdateMedicalService(MedicalServiceDto data)
    {
        var result = UpdateMedicalServiceAction(data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating service");
        
        return ActionResponse.Ok("Service updated successfully");
    }
    
}