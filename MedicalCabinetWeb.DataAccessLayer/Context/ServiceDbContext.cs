using MedicalCabinetWeb.Domain.Entities.Service;
using Microsoft.EntityFrameworkCore;


namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class ServiceDbContext: DbContext
{
    public DbSet<ServiceEntity> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}