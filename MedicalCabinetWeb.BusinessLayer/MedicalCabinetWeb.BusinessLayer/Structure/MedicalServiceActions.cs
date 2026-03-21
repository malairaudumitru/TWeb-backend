
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.MedicalService;
using MedicalCabinetWeb.Domain.Models.MedicalService;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicalServiceActions
{
    private readonly MedicalServiceContext _context;

    public MedicalServiceActions()
    {
        _context = new MedicalServiceContext();
    }

    protected bool CreateMedicalServiceAction(MedicalServiceDto service)
    {
        var validate = ValidateMedicalServiceName(service);
        if (!validate.IsSuccess)
            return false;
        
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
    
    private ActionResponse ValidateMedicalServiceName(MedicalServiceDto data)
    {
        var localData = _context.MedicalServices
            .FirstOrDefault(x => x.ServiceName.ToLower() == data.ServiceName.ToLower());

        if (localData != null)
            return new ActionResponse
            {
                IsSuccess = false,
                Message = "A medical service with the same name already exists."
            };

        return new ActionResponse
        {
            IsSuccess = true,
            Message = "A medical service name is valid."
        };
    }
    
    protected MedicalServiceDto? GetMedicalServiceByIdAction(int id)
    {
        var serviceEntity = _context.MedicalServices
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
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

    protected List<MedicalServiceDto> GetMedicalServiceListAction()
    {
        var productList = _context.MedicalServices
            .Where(x => x.IsDeleted == false)
            .Select(serviceEntity => new MedicalServiceDto
            
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                ServicePrice = serviceEntity.ServicePrice,
                ServiceDescription = serviceEntity.ServiceDescription,
                ServiceDuration = serviceEntity.ServiceDuration,
                
            })
            .ToList();
            
       
        return productList;
    }

    protected bool DeleteMedicalServiceAction(int id)
    {
        var serviceEntity = _context.MedicalServices.Find(id);
        {
            if (serviceEntity == null)
                return false;
        }
        try
        {
            serviceEntity.IsDeleted = true;
            _context.MedicalServices.Update(serviceEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    protected bool UpdateMedicalServiceAction(MedicalServiceDto service)
    {
        var serviceEntity = _context.MedicalServices.Find(service.Id);
        if(serviceEntity == null)
            return false;

        serviceEntity.ServiceName = service.ServiceName;
        serviceEntity.ServicePrice = service.ServicePrice;
        serviceEntity.ServiceDescription = service.ServiceDescription;
        serviceEntity.ServiceDuration = service.ServiceDuration;
        serviceEntity.UpdatedAt = DateTime.Now;

        try
        {
            _context.MedicalServices.Update(serviceEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }


    }
   
}