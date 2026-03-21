using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.DataAccessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using MedicalCabinetWeb.Domain.Models.LogicService;


namespace MedicalCabinetWeb.BusinessLayer.Core;

public class ServiceLogic: IServiceLogic
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceLogic(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public LogicServiceResponse CreateService(MedicalServiceDto serviceCreateDto)
    {
        var result = _serviceRepository.CreateService(serviceCreateDto);
        if (result == false)
            return new LogicServiceResponse
            {
                IsSuccess = false,
                Message = "Error creating service"
            };
        
        return new LogicServiceResponse
        {
            IsSuccess = true,
            Message = "Service created successfully"
        };
    }

    public LogicServiceResponse DeleteService(int id)
    {
        var result = _serviceRepository.DeleteService(id);
        if (result == false)
            return new LogicServiceResponse
            {
                IsSuccess = false,
                Message = "Error delete service"
            };

        return new LogicServiceResponse
        {
            IsSuccess = true,
            Message = "Service delete successfully"
        };
        
    }
    

    public LogicServiceResponse GetServiceById(int id)
    {
        var service = _serviceRepository.GetServiceById(id);
        if (service == null)
            return LogicServiceResponse.NotFound("Service not found");


        return new LogicServiceResponse
        {
            IsSuccess = true,
            Data = service
        };
    }

    public LogicServiceResponse GetServiceList()
    {
        var serviceList = _serviceRepository.GetServiceList();
        return new LogicServiceResponse
        {
            IsSuccess = true,
            Data = serviceList
        };
    }
    
}