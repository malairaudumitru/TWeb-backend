using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic() { }

    public IServiceLogic GetServiceLogic()
    {
        return new ServiceLogic();
    }
}