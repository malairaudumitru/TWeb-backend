using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using MedicalCabinetWeb.Domain.Models.Patient;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class PatientActions
{
    private readonly UserDbContext _context;

    public PatientActions()
    {
        _context = new UserDbContext();
    }

    public bool CreatePatientAction(PatientCreateDto patient)
    {
        var patientEntity = new Patient
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Email = patient.Email,
            Phone = patient.Phone,
            DateOfBirth = patient.DateOfBirth,
            Sex = patient.Sex,
            Password = patient.Password,
            Status = patient.Status
        };

        try
        {
            _context.Add(patientEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }

    public PatientInfoDto? GetPatientByIdAction(int id)
    {
        var patientEntity = _context.Patients.Find(id);
        if (patientEntity == null)
            return null;

        var patientInfoDto = new PatientInfoDto
        {
            Id = patientEntity.Id,
            LastName = patientEntity.LastName,
            FirstName = patientEntity.FirstName,
            DateOfBirth = patientEntity.DateOfBirth,
            Sex = patientEntity.Sex,
            Email = patientEntity.Email,
            Password = patientEntity.Password,
            Phone = patientEntity.Phone,
            Status = patientEntity.Status

        };

        return patientInfoDto;
    }

    public List<PatientInfoDto> GetPatientListAction()
    {
        var patientList = _context.Patients
             .Where(p => p.IsDeleted == false)
             .Select(patientEntity => new PatientInfoDto()
            {
                Id = patientEntity.Id,
                LastName = patientEntity.LastName,
                FirstName = patientEntity.FirstName,
                DateOfBirth = patientEntity.DateOfBirth,
                Sex = patientEntity.Sex,
                Email = patientEntity.Email,
                Password = patientEntity.Password,
                Phone = patientEntity.Phone,
                Status = patientEntity.Status
            })
            .ToList();
        return patientList;
    }

    protected bool UpdatePatientAction(int id, PatientCreateDto patient)
    {
        var patientEntity = _context.Patients.Find(id);
        if (patientEntity == null)
            return false;

        patientEntity.LastName = patient.LastName;
        patientEntity.FirstName = patient.FirstName;
        patientEntity.DateOfBirth = patient.DateOfBirth;
        patientEntity.Sex = patient.Sex;
        patientEntity.Email = patient.Email;
        patientEntity.Password = patient.Password;
        patientEntity.Phone = patient.Phone;
        patientEntity.Status = patientEntity.Status;

        try
        {
            _context.Patients.Update(patientEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }

    protected bool DeletePatientAction(int id)
    {
        var patientEntity = _context.Patients.Find(id);
        {
            if (patientEntity == null)
                return false;
        }
        try
        {
            patientEntity.IsDeleted = true;
            _context.Patients.Update(patientEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    
}