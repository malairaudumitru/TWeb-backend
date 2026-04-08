using MedicalCabinetWeb.Domain.Models.Medic;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicLogic
{
    ServiceResponse CreateMedic(MedicCreateDto data);
    ServiceResponse GetMedicById(int id);
    ServiceResponse GetMedicList();
    ServiceResponse UpdateMedic(int id, MedicCreateDto data);

}