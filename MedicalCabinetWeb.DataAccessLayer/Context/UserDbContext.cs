using MedicalCabinetWeb.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class UserDbContext : DbContext
{
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medic> Medics { get; set; }
    public DbSet<Admin> Admins { get; set; }

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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserAccount>()
            .HasOne(u => u.Patient)
            .WithOne(p => p.UserAccount)
            .HasForeignKey<Patient>(p => p.UserAccountId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserAccount>()
            .HasOne(u => u.Medic)
            .WithOne(m => m.UserAccount)
            .HasForeignKey<Medic>(m => m.UserAccountId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserAccount>()
            .HasOne(u => u.Admin)
            .WithOne(a => a.UserAccount)
            .HasForeignKey<Admin>(a => a.UserAccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}