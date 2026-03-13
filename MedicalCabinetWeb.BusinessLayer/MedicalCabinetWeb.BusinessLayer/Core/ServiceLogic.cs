using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.Service;
using MedicalCabinetWeb.Domain.Models.LogicService;


namespace MedicalCabinetWeb.BusinessLayer.Core;

public class ServiceLogic: ServiceActions, IServiceLogic
{
    public LogicServiceResponse CreateService(ServiceCreateDto serviceCreateDto)
    {
        var result = CreateServiceAction(serviceCreateDto);
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
        var result =DeleteServiceAction(id);
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
        var service = GetServiceByIdAction(id);
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
        var serviceList = GetServiceListAction();
        return new LogicServiceResponse
        {
            IsSuccess = true,
            Data = serviceList
        };
    }
    
}