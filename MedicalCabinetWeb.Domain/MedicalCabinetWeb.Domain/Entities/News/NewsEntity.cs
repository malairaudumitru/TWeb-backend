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
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public NewsType Type { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}