using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.DataAccessLayer.Core;
using MedicalCabinetWeb.DataAccessLayer.Interfaces;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    private readonly IServiceRepository _serviceRepository;

    public BusinessLogic()
    {
        _serviceRepository = new ServiceRepository(new ServiceDbContext());
    }

    public IServiceLogic GetServiceLogic()
    {
        return new ServiceLogic(_serviceRepository);
    }
}