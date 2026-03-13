using MedicalCabinetWeb.Domain.Models.Service;

namespace MedicalCabinetWeb.DataAccessLayer.Interfaces;

public interface IServiceRepository
{
    bool CreateService(ServiceCreateDto service);
    ServiceInfoDto? GetServiceById(int id);
    List<ServiceInfoDto>? GetServiceList();
    bool DeleteService(int id);
}