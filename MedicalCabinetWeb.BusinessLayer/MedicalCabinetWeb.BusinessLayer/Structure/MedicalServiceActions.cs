
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.MedicalService;
using MedicalCabinetWeb.Domain.Models.MedicalService;
 
namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicalServiceActions
{
    private readonly MedicalServiceContext _context;

    public MedicalServiceActions()
    {
        _context = new MedicalServiceContext();
    }

    public bool CreateMedicalServiceAction(MedicalServiceDto service)
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
    
    public MedicalServiceDto? GetMedicalServiceByIdAction(int id)
    {
        var serviceEntity = _context.MedicalServices.Find(id);
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

    public List<MedicalServiceDto>? GetMedicalServiceListAction()
    {
        var productList = _context.MedicalServices.Select(serviceEntity => new MedicalServiceDto
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

    public bool DeleteMedicalServiceAction(int id)
    {
        var serviceEntity = _context.MedicalServices.Find(id);
        {
            if (serviceEntity == null)
                return false;
        }
        try
        {
            _context.MedicalServices.Remove(serviceEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public bool UpdateMedicalServiceAction(MedicalServiceDto service)
    {
        throw new NotImplementedException();
    }
   
}