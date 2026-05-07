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

    protected List<MedicInfoDto> GetMedicListAction()
    {
        var medicList = _context.Medics
            .Where(x => x.IsDeleted == false)
            .Select(medicEntity => new MedicInfoDto
            {
                Id = medicEntity.Id,
                LastName =  medicEntity.LastName,
                FirstName =  medicEntity.FirstName,
                Specialty =  medicEntity.Speciality
            })
            .ToList();
        
        return medicList;
    }

    protected bool UpdateMedicAction(int id, MedicCreateDto medicInfo)
    {
        var medicEntity = _context.Medics.Find(id);
        if(medicEntity == null)
            return false;
        
        if (medicEntity.IsDeleted == true)
            return  false;

        medicEntity.LastName = medicInfo.LastName;
        medicEntity.FirstName = medicInfo.FirstName;
        medicEntity.Speciality = medicInfo.Speciality;

        try
        {
            _context.Medics.Update(medicEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        

    }

    protected bool DeleteMedicAction(int id)
    {
        var medicEntity = _context.Medics.Find(id);
        {
            if (medicEntity == null)
                return false;
        }
        try
        {
            medicEntity.IsDeleted = true;
            _context.Medics.Update(medicEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }



}