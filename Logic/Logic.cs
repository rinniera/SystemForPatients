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
        private List<Patient> patients = new List<Patient>();

        private int nextId = 1;

        //<summary>
        // функция для добавления пациента.
        // получает параметр - объект пациента. 
        //</summary>
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

        //<summary>
        // функция для проверки введённых пациента.
        // получает параметр - объект пациента. 
        //</summary>
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

        //<summary>
        // функция для проверки введённых символов в строке.
        // строка должна содержать буквы, дефис и пробел. 
        //</summary>
        private static bool IsNameValid(string value)
        {
            return value.All(c => char.IsLetter(c) || c == '-' || c == ' ');
        }

        //<summary>
        // функция для проверки введённых символов в строке.
        // строка должна содержать буквы, цифры, дефис и пробел. 
        //</summary>
        private static bool IsTextValid(string value)
        {
            return value.All(
                c => char.IsLetterOrDigit(c) || c == '-' || c == ' ');
        }

        //<summary>
        // функция для вывода данных об одном пациенте.
        // получает номер пациента.
        // возвращает объект Patient или null, он не был найден.
        //</summary>
        public Patient GetPatient(int id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        //<summary>
        // функция для вывода списка всех пациентов. возвращает копию списка. 
        //</summary>
        public List<Patient> GetAllPatients()
        {
            return new List<Patient>(patients);
        }

        //<summary>
        // функция для обновления данных о пациенте.
        // получает объект пациента с тем же id, но новыми данными.
        //</summary>
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

        //<summary>
        // функция для удаления пациента из списка.
        // получает номер пациента 
        //</summary>
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

        //<summary>
        // группирует пациентов по диагнозу
        // ключ - диагноз, значение - пациенты с этим диагнозом.
        //</summary>
        public Dictionary<string, List<Patient>> GroupByDiagnosis()
        {
            return patients
                .GroupBy(p => p.Diagnosis)
                .ToDictionary(
                    group => group.Key,
                    group => group.ToList()
                );
        }

        //<summary>
        // считает количество пациентов в отделении
        // ключ - название отделения, значение - количество пациентов.
        //</summary> 
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