using MedicalCabinetWeb.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

public class ReviewsDbContext: DbContext
{
    public DbSet<ReviewsEntity> Reviews { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}