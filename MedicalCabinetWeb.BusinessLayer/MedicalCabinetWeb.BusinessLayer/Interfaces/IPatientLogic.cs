using MedicalCabinetWeb.Domain.Models.Patient;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IPatientLogic
{
    ServiceResponse CreatePatient(PatientCreateDto  data);
    ServiceResponse GetPatientById(int id);
    ServiceResponse GetPatientList();
    ServiceResponse UpdatePatient(int id, PatientCreateDto data);
    ServiceResponse DeletePatient(int id);
    
    
}