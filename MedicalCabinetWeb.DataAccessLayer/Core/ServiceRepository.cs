
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.DataAccessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Entities.MedicalService;
using MedicalCabinetWeb.Domain.Models.MedicalService;
 
namespace MedicalCabinetWeb.DataAccessLayer.Core;

public class ServiceRepository : IServiceRepository
{
    private readonly ServiceDbContext _context;

    public ServiceRepository(ServiceDbContext context)
    {
        _context = context;
    }

    public bool CreateService(MedicalServiceDto service)
    {
        var serviceEntity = new MedicalServiceData
        {
            ServiceName = service.ServiceName,
            ServicePrice = service.ServicePrice,
            ServiceDescription = service.ServiceDescription,
            ServiceDuration = service.ServiceDuration
        };
        try
        {
            _context.Add(serviceEntity);
            _context.SaveChanges();
            return true;
        } catch (Exception e)
        {
            return false;
        }
    }
    
    public MedicalServiceDto? GetServiceById(int id)
    {
        var serviceEntity = _context.Services.Find(id);
        if(serviceEntity == null)
            return null; 
       
        var serviceInfoDto = new MedicalServiceDto
        {
            Id = serviceEntity.Id,
            ServiceName = serviceEntity.ServiceName,
            ServicePrice = serviceEntity.ServicePrice,
            ServiceDescription = serviceEntity.ServiceDescription,
            ServiceDuration = serviceEntity.ServiceDuration
        };
       
        return serviceInfoDto;

    }

    public List<MedicalServiceDto>? GetServiceList()
    {
        var productList = _context.Services.Select(serviceEntity => new MedicalServiceDto
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                ServicePrice = serviceEntity.ServicePrice,
                ServiceDescription = serviceEntity.ServiceDescription,
                ServiceDuration = serviceEntity.ServiceDuration
            })
            .ToList();
       
        return productList;
    }

    public bool DeleteService(int id)
    {
        var serviceEntity = _context.Services.Find(id);
        {
            if (serviceEntity == null)
                return false;
        }
        try
        {
            _context.Services.Remove(serviceEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
   
}