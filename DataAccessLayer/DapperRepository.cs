using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using Model;

namespace DataAccessLayer
{
    // <summary>
    // репозиторий для работы с базой данных через Dapper. Для выполнения CRUD-операций/>.
    // </summary>
    /// <typeparam name="T">Тип сущности, реализующий <see cref="IDomainObject"/>.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : IDomainObject
    {
        // <summary>
        // Строка подключения к базе данных SQL Server
        // </summary>
        private const string ConnectionString =@"Server=LAPTOP-RMO7K6AT\SQLEXPRESS;Database=SystemForPatients;Trusted_Connection=True;TrustServerCertificate=True;";

        // <summary>
        // Полное имя таблицы в БД 
        // </summary>
        private readonly string _tableName;

        // <summary>
        // Конструктор репозитория. Формирует имя таблицы на основе имени типа <typeparamref name="T"/>.
        // </summary>
        public DapperRepository()
        {
            _tableName = "dbo." + typeof(T).Name + "s";
        }

        // <summary>
        // Создаёт новое соединение с базой данных.
        // </summary>
        /// <returns>Открытое соединение <see cref="IDbConnection"/>.</returns>
        private IDbConnection CreateConnection() => new SqlConnection(ConnectionString);

        // <summary>
        // Возвращает все записи из таблицы.
        // </summary>
        public IEnumerable<T> ReadAll()
        {
            using var db = CreateConnection();
            return db.Query<T>($"SELECT * FROM {_tableName}").ToList();
        }

        // <summary>
        // Возвращает запись по её идентификатору.
        // </summary>
        /// <param name="id">Идентификатор записи.</param>
        /// <returns>Сущность <typeparamref name="T"/> или null, если запись не найдена.</returns>
        public T ReadById(int id)
        {
            using var db = CreateConnection();
            return db.QueryFirstOrDefault<T>(
                $"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
        }

        // <summary>
        // Добавляет новую запись в таблицу.
        // После добавления данных присваивает сгенерированный базой идентификатор.
        // </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Create(T entity)
        {
            using var db = CreateConnection();

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "Id")
                .ToList();

            var columns = string.Join(", ", props.Select(p => p.Name));
            var values = string.Join(", ", props.Select(p => "@" + p.Name));

            var parameters = new DynamicParameters();
            foreach (var p in props)
            {
                var value = p.GetValue(entity);
                if (value is Enum e)
                    value = e.ToString();
                parameters.Add("@" + p.Name, value);
            }

            var sql = $"INSERT INTO {_tableName} ({columns}) OUTPUT INSERTED.Id VALUES ({values})";

            int newId = db.ExecuteScalar<int>(sql, parameters);

            entity.Id = newId;
        }

        // <summary>
        // Обновляет существующую запись в таблице.
        // </summary>
        /// <param name="entity">Сущность с обновлёнными данными (Id обязателен).</param>
        public void Update(T entity)
        {
            using var db = CreateConnection();

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "Id")
                .ToList();

            var parameters = new DynamicParameters();
            foreach (var p in props)
            {
                var value = p.GetValue(entity);
                if (value is Enum e)
                    value = e.ToString();
                parameters.Add("@" + p.Name, value);
            }
            parameters.Add("@Id", entity.Id);

            var setClause = string.Join(", ", props.Select(p => $"{p.Name} = @{p.Name}"));
            var sql = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

            db.Execute(sql, parameters);
        }

        // <summary>
        // Удаляет запись из таблицы по идентификатору сущности.
        // </summary>
        /// <param name="entity">Сущность, которую нужно удалить (используется её Id).</param>
        public void Delete(T entity)
        {
            using var db = CreateConnection();
            db.Execute($"DELETE FROM {_tableName} WHERE Id = @Id", new {entity.Id });
        }

    }
}