using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;


namespace DataAccessLayer
{
    internal interface IRepository<T> where T : IDomainObject, new()

    {
        void Create(T obj);

        //void Add(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(T obj);

    }
}
