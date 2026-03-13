
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.Service;
using MedicalCabinetWeb.Domain.Models.Service;
 
namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class ServiceActions
{
    private readonly ServiceDbContext _context;

    public ServiceActions()
    {
        _context = new ServiceDbContext();
    }

   public bool CreateServiceAction(ServiceCreateDto service)
    {
        var serviceEntity = new ServiceEntity
        {
            Name = service.Name,
            Price = service.Price
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
    
   public ServiceInfoDto? GetServiceByIdAction(int id)
   {
       var serviceEntity = _context.Services.Find(id);
       if(serviceEntity == null)
           return null; 
       
       var serviceInfoDto = new ServiceInfoDto
       {
           Id = serviceEntity.Id,
           Name = serviceEntity.Name,
           Price = serviceEntity.Price
       };
       
       return serviceInfoDto;

   }

   public List<ServiceInfoDto>? GetServiceListAction()
   {
       var productList = _context.Services.Select(serviceEntity => new ServiceInfoDto
       {
           Id = serviceEntity.Id,
           Name = serviceEntity.Name,
           Price = serviceEntity.Price
       })
       .ToList();
       
       return productList;
   }

   public bool DeleteServiceAction(int id)
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