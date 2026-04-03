using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicLogic
{
    List<Medic> GetAll();
    Medic GetById(int id);
    List<Medic> GetBySpeciality(MedicSpeciality speciality);
    void Create(Medic medic);
    List<Medic> GetByName(string firstName, string lastName);
    
    
}