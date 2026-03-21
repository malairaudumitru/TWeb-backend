using MedicalCabinetWeb.Domain.Entities.MedicalService;
using Microsoft.EntityFrameworkCore;


namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class ServiceDbContext: DbContext
{
    public DbSet<MedicalServiceData> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}