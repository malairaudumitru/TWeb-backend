using MedicalCabinetWeb.Domain.Entities.News;
using Microsoft.EntityFrameworkCore;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class NewsDbContext: DbContext
{
    public DbSet<NewsEntity> News { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsEntity>()
            .Property(n => n.Type)
            .HasConversion<string>(); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}