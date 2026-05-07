using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCabinetWeb.Domain.Entities.MedicalService;

namespace MedicalCabinetWeb.Domain.Models.MedicalService;

public class MedicalServiceInfoDto
{
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
    
    public ServiceCategory Category { get; set; }
}