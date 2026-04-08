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
           return new ServiceResponse
           {
               IsSuccess = false, 
               Message = "Error creating Patient"
           };
       return new ServiceResponse
       {
           IsSuccess = true,
           Message = "Patient created successfully"
       };


    }

    public ServiceResponse GetPatientById(int id)
    {
        var patient = GetPatientByIdAction(id);
        if (patient == null)
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Patient not found"
            };
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = patient
        };
    }

    public ServiceResponse GetPatientList()
    {
        var patientList = GetPatientListAction();
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = patientList
        };
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