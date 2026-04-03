using System.ComponentModel.DataAnnotations;
using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;

namespace MedicalCabinetWeb.Domain.Models.MedicalAppointment;

public class MedicalAppointmentInfoDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string PatientName { get; set; }
    
    [Required]
    [Phone]
    [StringLength(15)]
    public string Phone { get; set; }
    
    [Required]
    [EmailAddress] 
    [StringLength(50)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50)]
    public string DoctorName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string ServiceName { get; set; }
    
    [Required]
    [StringLength(400)]
    public string ReasonForVisit { get; set; }
    
    [Required]
    [StringLength(10)]
    public TimeOnly AppointmentTime { get; set; } 
    
    [Required]
    [DataType(DataType.Date)]
    public DateOnly AppointmentDate { get; set; }
    
    public AppointmentStatus Status { get; set; }
}