using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using Npgsql;
using Model;

namespace DataAccessLayer
{
    // <summary>
    //  репозиторий для работы с базой данных PostgreSQL через Dapper. Реализует базовые CRUD-операции для любой сущности, унаследованной от <see cref="IDomainObject"/>.
    // </summary>
    /// <typeparam name="T">Тип сущности, с которой работает репозиторий.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : IDomainObject
    {
        // Строка подключения к базе данных. Передается извне через конструктор (Dependency Injection).
        private readonly string _connectionString;

        // Имя таблицы в базе данных, сформированное на основе имени типа T.
        private readonly string _tableName;

        //<summary>
        // Инициализирует новый экземпляр репозитория Dapper.
        // </summary>
        /// <param name="connectionString">Строка подключения к базе данных PostgreSQL.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если строка подключения равна null.</exception>
        public DapperRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _connectionString = connectionString;

            _tableName = "\"" + typeof(T).Name + "s\"";
        }

        // <summary>
        // Создает новое соединение с базой данных.
        // </summary>
        /// <returns>Объект соединения, реализующий интерфейс <see cref="IDbConnection"/>.</returns>
        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        // <summary>
        // Возвращает все записи из таблицы.
        // </summary>
        /// <returns>Коллекция сущностей <typeparamref name="T"/>.</returns>
        public IEnumerable<T> ReadAll()
        {
            using var db = CreateConnection();
            return db.Query<T>($"SELECT * FROM {_tableName}").ToList();
        }

        // <summary>
        // Возвращает запись по её уникальному идентификатору.
        // </summary>
        /// <param name="id">Идентификатор записи.</param>
        // <returns>Найденная сущность или null, если запись не найдена.</returns>
        public T ReadById(int id)
        {
            using var db = CreateConnection();
            return db.QueryFirstOrDefault<T>(
                $"SELECT * FROM {_tableName} WHERE \"Id\" = @Id", new { Id = id });
        }

        // <summary>
        // Добавляет новую запись в таблицу и присваивает сущности сгенерированный базой данных ID.
        // </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Create(T entity)
        {
            using var db = CreateConnection();

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "Id")
                .ToList();

            var columns = string.Join(", ", props.Select(p => $"\"{p.Name}\""));
            var values = string.Join(", ", props.Select(p => "@" + p.Name));

            var parameters = new DynamicParameters();
            foreach (var p in props)
            {
                var value = p.GetValue(entity);
                if (value is Enum e)
                    value = e.ToString();
                parameters.Add("@" + p.Name, value);
            }

            var sql = $"INSERT INTO {_tableName} ({columns}) VALUES ({values}) RETURNING \"Id\"";

            int newId = db.ExecuteScalar<int>(sql, parameters);

            entity.Id = newId;
        }

        // <summary>
        // Обновляет существующую запись в таблице.
        // </summary>
        /// <param name="entity">Сущность с обновленными данными.</param>
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

            var setClause = string.Join(", ", props.Select(p => $"\"{p.Name}\" = @{p.Name}"));
            var sql = $"UPDATE {_tableName} SET {setClause} WHERE \"Id\" = @Id";

            db.Execute(sql, parameters);
        }

        // <summary>
        // Удаляет запись из таблицы по её идентификатору.
        // </summary>
        /// <param name="entity">Удаляемая сущность (используется её Id).</param>
        public void Delete(T entity)
        {
            using var db = CreateConnection();
            db.Execute($"DELETE FROM {_tableName} WHERE \"Id\" = @Id", new { entity.Id });
        }
    }
}