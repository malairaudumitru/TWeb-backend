using MedicalCabinetWeb.Domain.Entities.MedicalService;
using Microsoft.EntityFrameworkCore;


namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class MedicalServiceContext: DbContext
{
    public DbSet<MedicalServiceData> MedicalServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}