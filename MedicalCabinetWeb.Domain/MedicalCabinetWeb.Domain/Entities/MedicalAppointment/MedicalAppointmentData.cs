using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCabinetWeb.Domain.Entities.MedicalAppointment;

public class MedicalAppointmentData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
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
    public string AppointmentTime { get; set; } 
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [DataType(DataType.Date)]
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Asteptare;
    
    public bool IsDeleted { get; set; } = false;
    
}