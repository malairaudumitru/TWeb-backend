using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCabinetWeb.Domain.Entities.MedicalService;

public class MedicalServiceData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string ServiceName { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ServicePrice { get; set; }
    
    [StringLength(400)]
    public string ServiceDescription { get; set; }
    
    [Required]
    [Range(5, 480)]
    public int ServiceDuration { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    
}