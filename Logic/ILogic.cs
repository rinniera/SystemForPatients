using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    // <summary>
    // Интерфейс-фасад для бизнес-логики.
    // Предоставляет единую точку доступа для слоя представления.
    // </summary>
    public interface ILogic
    {
        // <summary>
        // Добавляет нового пациента в систему.
        // </summary>
        // <param name="patient">Объект пациента с данными для добавления.</param>
        void AddPatient(Patient patient);

        // <summary>
        // Возвращает данные конкретного пациента по его идентификатору.
        // </summary>
        // <param name="id">Уникальный идентификатор пациента.</param>
        // <returns>Объект пациента или null, если пациент с таким ID не найден.</returns>
        Patient GetPatient(int id);

        // <summary>
        // Возвращает список всех пациентов, находящихся в системе.
        // </summary>
        // <returns>Коллекция объектов типа <see cref="Patient"/>.</returns>
        List<Patient> GetAllPatients();

        // <summary>
        // Обновляет данные существующего пациента.
        // Проверяет существование пациента и валидирует новые данные.
        // </summary>
        /// <param name="patient">Объект пациента с обновленными данными (содержит ID).</param>
        void UpdatePatient(Patient patient);

        // <summary>
        // Удаляет пациента из системы по его идентификатору.
        // </summary>
        /// <param name="id">Уникальный идентификатор удаляемого пациента.</param>
        // <returns>True, если удаление прошло успешно; False, если пациент не найден.</returns>
        bool DeletePatient(int id);

        // <summary>
        // Выполняет группировку всех пациентов по их диагнозам.
        // Вызов делегируется в соответствующий части бизнес-логики.
        // </summary>
        // <returns>Словарь, где ключ — название диагноза, а значение — список пациентов с этим диагнозом.</returns>
        Dictionary<string, List<Patient>> GroupByDiagnosis();

        // <summary>
        // Подсчитывает количество пациентов в каждом отделении больницы.
        // Вызов делегируется в соответствующий части бизнес-логики.
        // </summary>
        // <returns>Словарь, где ключ — название отделения, а значение — количество пациентов в нём.</returns>
        Dictionary<string, int> CountPatientsByDepartment();
    }
}