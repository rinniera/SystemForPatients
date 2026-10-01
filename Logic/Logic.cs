using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Logic
{
    public class Logic
    {
        //IRepository<project> repository = new EntityProjectRepository();

        private List<Patient> patients = new List<Patient>();

        private int nextId = 1;

        ///<summary>
        /// метод для добавления пациента в список
        /// </summary>
        /// <param name="patient">объект пациента</param>
        
        public void AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            ValidatePatient(patient);

            patient.Id = nextId;
            nextId++;

            patients.Add(patient);
        }

        ///<summary>
        /// метод для проверки введённых данных о пациенте
        /// </summary>
        /// <param name="patient">объект пациента</param>

        private void ValidatePatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FirstName))
            {
                throw new ArgumentException("Имя пациента не может быть пустым!");
            }

            if (!IsNameValid(patient.FirstName))
            {
                throw new ArgumentException("Имя пациента содержит недопустимые символы!");
            }

            if (string.IsNullOrWhiteSpace(patient.LastName))
            {
                throw new ArgumentException("Фамилия пациента не может быть пустой!");
            }

            if (!IsNameValid(patient.LastName))
            {
                throw new ArgumentException("Фамилия пациента содержит недопустимые символы!");
            }

            if (!string.IsNullOrWhiteSpace(patient.Patronymic) &&
                !IsNameValid(patient.Patronymic))
            {
                throw new ArgumentException("Отчество содержит недопустимые символы!");
            }

            if (patient.Gender == Gender.NotSelected)
            {
                throw new ArgumentException("Необходимо указать пол пациента!");
            }

            if (string.IsNullOrWhiteSpace(patient.Diagnosis))
            {
                throw new ArgumentException("Диагноз не может быть пустым!");
            }

            if (!IsTextValid(patient.Diagnosis))
            {
                throw new ArgumentException("Диагноз содержит недопустимые символы!");
            }

            if (string.IsNullOrWhiteSpace(patient.Department))
            {
                throw new ArgumentException("Отделение не может быть пустым!");
            }

            if (!IsTextValid(patient.Department))
            {
                throw new ArgumentException("Отделение содержит недопустимые символы!");
            }

            if (string.IsNullOrWhiteSpace(patient.TreatmentStatus))
            {
                throw new ArgumentException("Статус лечения не может быть пустым!");
            }

            if (!IsTextValid(patient.TreatmentStatus))
            {
                throw new ArgumentException("Статус лечения содержит недопустимые символы!");
            }
        }

        ///<summary>
        /// метод для проверки введённых символов в строке. должна содержать буквы, дефис и пробел.
        /// </summary>
        /// <param name="value"> введённая строка </param>
        /// <return> возвращает true, если введённое значение содержит допустимые символы, иначе false</return>

        private static bool IsNameValid(string value)
        {
            return value.All(c => char.IsLetter(c) || c == '-' || c == ' ');
        }

        ///<summary>
        /// функция для проверки введённых символов в строке. должна содержать буквы, цифры, дефис и пробел.
        /// </summary>
        /// <param name="value"> введённая строка </param>
        /// <return> возвращает true, если введённое значение содержит допустимые символы, иначе false</return>
        private static bool IsTextValid(string value)
        {
            return value.All(
                c => char.IsLetterOrDigit(c) || c == '-' || c == ' ');
        }

        ///<summary>
        /// метод для вывода данных о пациенте. 
        /// </summary>
        /// <param name="id"> id пациента </param>
        /// <return> возвращает объект соответствующий полученному id или null, если он не был найден </return>
        public Patient GetPatient(int id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        ///<summary>
        /// метод для вывода всех пациентов из списка
        /// </summary>
        /// <return> возвращает копию списка </return>
        public List<Patient> GetAllPatients()
        {
            return new List<Patient>(patients);
        }

        ///<summary>
        /// метод для обновления данных о пациенте
        /// </summary>
        /// <param name="patient"> объект пациента с обновлёнными данными </param>
        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            ValidatePatient(patient);

            Patient existingPatient = GetPatient(patient.Id);

            if (existingPatient == null)
            {
                throw new ArgumentException("Пациент с указанным номером не найден.");
            }

            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.Patronymic = patient.Patronymic;
            existingPatient.Gender = patient.Gender;
            existingPatient.Diagnosis = patient.Diagnosis;
            existingPatient.Department = patient.Department;
            existingPatient.TreatmentStatus = patient.TreatmentStatus;
        }

        ///<summary>
        /// метод удаления пациента из списка
        /// </summary>
        /// <param name="id"> объект введённый id </param>
        /// <return> если id не был получен, метод возвращает false. в ином случае вернёт true. </return>
        public bool DeletePatient(int id)
        {
            Patient patient = GetPatient(id);

            if (patient == null)
            {
                return false;
            }

            patients.Remove(patient);
            return true;
        }

        ///<summary>
        /// метод для группировки пациентов по диагнозу. ключ - диагноз, значение - пациенты с этим диагнозом.
        /// </summary>
        /// <return> возвращает словарь с группированными данными. </return>
        public Dictionary<string, List<Patient>> GroupByDiagnosis()
        {
            return patients
                .GroupBy(p => p.Diagnosis)
                .ToDictionary(
                    group => group.Key,
                    group => group.ToList()
                );
        }

        ///<summary>
        /// метод для подсчётов пациентов в отделении. ключ - название отделения, значение - количество пациентов.
        /// </summary>
        /// <return> возвращает словарь с группированными данными </return>
        public Dictionary<string, int> CountPatientsByDepartment()
        {
            return patients
                .GroupBy(p => p.Department)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );
        }
    }
}