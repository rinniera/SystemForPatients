using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject 
    {
        // <summary>
        // Добавляет новую сущность в бд
        // </summary>
        void Create(T obj);

        // <summary>
        // Возвращает все сущности из бд
        // </summary>
        // <returns>Коллекция всех сущностей <typeparamref name="T"/>.</returns>
        IEnumerable<T> ReadAll();

        // <summary>
        // Возвращает сущность по её идентификатору.
        // </summary>
        /// <param name="id">Идентификатор сущности.</param>
        // <returns>Найденная сущность или null, если запись не найдена.</returns>
        T ReadById(int id);

        // <summary>
        /// Обновляет существующую сущность в бд
        // </summary>
        /// <param name="obj">Сущность с обновлёнными данными (Id обязателен).</param>
        void Update(T obj);

        // <summary>
        // Удаляет сущность из хранилища.
        // </summary>
        /// <param name="obj">Удаляемая сущность (используется её Id).</param>
        void Delete(T obj);

    }
}
