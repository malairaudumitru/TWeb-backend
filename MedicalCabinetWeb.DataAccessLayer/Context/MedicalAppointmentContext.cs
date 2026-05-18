using MedicalCabinetWeb.Domain.Entities.MedicalAppointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class MedicalAppointmentContext : DbContext
{
    public DbSet<MedicalAppointmentData> MedicalAppointments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets(System.Reflection.Assembly.GetEntryAssembly()!)
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
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