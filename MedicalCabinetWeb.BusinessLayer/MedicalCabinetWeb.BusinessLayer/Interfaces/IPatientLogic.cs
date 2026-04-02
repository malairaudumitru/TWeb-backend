using MedicalCabinetWeb.Domain.Entities.User;
    
namespace MedicalCabinetWeb.BusinessLayer.Interfaces;



public interface IPatientLogic
{
    List<Patient> GetAll();
    Patient GetById(int id);
    void Create(Patient patient);
    void Update(int id, Patient patient);
    void Delete(int id);
    List<Patient> GetByName(string firstName, string lastName);
    
}