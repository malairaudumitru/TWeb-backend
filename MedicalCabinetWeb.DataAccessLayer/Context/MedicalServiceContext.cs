<<<<<<<< HEAD:MedicalCabinetWeb.DataAccessLayer/Context/UserDbContext.cs
﻿using MedicalCabinetWeb.Domain.Entities.User;
========
﻿using MedicalCabinetWeb.Domain.Entities.MedicalService;
>>>>>>>> malairaudumitru:MedicalCabinetWeb.DataAccessLayer/Context/MedicalServiceContext.cs
using Microsoft.EntityFrameworkCore;

namespace MedicalCabinetWeb.DataAccessLayer.Context;

<<<<<<<< HEAD:MedicalCabinetWeb.DataAccessLayer/Context/UserDbContext.cs
public class UserDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medic> Medics { get; set; }
    public DbSet<Admin> Admins { get; set; }
========
public class MedicalServiceContext: DbContext
{
    public DbSet<MedicalServiceData> MedicalServices { get; set; }
>>>>>>>> malairaudumitru:MedicalCabinetWeb.DataAccessLayer/Context/MedicalServiceContext.cs

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MedicalCabinet;Username=postgres;Password=admin");
        }
    }
}