using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicLogic
{
    ActionResponse CreateMedic(MedicCreateDto data);
    ActionResponse GetMedicById(int id);
    ActionResponse GetMedicList();
    ActionResponse UpdateMedic(int id, MedicCreateDto data);
    ActionResponse DeleteMedic(int id);

}