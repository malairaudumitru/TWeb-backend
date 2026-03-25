using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using Microsoft.EntityFrameworkCore;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class MedicalAppointmentContext : DbContext
{
    public DbSet<MedicalAppointmentData> MedicalAppointments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalAppointmentData>()
            .Property(a => a.Status)
            .HasConversion<string>();
    }
    
}