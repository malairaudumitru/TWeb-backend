using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic(){}
    
    //PatientLogic
    public IPatientLogic GetPatientLogic()
    {
        return new PatientLogic();


    }
    
    //MedicLogic
    public IMedicLogic GetMedicLogic()
    {
        return new MedicLogic();
    }
}
