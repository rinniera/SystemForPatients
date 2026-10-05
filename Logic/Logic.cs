using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Logic
{
    public class Logic
    {
        private readonly IRepository<Patient> _repository;

        public Logic(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        ///<summary>
        /// метод для добавления пациента
        /// </summary>
        /// <param name="patient">объект пациента</param>
        public void AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            ValidatePatient(patient);
            _repository.Create(patient);
        }

        ///<summary>
        /// метод для проверки введённых данных о пациенте
        /// </summary>
        /// <param name="patient">объект пациента</param>
        private void ValidatePatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FirstName))
                throw new ArgumentException("Имя пациента не может быть пустым!");

            if (!IsNameValid(patient.FirstName))
                throw new ArgumentException("Имя пациента содержит недопустимые символы!");

            if (string.IsNullOrWhiteSpace(patient.LastName))
                throw new ArgumentException("Фамилия пациента не может быть пустой!");

            if (!IsNameValid(patient.LastName))
                throw new ArgumentException("Фамилия пациента содержит недопустимые символы!");

            if (!string.IsNullOrWhiteSpace(patient.Patronymic) &&
                !IsNameValid(patient.Patronymic))
                throw new ArgumentException("Отчество содержит недопустимые символы!");

            if (patient.Gender == Gender.NotSelected)
                throw new ArgumentException("Необходимо указать пол пациента!");

            if (string.IsNullOrWhiteSpace(patient.Diagnosis))
                throw new ArgumentException("Диагноз не может быть пустым!");

            if (!IsTextValid(patient.Diagnosis))
                throw new ArgumentException("Диагноз содержит недопустимые символы!");

            if (string.IsNullOrWhiteSpace(patient.Department))
                throw new ArgumentException("Отделение не может быть пустым!");

            if (!IsTextValid(patient.Department))
                throw new ArgumentException("Отделение содержит недопустимые символы!");

            if (string.IsNullOrWhiteSpace(patient.TreatmentStatus))
                throw new ArgumentException("Статус лечения не может быть пустым!");

            if (!IsTextValid(patient.TreatmentStatus))
                throw new ArgumentException("Статус лечения содержит недопустимые символы!");
        }

        private static bool IsNameValid(string value)
            => value.All(c => char.IsLetter(c) || c == '-' || c == ' ');

        private static bool IsTextValid(string value)
            => value.All(c => char.IsLetterOrDigit(c) || c == '-' || c == ' ');

        ///<summary>
        /// метод для вывода данных о пациенте
        /// </summary>
        /// <param name="id">id пациента</param>
        /// <return>объект или null</return>
        public Patient GetPatient(int id)
        {
            return _repository.ReadById(id);
        }

        ///<summary>
        /// метод для вывода всех пациентов
        /// </summary>
        public List<Patient> GetAllPatients()
        {
            return _repository.ReadAll().ToList();
        }

        ///<summary>
        /// метод для обновления данных о пациенте
        /// </summary>
        /// <param name="patient">объект пациента с обновлёнными данными</param>
        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            ValidatePatient(patient);

            Patient existing = _repository.ReadById(patient.Id);
            if (existing == null)
                throw new ArgumentException("Пациент с указанным номером не найден.");

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

        ///<summary>
        /// метод удаления пациента
        /// </summary>
        /// <param name="id">id пациента</param>
        /// <return>true, если удалено</return>
        public bool DeletePatient(int id)
        {
            Patient patient = _repository.ReadById(id);
            if (patient == null)
                return false;

            _repository.Delete(patient);
            return true;
        }

        ///<summary>
        /// группировка пациентов по диагнозу
        /// </summary>
        public Dictionary<string, List<Patient>> GroupByDiagnosis()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Diagnosis)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        ///<summary>
        /// подсчёт пациентов в отделении
        /// </summary>
        public Dictionary<string, int> CountPatientsByDepartment()
        {
            return _repository.ReadAll()
                .GroupBy(p => p.Department)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}