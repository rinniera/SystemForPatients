using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    // <summary>
    // репозиторий для работы с базой данных через Entity Framework. Реализует базовые CRUD-операции />.
    /// Использует <see cref="PatientDBContext"/> для доступа к данным.
    // </summary>
    /// <typeparam name="T">Тип сущности, реализующий <see cref="IDomainObject"/>.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        // <summary>
        // Контекст базы данных EF, через который выполняются все операции.
        // </summary>
        private readonly PatientDBContext _context;

        // <summary>
        // Набор сущностей <typeparamref name="T"/> в контексте.
        // </summary>
        private readonly DbSet<T> _dbSet;

        // <summary>
        // Конструктор репозитория. Создаёт новый контекст БД и получает набор сущностей указанного типа.
        // </summary>
        public EntityRepository()
        {
            _context = new PatientDBContext();
            _dbSet = _context.Set<T>();
        }

        // <summary>
        // Возвращает все сущности из базы данных.
        // </summary>
        /// <returns>Список всех сущностей <typeparamref name="T"/>.</returns>
        public IEnumerable<T> ReadAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        // <summary>
        // Возвращает сущность по её идентификатору.
        // </summary>
        /// <param name="id">Идентификатор сущности.</param>
        // <returns>Найденная сущность или null, если запись не найдена.</returns>
        public T ReadById(int id)
        {
            return _dbSet.Find(id);
        }

        // <summary>
        // Добавляет новую сущность в базу данных.
        // </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // <summary>
        // Обновляет существующую сущность в базе данных.
        // </summary>
        /// <param name="entity">Сущность с обновлёнными данными (Id обязателен).</param>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        // <summary>
        // Удаляет сущность из базы данных.
        // </summary>
        /// <param name="entity">Удаляемая сущность.</param>
        public void Delete(T entity)
        {
                _dbSet.Remove(entity);
                _context.SaveChanges();
         
        }

    }
}