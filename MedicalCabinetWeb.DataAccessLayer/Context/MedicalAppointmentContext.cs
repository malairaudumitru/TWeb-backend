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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalAppointmentData>()
            .Property(x => x.AppointmentDate)
            .HasColumnType("date");
        
        modelBuilder.Entity<MedicalAppointmentData>()
            .Property(x => x.AppointmentTime)
            .HasColumnType("time");
    }
    
}