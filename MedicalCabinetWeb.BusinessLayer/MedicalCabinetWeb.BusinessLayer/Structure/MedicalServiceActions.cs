
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

    protected bool CreateMedicalServiceAction(MedicalServiceCreateDto serviceInfo)
    {
        var validate = ValidateMedicalServiceName(serviceInfo);
        if (!validate.IsSuccess)
            return false;
        
        var serviceEntity = new MedicalServiceData
        {
            ServiceName = serviceInfo.ServiceName,
            ServicePrice = serviceInfo.ServicePrice,
            ServiceDescription = serviceInfo.ServiceDescription,
            ServiceDuration = serviceInfo.ServiceDuration
        };
        try
        {
            _context.Add(serviceEntity);
            _context.SaveChanges();
            return true;
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    
    private ActionResponse ValidateMedicalServiceName(MedicalServiceCreateDto data)
    {
        
        if (string.IsNullOrEmpty(data.ServiceName))
            return new ActionResponse { IsSuccess = false, Message = "ServiceName is empty" };

        var localData = _context.MedicalServices
            .FirstOrDefault(x => x.ServiceName != null && 
                                 x.ServiceName.ToLower() == data.ServiceName.ToLower() && 
                                 x.IsDeleted == false);

        if (localData != null)
            return new ActionResponse { IsSuccess = false, Message = "Already exists" };

        return new ActionResponse { IsSuccess = true };
    }
    
    protected MedicalServiceInfoDto? GetMedicalServiceByIdAction(int id)
    {
        var serviceEntity = _context.MedicalServices
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if(serviceEntity == null)
            return null; 
       
        var serviceInfoDto = new MedicalServiceInfoDto
        {
            Id = serviceEntity.Id,
            ServiceName = serviceEntity.ServiceName,
            ServicePrice = serviceEntity.ServicePrice,
            ServiceDescription = serviceEntity.ServiceDescription,
            ServiceDuration = serviceEntity.ServiceDuration
        };
       
        return serviceInfoDto;

    }

    protected List<MedicalServiceInfoDto> GetMedicalServiceListAction()
    {
        var productList = _context.MedicalServices
            .Where(x => x.IsDeleted == false)
            .Select(serviceEntity => new MedicalServiceInfoDto
            
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
    
    protected bool UpdateMedicalServiceAction(int id, MedicalServiceInfoDto serviceInfo)
    {
        var serviceEntity = _context.MedicalServices.Find(id);
        if(serviceEntity == null)
            return false;

        serviceEntity.ServiceName = serviceInfo.ServiceName;
        serviceEntity.ServicePrice = serviceInfo.ServicePrice;
        serviceEntity.ServiceDescription = serviceInfo.ServiceDescription;
        serviceEntity.ServiceDuration = serviceInfo.ServiceDuration;
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