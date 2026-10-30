using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    // <summary>
    // Интерфейс бизнес-логики для выполнения бизнес-функций
    // </summary>
    public interface IBusinessLogic
    {
        // <summary>
        // Группирует пациентов по их диагнозам.
        // </summary>
        // <returns>Словарь, где ключ - название диагноза, а значение - список пациентов с этим диагнозом.</returns>
        public Dictionary<string, List<Patient>> GroupByDiagnosis();

        // <summary>
        // Подсчитывает количество пациентов в каждом отделении больницы.
        // </summary>
        // <returns>Словарь, где ключ - название отделения, а значение - количество пациентов в нём.</returns>
        public Dictionary<string, int> CountPatientsByDepartment();
    }
}
