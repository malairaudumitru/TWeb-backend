namespace MedicalCabinetWeb.Domain.Models.MedicalAppointment;

public class MedicalAppointmentsCreateDto
{
    public string PatientName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string DoctorName { get; set; }
    public string ServiceName { get; set; }
    public string ReasonForVisit { get; set; }
    public string AppointmentTime { get; set; } 
    public DateTime AppointmentDate { get; set; }
}