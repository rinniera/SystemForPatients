using Microsoft.EntityFrameworkCore;
using Model;


namespace DataAccessLayer
{
        public class PatientDBContext : DbContext
        {

            // <summary>
            // Набор сущностей "Пациент". Соответствует таблице "Patient" в базе данных.
            // </summary>
        public DbSet<Patient> Patients { get; set; }


            // <summary>
            // Настройка подключения к базе данных SQL Server. Используется экземпляр SQLEXPRESS, база данных SystemForPatients.
            // </summary>
            /// <param name="optionsBuilder">Построитель параметров подключения к БД.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-RMO7K6AT\SQLEXPRESS;Database=SystemForPatients;Trusted_Connection=True;TrustServerCertificate=True;");
            }

            /// <summary>
            /// Настройка отображения модели на таблицу базы данных: имя таблицы, первичный ключ, автоинкремент Id, преобразование пола в строку и обязательность полей.
            /// </summary>
            /// <param name="modelBuilder">Построитель модели EF.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Patient>().ToTable("Patients");

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