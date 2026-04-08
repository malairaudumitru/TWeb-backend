using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using MedicalCabinetWeb.Domain.Models.Medic;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicActions
{
    private readonly UserDbContext _context;

    public MedicActions()
    {
        _context = new UserDbContext();
    }

    protected bool CreateMedicAction(MedicCreateDto medic)
    {
        var medicEntity = new Medic
        {
            LastName = medic.LastName,
            FirstName = medic.FirstName,
            Speciality = medic.Speciality
        };
        try
        {
            _context.Add(medicEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected MedicInfoDto? GetMedicByIdAction(int id)
    {
        var medicEntity = _context.Medics.Find(id);
        if (medicEntity == null)
            return null;

        var medicInfoDto = new MedicInfoDto
        {
            Id = medicEntity.Id,
            LastName = medicEntity.LastName,
            FirstName = medicEntity.FirstName,
            Specialty = medicEntity.Speciality
        };
        return medicInfoDto;
    }




}