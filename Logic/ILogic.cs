using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Интерфейс-фасад для бизнес-логики.
    /// Предоставляет единую точку доступа для слоя представления.
    /// </summary>
    public interface ILogic
    {
        // CRUD-операции
        void AddPatient(Patient patient);
        Patient GetPatient(int id);
        List<Patient> GetAllPatients();
        void UpdatePatient(Patient patient);
        bool DeletePatient(int id);

        //Бизнес функции в IBusinessLogic
        Dictionary<string, List<Patient>> GroupByDiagnosis();
        Dictionary<string, int> CountPatientsByDepartment();
    }
}