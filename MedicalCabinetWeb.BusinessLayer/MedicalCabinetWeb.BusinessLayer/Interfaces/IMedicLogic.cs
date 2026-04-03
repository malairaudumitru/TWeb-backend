using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicLogic
{
    List<Medic> GetALL();
    List<Medic> GetBySpeciality(MedicSpeciality speciality);
    void Create(Medic medic);
}