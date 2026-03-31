using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicalAppointmentLogic
{
    ActionResponse GetMedicalAppointmentList();
    ActionResponse GetMedicalAppointmentById(int id);
    ActionResponse CreateMedicalAppointment(MedicalAppointmentCreateDto data);
    ActionResponse UpdateMedicalAppointment(int id, MedicalAppointmentCreateDto data);
    ActionResponse DeleteMedicalAppointment(int id); 
    ActionResponse GetMedicalAppointmentByDate(DateOnly date);
   // ActionResponse UpdateAppointmentsStatus(int id, AppointmentStatus status);

}