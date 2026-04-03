using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicLogic
{
    List<Medic> GetALL();
    Medic GetById(int id);
    List<Medic> GetBySpeciality(MedicSpeciality speciality);
    void Create(Medic medic);
    
}