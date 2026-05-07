using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicLogic: MedicActions, IMedicLogic
{
    public ActionResponse CreateMedic(MedicCreateDto patient)
    {
        var result = CreateMedicAction(patient);
        if (result == false)
            return ActionResponse.BadRequest("Error creating Medic");
        
        return ActionResponse.Ok("Medic created successfully");

    }

    public ActionResponse GetMedicById(int id)
    {
        var medic = GetMedicByIdAction(id);
        if (medic == null)
            return ActionResponse.NotFound("Medic not found");
        
        return ActionResponse.Ok(data: medic);
    }

    public ActionResponse GetMedicList()
    {
        var medicList = GetMedicListAction();
        
        return ActionResponse.Ok(data: medicList);
    }

    public ActionResponse UpdateMedic(int id, MedicCreateDto data)
    {
        var result = UpdateMedicAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating Medic");
        
        return ActionResponse.Ok("Medic updated successfully");
    }

    public ActionResponse DeleteMedic(int id)
    {
        var result = DeleteMedicAction(id);
        if (result == false)
            return  ActionResponse.NotFound("Medic not found");
        
        return ActionResponse.Ok("Medic deleted successfully");
        
    }
    
}