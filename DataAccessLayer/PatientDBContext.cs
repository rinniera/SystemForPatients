using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    // <summary>
    // Контекст базы данных Entity Framework для работы с сущностями пациентов.
    // Отвечает за настройку подключения, маппинг объектов C# на таблицы БД и управление изменениями.
    // </summary>
    public class PatientDBContext : DbContext
    {

        // <summary>
        // Набор сущностей - таблица - "Пациенты" в базе данных.
        // </summary>
        public DbSet<Patient> Patients { get; set; }

        // <summary>
        // Инициализирует новый экземпляр контекста базы данных. Настройки подключения (строки подключения, провайдер БД) передаются извне 
        // Конструктор пуст, так как вся необходимая конфигурация уже передана в базовый класс DbContext через параметр options.
        // </summary>
        /// <param name="options">Параметры конфигурации контекста.</param>
        public PatientDBContext(DbContextOptions<PatientDBContext> options)
            : base(options)
        {

        }

        // <summary>
        // Настраивает модель данных и правила отображения (маппинга) сущностей C# на структуру таблиц базы данных PostgreSQL.
        // </summary>
        /// <param name="modelBuilder">Построитель модели, используемый для конфигурации сущностей.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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