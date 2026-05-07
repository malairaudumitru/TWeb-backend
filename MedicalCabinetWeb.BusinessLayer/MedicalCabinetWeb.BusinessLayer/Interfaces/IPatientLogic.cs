using MedicalCabinetWeb.Domain.Models.Patient;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IPatientLogic
{
    ActionResponse CreatePatient(PatientCreateDto  data);
    ActionResponse GetPatientById(int id);
    ActionResponse GetPatientList();
    ActionResponse UpdatePatient(int id, PatientCreateDto data);
    ActionResponse DeletePatient(int id);
    
    
}