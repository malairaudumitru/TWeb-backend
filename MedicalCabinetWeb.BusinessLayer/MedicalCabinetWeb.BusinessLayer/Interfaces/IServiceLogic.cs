using MedicalCabinetWeb.Domain.Models.Service;
using MedicalCabinetWeb.Domain.Models.LogicService;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IServiceLogic
{
    LogicServiceResponse CreateService(ServiceCreateDto service);
    LogicServiceResponse GetServiceById(int id);
    LogicServiceResponse GetServiceList();
    LogicServiceResponse DeleteService(int id);

    //In caz daca vrei sa modifici de pe front
    //UpdateProduct
    //DeleteProduct
}