using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class PatientLogic : PatientActions, IPatientLogic
{
    private readonly UserDbContext _context;

    public PatientLogic(UserDbContext context)
    {
        _context = context;
    }

    public List<Patient> GetAll()
    {
        return _context.Patients.ToList();
    }

    public Patient GetById(int id)
    {
        return _context.Patients.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
    }

    public void Update(int id, Patient patient)
    {
        var existing = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (existing == null) return;

        existing.FirstName = patient.FirstName;
        existing.LastName = patient.LastName;
        existing.DateOfBirth = patient.DateOfBirth;
        existing.Sex = patient.Sex;
        existing.Email = patient.Email;
        existing.Password = patient.Password;
        existing.Phone = patient.Phone;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (patient == null) return;

        _context.Patients.Remove(patient);
        _context.SaveChanges();
    }

    public List<Patient> GetByName(string firstName, string lastName)
    {
        return  _context.Patients.
            Where(p => p.FirstName == firstName && p.LastName == lastName).
            ToList();
    }

    public List<Patient> GetByStatus(PatientStatus status)
    {
        return _context.Patients.Where(p => p.Status == status).ToList();
    }

    public void UpdateStatus(int id, PatientStatus status)
    {
        var existing = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (existing == null) return;
        existing.Status =  status;
        _context.SaveChanges();
    }
}
