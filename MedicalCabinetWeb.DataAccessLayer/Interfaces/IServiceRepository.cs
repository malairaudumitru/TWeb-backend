using MedicalCabinetWeb.Domain.Models.MedicalService;


namespace MedicalCabinetWeb.DataAccessLayer.Interfaces;

public interface IServiceRepository
{
    bool CreateService(MedicalServiceDto service);
    MedicalServiceDto? GetServiceById(int id);
    List<MedicalServiceDto>? GetServiceList();
    bool DeleteService(int id);
}