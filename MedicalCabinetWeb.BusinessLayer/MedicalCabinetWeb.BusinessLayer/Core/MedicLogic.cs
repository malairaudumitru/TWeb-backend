using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicLogic: MedicActions, IMedicLogic
{
    public ServiceResponse CreateMedic(MedicCreateDto patient)
    {
        var result = CreateMedicAction(patient);
        if (result == false)
            return ServiceResponse.BadRequest("Error creating Medic");
        
        return ServiceResponse.Ok("Medic created successfully");

    }

    public ServiceResponse GetMedicById(int id)
    {
        var medic = GetMedicByIdAction(id);
        if (medic == null)
            return ServiceResponse.NotFound("Medic not found");
        
        return ServiceResponse.Ok(data: medic);
    }

    public ServiceResponse GetMedicList()
    {
        var medicList = GetMedicListAction();
        
        return ServiceResponse.Ok(data: medicList);
    }

    public ServiceResponse UpdateMedic(int id, MedicCreateDto data)
    {
        var result = UpdateMedicAction(id, data);
        if (result == false)
            return ServiceResponse.BadRequest("Error updating Medic");
        
        return ServiceResponse.Ok("Medic updated successfully");
    }

    public ServiceResponse DeleteMedic(int id)
    {
        var result = DeleteMedicAction(id);
        if (result == false)
            return  ServiceResponse.NotFound("Medic not found");
        
        return ServiceResponse.Ok("Medic deleted successfully");
        
    }
    
}