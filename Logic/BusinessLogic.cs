using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IRepository<Patient> _repository;

        public BusinessLogic(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        // <summary>
        // Группирует пациентов по их диагнозам.
        // </summary>
        // <returns>Словарь, где ключ - диагноз, а значение - список пациентов.</returns>

        public Dictionary<string, List<Patient>> GroupByDiagnosis()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Diagnosis)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // <summary>
        // Подсчитывает количество пациентов в каждом отделении.
        // </summary>
        // <returns>Словарь, где ключ - название отделения, а значение - количество пациентов.</returns>
        public Dictionary<string, int> CountPatientsByDepartment()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Department)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}