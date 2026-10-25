using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    public class PatientDBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public PatientDBContext(DbContextOptions<PatientDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // В PostgreSQL лучше явно указать схему (обычно public)
            modelBuilder.Entity<Patient>().ToTable("Patients", schema: "public");

            modelBuilder.Entity<Patient>().HasKey(p => p.Id);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Patient>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.Gender).IsRequired();
        }
    }
}