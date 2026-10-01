using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityProjectRepository : IRepository<Patient>
    {
        private readonly PatientContext _context;

        public EntityProjectRepository(PatientContext context)
        {
            _context = context;
        }

        public void Create(Patient obj)
        {
            //throw new NotImplementedException();
            //_context.Set<Patient>().Add(obj);
            //_context.SaveChanges();
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
