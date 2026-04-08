using MedicalCabinetWeb.Domain.Models.Patient;
using MedicalCabinetWeb.Domain.Models.Service;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IPatientLogic
{
    ServiceResponse CreatePatient(PatientCreateDto  patient);
    ServiceResponse GetPatientById(int id);
    ServiceResponse GetPatientList();

}