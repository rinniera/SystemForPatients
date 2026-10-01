using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperProjectRepository : IRepository<Patient>
    {
        public void Create(Patient obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Patient ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient obj)
        {
            throw new NotImplementedException();
        }
    }
}


