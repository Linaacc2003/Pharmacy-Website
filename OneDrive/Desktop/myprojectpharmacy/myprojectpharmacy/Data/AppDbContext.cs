using Microsoft.EntityFrameworkCore;
using myprojectpharmacy.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pharmacist> Pharmacists { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pharmacist>().ToTable("Pharmacists");
        modelBuilder.Entity<Patient>().ToTable("Patients");
        modelBuilder.Entity<Prescription>().ToTable("Prescriptions");
        modelBuilder.Entity<Supplier>().ToTable("Suppliers");
        modelBuilder.Entity<User>().ToTable("Users");

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Pharmacist)
            .WithMany()
            .HasForeignKey(p => p.PharmacistId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany()
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
