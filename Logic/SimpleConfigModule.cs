using Ninject.Modules;
using DataAccessLayer;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    // <summary>
    // Модуль конфигурации зависимостей для IoC-контейнера Ninject.
    // Отвечает за связывание интерфейсов с их конкретными реализациями и настройку подключения к базе данных.
    // </summary>
    public class SimpleConfigModule : NinjectModule
    {
        // <summary>
        // Метод загрузки конфигурации. Вызывается автоматически при инициализации ядра Ninject. В нём определяются все правила создания объектов.
        // </summary>
        public override void Load()
        {
            string connectionString = "Host=aws-0-eu-west-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.sxiucvcwrwgbdzrhpoya;Password=19Brick286GG;SSL Mode=Require;Trust Server Certificate=true;";

            // настройки для контекста базы данных, передаётся строка подключения и указывается провайдер PostgreSQL.
            var dbContextOptions = new DbContextOptionsBuilder<PatientDBContext>()
                .UseNpgsql(connectionString)
                .Options;

            // контекст базы данных(PatientDBContext).
            // SingletonScope, чтобы в рамках приложения существовал только один экземпляр контекста.
            // Принудительно передаём ему объект dbContextOptions через конструктор.
            Bind<PatientDBContext>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("options", dbContextOptions);

            //Bind<EntityRepository<Patient>>()
            //  .ToSelf()
            //  .InSingletonScope();

            // связываем интерфейс IRepository<Patient> и класс DapperRepository<Patient>.
            // Внедряем строку подключения напрямую в конструктор репозитория, так логика будет работать через Dapper.
            Bind<IRepository<Patient>>()
               .To<DapperRepository<Patient>>()
               .InSingletonScope()
               .WithConstructorArgument("connectionString", connectionString);

            // Ninject будет автоматически создавать его экземпляр 
            Bind<Validator>().ToSelf();

            Bind<IBusinessLogic>().To<BusinessLogic>();
        }
    }
}
    
