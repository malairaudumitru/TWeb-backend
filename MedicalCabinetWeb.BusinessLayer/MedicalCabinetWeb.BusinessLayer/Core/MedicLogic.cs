using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicLogic : MedicActions, IMedicLogic
{
    private readonly UserDbContext _context;

    public MedicLogic(UserDbContext context)
    {
        _context = context;
    }
    
    public List<Medic> GetALL()
    {
        return _context.Medici.ToList();
    }

    public Medic GetById(int id)
    {
        return _context.Medici.FirstOrDefault(m => m.Id == id);
    }
    
    public List<Medic> GetBySpeciality(MedicSpeciality speciality)
    {
        return _context.Medici.Where(m => m.Speciality == speciality).ToList();
    }

    public void Create(Medic medic)
    {
        _context.Medici.Add(medic);
        _context.SaveChanges();
    }

}