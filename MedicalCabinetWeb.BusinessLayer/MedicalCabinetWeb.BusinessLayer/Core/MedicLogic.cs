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
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Error creating Medic"
            };
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Medic created successfully"
        };

    }

    public ServiceResponse GetMedicById(int id)
    {
        var medic = GetMedicByIdAction(id);
        if (medic == null)
            return ServiceResponse.NotFound("Medic not found");
        
        return ServiceResponse.Ok(data: medic);
    }
}