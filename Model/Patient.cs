using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patient: IDomainObject
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Gender Gender { get; set; }

        public string Diagnosis { get; set; } 
        public string Department { get; set; }
        public string TreatmentStatus { get; set; }
    }
}
