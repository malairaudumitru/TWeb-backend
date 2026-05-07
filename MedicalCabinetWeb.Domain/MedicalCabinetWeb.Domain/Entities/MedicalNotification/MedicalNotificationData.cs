using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCabinetWeb.Domain.Entities.MedicalNotification;

public class MedicalNotificationData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(400)]
    public string Message { get; set; }
    
    
    public bool IsRead { get; set; } = false;
    
    public bool IsDeleted { get; set; } = false;
    
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [DataType(DataType.Date)]
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    
}