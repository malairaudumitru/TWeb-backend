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
    
}