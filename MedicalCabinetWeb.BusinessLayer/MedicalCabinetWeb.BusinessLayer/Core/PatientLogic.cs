using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Patient;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class PatientLogic: PatientActions, IPatientLogic
{
    public ServiceResponse CreatePatient(PatientCreateDto patient)
    {
       var result = CreatePatientAction(patient);
       if(result == false)
           return  ServiceResponse.BadRequest("Error updating Patient");
       
       return ServiceResponse.Ok("Patient created successfully");
       
    }

    public ServiceResponse GetPatientById(int id)
    {
        var patient = GetPatientByIdAction(id);
        if (patient == null)
            return  ServiceResponse.BadRequest("Error getting Patient");
        
        return ServiceResponse.Ok(data: patient);
    }

    public ServiceResponse GetPatientList()
    {
        var patientList = GetPatientListAction();
        
        return ServiceResponse.Ok(data: patientList);
    }

    public ServiceResponse UpdatePatient(int id, PatientCreateDto data)
    {
        var result = UpdatePatientAction(id, data);
        if (result == false)
            return ServiceResponse.BadRequest("Error updating Patient");
        
        return ServiceResponse.Ok("Patient updated successfully");
    }

    public ServiceResponse DeletePatient(int id)
    {
        var result = DeletePatientAction(id);
        if (result == false)
            return ServiceResponse.BadRequest("Error deleting Patient");
        
        return ServiceResponse.Ok("Patient deleted successfully");
    }
    
    
}