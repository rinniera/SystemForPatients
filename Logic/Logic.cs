using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Logic
{
    /// <summary>
    /// Класс бизнес-логики для управления данными пациентов.
    /// </summary>
    public class Logic
    {
        private readonly IRepository<Patient> _repository;
        private readonly Validator _validator;

        public IRepository<Patient> Repository { get; set; }

        // Конструктор, принимающий абстракцию
        public Logic(IRepository<Patient> repository)
        {
            Repository = repository;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса бизнес-логики.
        /// </summary>
        /// <param name="repository">Репозиторий для доступа к данным.</param>
        /// <param name="validator">Валидатор для проверки корректности данных.</param>
        public Logic(IRepository<Patient> repository, Validator validator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Добавляет нового пациента в базу данных после успешной валидации.
        /// </summary>
        /// <param name="patient">Объект пациента.</param>
        public void AddPatient(Patient patient)
        {
            _validator.Validate(patient);
            _repository.Create(patient);
        }

        /// <summary>
        /// Возвращает данные о пациенте по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <returns>Объект пациента или null, если пациент не найден.</returns>
        public Patient GetPatient(int id)
        {
            return _repository.ReadById(id);
        }

        /// <summary>
        /// Возвращает список всех пациентов.
        /// </summary>
        /// <returns>Список объектов пациентов.</returns>
        public List<Patient> GetAllPatients()
        {
            return _repository.ReadAll().ToList();
        }

        /// <summary>
        /// Обновляет данные существующего пациента.
        /// </summary>
        /// <param name="patient">Объект пациента с обновленными данными.</param>
        public void UpdatePatient(Patient patient)
        {
            _validator.Validate(patient);

            Patient existing = _repository.ReadById(patient.Id);
            if (existing == null)
            {
                throw new ArgumentException($"Пациент с идентификатором {patient.Id} не найден.");
            }

            // Обновляем поля существующей сущности
            existing.FirstName = patient.FirstName;
            existing.LastName = patient.LastName;
            existing.Patronymic = patient.Patronymic;
            existing.Gender = patient.Gender;
            existing.Diagnosis = patient.Diagnosis;
            existing.Department = patient.Department;
            existing.TreatmentStatus = patient.TreatmentStatus;

            _repository.Update(existing);
        }

        /// <summary>
        /// Удаляет пациента из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <returns>True, если удаление прошло успешно; иначе False.</returns>
        public bool DeletePatient(int id)
        {
            Patient patient = _repository.ReadById(id);
            if (patient == null)
            {
                return false;
            }

            _repository.Delete(patient);
            return true;
        }

        /// <summary>
        /// Группирует пациентов по их диагнозам.
        /// </summary>
        /// <returns>Словарь, где ключ - диагноз, а значение - список пациентов.</returns>
        public Dictionary<string, List<Patient>> GroupByDiagnosis()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Diagnosis)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        /// <summary>
        /// Подсчитывает количество пациентов в каждом отделении.
        /// </summary>
        /// <returns>Словарь, где ключ - название отделения, а значение - количество пациентов.</returns>
        public Dictionary<string, int> CountPatientsByDepartment()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Department)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}