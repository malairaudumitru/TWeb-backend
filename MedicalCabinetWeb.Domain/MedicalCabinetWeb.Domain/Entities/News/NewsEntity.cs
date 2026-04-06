using System.ComponentModel.DataAnnotations;

namespace MedicalCabinetWeb.Domain.Entities.News;

public enum NewsType
{
    ServiciuNou,
    Promotie,
    MedicNou,
    ActualizarePret
}

public class NewsEntity
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(400)]
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}

