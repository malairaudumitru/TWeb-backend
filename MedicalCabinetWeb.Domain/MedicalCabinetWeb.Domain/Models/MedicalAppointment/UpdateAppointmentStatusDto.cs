using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;

namespace MedicalCabinetWeb.Domain.Models.MedicalAppointment;

public class UpdateAppointmentStatusDto
{
    public AppointmentStatus Status { get; set; }
}