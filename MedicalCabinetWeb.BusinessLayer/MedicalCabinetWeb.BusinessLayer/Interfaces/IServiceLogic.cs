using MedicalCabinetWeb.Domain.Models.MedicalService;
using MedicalCabinetWeb.Domain.Models.LogicService;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IServiceLogic
{
    LogicServiceResponse CreateService(MedicalServiceDto service);
    LogicServiceResponse GetServiceById(int id);
    LogicServiceResponse GetServiceList();
    LogicServiceResponse DeleteService(int id);

    //In caz daca vrei sa modifici de pe front
    //UpdateProduct
    //DeleteProduct
}