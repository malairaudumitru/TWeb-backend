using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface IMedicalAppointmentLogic
{
    // ActionResponse GetMedicalAppointmentsList();
    // ActionResponse GetMedicalAppointmentsById(int id);
    ActionResponse CreateMedicalAppointment(MedicalAppointmentCreateDto data);
    // ActionResponse UpdateMedicalAppointments(int id, MedicalAppointmentCreateDto data);
    // ActionResponse DeleteMedicalAppointments(int id);
    // ActionResponse GetMedicalAppointmentsByDate(DateTime date);
   // ActionResponse UpdateAppointmentsStatus(int id, AppointmentStatus status);

}