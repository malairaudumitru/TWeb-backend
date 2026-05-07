using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Patient;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class PatientLogic: PatientActions, IPatientLogic
{
    public ActionResponse CreatePatient(PatientCreateDto patient)
    {
       var result = CreatePatientAction(patient);
       if(result == false)
           return  ActionResponse.BadRequest("Error updating Patient");
       
       return ActionResponse.Ok("Patient created successfully");
       
    }

    public ActionResponse GetPatientById(int id)
    {
        var patient = GetPatientByIdAction(id);
        if (patient == null)
            return  ActionResponse.BadRequest("Error getting Patient");
        
        return ActionResponse.Ok(data: patient);
    }

    public ActionResponse GetPatientList()
    {
        var patientList = GetPatientListAction();
        
        return ActionResponse.Ok(data: patientList);
    }

    public ActionResponse UpdatePatient(int id, PatientCreateDto data)
    {
        var result = UpdatePatientAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating Patient");
        
        return ActionResponse.Ok("Patient updated successfully");
    }

    public ActionResponse DeletePatient(int id)
    {
        var result = DeletePatientAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting Patient");
        
        return ActionResponse.Ok("Patient deleted successfully");
    }
    
    
}