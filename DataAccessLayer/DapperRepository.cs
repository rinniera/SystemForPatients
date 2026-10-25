using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using Npgsql;
using Model;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : IDomainObject
    {
       
        private readonly string _connectionString;

        private readonly string _tableName;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _tableName = "\"" + typeof(T).Name + "s\"";
        }

        private IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

        public IEnumerable<T> ReadAll()
        {
            using var db = CreateConnection();
            return db.Query<T>($"SELECT * FROM {_tableName}").ToList();
        }

        public T ReadById(int id)
        {
            using var db = CreateConnection();
            return db.QueryFirstOrDefault<T>(
                $"SELECT * FROM {_tableName} WHERE \"Id\" = @Id", new { Id = id });
        }

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

        public void Delete(T entity)
        {
            using var db = CreateConnection();
            db.Execute($"DELETE FROM {_tableName} WHERE \"Id\" = @Id", new { entity.Id });
        }
    }
}