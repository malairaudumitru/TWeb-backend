using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.Responses;


namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicalAppointmentActions
{
    private readonly MedicalAppointmentContext _context;
    
    public MedicalAppointmentActions()
    {
        _context = new MedicalAppointmentContext();
    }

    protected bool CreateMedicalAppointmentAction(MedicalAppointmentCreateDto appointmentInfo)
    {
        var validate = ValidateMedicalAppointmentsName(appointmentInfo);
        if(!validate.IsSuccess)
            return false;

        var appointmentEntity = new MedicalAppointmentData
        {
            PatientName = appointmentInfo.PatientName,
            Phone = appointmentInfo.Phone,
            Email = appointmentInfo.Email,
            DoctorName = appointmentInfo.DoctorName,
            ServiceName = appointmentInfo.ServiceName,
            ReasonForVisit = appointmentInfo.ReasonForVisit,
            AppointmentTime = appointmentInfo.AppointmentTime,
            AppointmentDate = appointmentInfo.AppointmentDate,
        };
        try
        {
            _context.Add(appointmentEntity);
            _context.SaveChanges();
            return true;
        } 
        catch (Exception e)
        {
            return false;
        }
    }
    
    private ActionResponse ValidateMedicalAppointmentsName(MedicalAppointmentCreateDto data)
    {
        
        if (string.IsNullOrEmpty(data.PatientName))
            return new ActionResponse { IsSuccess = false, Message = "PatientName is empty" };

        if (string.IsNullOrEmpty(data.Phone))
            return new ActionResponse { IsSuccess = false, Message = "Phone is empty" };

        if (string.IsNullOrEmpty(data.DoctorName))
            return new ActionResponse { IsSuccess = false, Message = "DoctorName is empty" };

        if (string.IsNullOrEmpty(data.ServiceName))
            return new ActionResponse { IsSuccess = false, Message = "ServiceName is empty" };

        if (data.AppointmentDate == default)
            return new ActionResponse { IsSuccess = false, Message = "AppointmentDate is empty" };

        if (data.AppointmentDate < DateOnly.FromDateTime(DateTime.Today))
            return new ActionResponse { IsSuccess = false, Message = "AppointmentDate cannot be in the past" };

        return new ActionResponse { IsSuccess = true };
    }
    
    protected bool DeleteMedicalAppointmentAction(int id)
    {
        var appointmentEntity = _context.MedicalAppointments.Find(id);
        {
            if (appointmentEntity == null)
                return false;
        }
        try
        {
            appointmentEntity.IsDeleted = true;
            _context.MedicalAppointments.Update(appointmentEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    
    protected List<MedicalAppointmentInfoDto> GetMedicalAppointmentListAction()
    {
        var appointmentList = _context.MedicalAppointments
            .Where(x => x.IsDeleted == false)
            .Select(appointmentEntity => new MedicalAppointmentInfoDto
            
            {
                Id = appointmentEntity.Id,
                PatientName = appointmentEntity.PatientName,
                Phone = appointmentEntity.Phone,
                Email = appointmentEntity.Email,
                DoctorName = appointmentEntity.DoctorName,
                ServiceName = appointmentEntity.ServiceName,
                ReasonForVisit = appointmentEntity.ReasonForVisit,
                AppointmentTime = appointmentEntity.AppointmentTime,
                AppointmentDate = appointmentEntity.AppointmentDate,
                Status = appointmentEntity.Status
                
            })
            .ToList();
            
       
        return appointmentList;
    }
    
    protected MedicalAppointmentInfoDto? GetMedicalAppointmentByIdAction(int id)
    {
        var appointmentEntity = _context.MedicalAppointments
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if(appointmentEntity == null)
            return null; 
       
        var appointmentInfoDto = new MedicalAppointmentInfoDto
        {
            Id = appointmentEntity.Id,
            PatientName = appointmentEntity.PatientName,
            Phone = appointmentEntity.Phone,
            Email = appointmentEntity.Email,
            DoctorName = appointmentEntity.DoctorName,
            ServiceName = appointmentEntity.ServiceName,
            ReasonForVisit = appointmentEntity.ReasonForVisit,
            AppointmentTime = appointmentEntity.AppointmentTime,
            AppointmentDate = appointmentEntity.AppointmentDate,
            Status = appointmentEntity.Status
        };
       
        return appointmentInfoDto;

    }
    
    protected List<MedicalAppointmentInfoDto>? GetMedicalAppointmentByDateAction(DateOnly date)
    {
        var appointmentEntities = _context.MedicalAppointments
            .Where(x => x.AppointmentDate == date && x.IsDeleted == false)
            .ToList();
        if (appointmentEntities.Count == 0)
            return null;

        var appointmentInfoDtos = appointmentEntities
            .Select(appointmentEntity => new MedicalAppointmentInfoDto
            {
                Id = appointmentEntity.Id,
                PatientName = appointmentEntity.PatientName,
                Phone = appointmentEntity.Phone,
                Email = appointmentEntity.Email,
                DoctorName = appointmentEntity.DoctorName,
                ServiceName = appointmentEntity.ServiceName,
                ReasonForVisit = appointmentEntity.ReasonForVisit,
                AppointmentTime = appointmentEntity.AppointmentTime,
                AppointmentDate = appointmentEntity.AppointmentDate,
                Status = appointmentEntity.Status
            }).ToList();

        return appointmentInfoDtos;
    }
    
    protected bool UpdateMedicalAppointmentAction(int id, MedicalAppointmentCreateDto appointmentInfo)
    {
        var appointmentEntity = _context.MedicalAppointments.Find(id);
        if(appointmentEntity == null)
            return false;
        
        if (appointmentEntity.IsDeleted == true)
            return false;

        appointmentEntity.PatientName = appointmentInfo.PatientName;
        appointmentEntity.Phone = appointmentInfo.Phone;
        appointmentEntity.Email = appointmentInfo.Email;
        appointmentEntity.DoctorName = appointmentInfo.DoctorName;
        appointmentEntity.ServiceName = appointmentInfo.ServiceName;
        appointmentEntity.ReasonForVisit = appointmentInfo.ReasonForVisit;
        appointmentEntity.AppointmentTime = appointmentInfo.AppointmentTime;
        appointmentEntity.AppointmentDate = appointmentInfo.AppointmentDate;
        appointmentEntity.UpdatedAt = DateTime.UtcNow;

        try
        {
            _context.MedicalAppointments.Update(appointmentEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }


    }
    
    protected string? UpdateAppointmentStatusAction(int id, AppointmentStatus status)
    {
        if (!Enum.IsDefined(typeof(AppointmentStatus), status))
            return "Invalid status value";

        var appointmentEntity = _context.MedicalAppointments
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

        if (appointmentEntity == null)
            return "Appointment not found";

        appointmentEntity.Status = status;
        appointmentEntity.UpdatedAt = DateTime.UtcNow;

        try
        {
            _context.MedicalAppointments.Update(appointmentEntity);
            _context.SaveChanges();
            return null;
        }
        catch (Exception e)
        {
            return "Error updating status";
        }
    }
    
}