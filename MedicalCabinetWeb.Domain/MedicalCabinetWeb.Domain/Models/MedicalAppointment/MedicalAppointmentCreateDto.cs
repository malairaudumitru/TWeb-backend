namespace MedicalCabinetWeb.Domain.Models.MedicalAppointment;

public class MedicalAppointmentCreateDto
{
    public string PatientName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string DoctorName { get; set; }
    public string ServiceName { get; set; }
    public string ReasonForVisit { get; set; }
    public TimeOnly AppointmentTime { get; set; } 
    public DateOnly AppointmentDate { get; set; }
}