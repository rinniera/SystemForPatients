using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Logic
{
    public class Validator
    {
        public void Validate(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Объект пациента не может быть пустым.");
            }

            ValidateName(patient.FirstName, "Имя");
            ValidateName(patient.LastName, "Фамилия");

            // Отчество необязательно к заполнению, но если оно есть, оно должно быть валидным
            if (!string.IsNullOrWhiteSpace(patient.Patronymic))
            {
                ValidateName(patient.Patronymic, "Отчество");
            }

            if (patient.Gender == Gender.NotSelected)
            {
                throw new ArgumentException("Необходимо указать пол пациента.");
            }

            ValidateText(patient.Diagnosis, "Диагноз");
            ValidateText(patient.Department, "Отделение");
            ValidateText(patient.TreatmentStatus, "Статус лечения");
        }

        /// <summary>
        /// Вспомогательный метод для проверки строковых полей (имя, фамилия, отчество).
        /// </summary>
        private void ValidateName(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Поле '{fieldName}' не может быть пустым.");
            }

            foreach (char c in value)
            {
                // Разрешаем только буквы, дефис и пробел
                if (!char.IsLetter(c) && c != '-' && c != ' ')
                {
                    throw new ArgumentException($"Поле '{fieldName}' содержит недопустимые символы. Разрешены только буквы, пробелы и дефисы.");
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод для проверки текстовых полей (диагноз, отделение, статус).
        /// </summary>
        private void ValidateText(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Поле '{fieldName}' не может быть пустым.");
            }

            foreach (char c in value)
            {
                // Разрешаем буквы, цифры, дефис и пробел
                if (!char.IsLetterOrDigit(c) && c != '-' && c != ' ')
                {
                    throw new ArgumentException($"Поле '{fieldName}' содержит недопустимые символы. Разрешены только буквы, цифры, пробелы и дефисы.");
                }
            }

        }
    }
}
