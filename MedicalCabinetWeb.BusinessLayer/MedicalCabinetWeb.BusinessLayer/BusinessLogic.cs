using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.DataAccessLayer.Context;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
    private readonly UserDbContext _context;

    public BusinessLogic(UserDbContext context)
    {
        _context = context;
    }
public IPatientLogic GetPatientLogic()
{
    return new PatientLogic(_context);
}
    

    }