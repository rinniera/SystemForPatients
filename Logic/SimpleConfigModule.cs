using Ninject.Modules;
using DataAccessLayer;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // 1. Ваша строка подключения
            string connectionString = "Host=aws-0-eu-west-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.sxiucvcwrwgbdzrhpoya;Password=19Brick286GG;SSL Mode=Require;Trust Server Certificate=true;";

            // ==========================================
            // НАСТРОЙКА ENTITY FRAMEWORK
            // ==========================================
            var dbContextOptions = new DbContextOptionsBuilder<PatientDBContext>()
                .UseNpgsql(connectionString)
                .Options;

            Bind<PatientDBContext>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("options", dbContextOptions);

            Bind<EntityRepository<Patient>>()
                .ToSelf()
                .InSingletonScope();

            // ==========================================
            // ВЫБОР ОСНОВНОГО РЕПОЗИТОРИЯ
            // ==========================================
            // Если вы биндите интерфейс к Dapper, строка подключения 
            // передастся из бинда выше (где мы настраивали DapperRepository).
            Bind<IRepository<Patient>>()
               .To<DapperRepository<Patient>>()
               .InSingletonScope()
               .WithConstructorArgument("connectionString", connectionString);
            // ==========================================
            // ВАЛИДАТОР
            // ==========================================
            Bind<Validator>().ToSelf();
        }
    }
}
    
