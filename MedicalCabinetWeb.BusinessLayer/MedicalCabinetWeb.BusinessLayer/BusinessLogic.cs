using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic(){}
    
    
    public IPatientLogic GetPatientLogic()
    {
        return new PatientLogic();


    }
    
    
    public IMedicLogic GetMedicLogic()
    {
        return new MedicLogic();
    }
}
