using MedicalCabinetWeb.Domain.Models.MedicalService;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicalServiceLogic
{
    ActionResponse GetMedicalServiceList();
    ActionResponse GetMedicalServiceById(int id);
    ActionResponse CreateMedicalService(MedicalServiceCreateDto data);
    ActionResponse UpdateMedicalService(int id, MedicalServiceCreateDto data);
    ActionResponse DeleteMedicalService(int id);

    //In caz daca vrei sa modifici de pe front
    //UpdateProduct
    //DeleteProduct
}