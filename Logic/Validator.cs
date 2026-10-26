using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Logic
{
    // <summary>
    // Класс, отвечающий только за проверку корректности данных пациента.
    // </summary>
    public class Validator
    {
        // <summary>
        // Проверяет объект пациента на корректность заполнения всех полей.
        // В случае обнаружения ошибок выбрасывает соответствующие исключения.
        // </summary>
        /// <param name="patient">Объект пациента для проверки.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если объект пациента равен null.</exception>
        /// <exception cref="ArgumentException">Выбрасывается, если поля содержат пустые значения или недопустимые символы.</exception>
        public void Validate(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Объект пациента не может быть пустым.");
            }

            ValidateName(patient.FirstName, "Имя");
            ValidateName(patient.LastName, "Фамилия");

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
        /// <param name="value">Проверяемая строка.</param>
        /// <param name="fieldName">Название поля (для формирования понятного сообщения об ошибке).</param>
        /// <exception cref="ArgumentException">Выбрасывается при пустом значении или наличии недопустимых символов.</exception>
        private void ValidateName(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Поле '{fieldName}' не может быть пустым.");
            }

            foreach (char c in value)
            {
                if (!char.IsLetter(c) && c != '-' && c != ' ')
                {
                    throw new ArgumentException($"Поле '{fieldName}' содержит недопустимые символы. Разрешены только буквы, пробелы и дефисы.");
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод для проверки текстовых полей (диагноз, отделение, статус).
        /// </summary>
        /// <param name="value">Проверяемая строка.</param>
        /// <param name="fieldName">Название поля (для формирования понятного сообщения об ошибке).</param>
        /// <exception cref="ArgumentException">Выбрасывается при пустом значении или наличии недопустимых символов.</exception>
        private void ValidateText(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Поле '{fieldName}' не может быть пустым.");
            }

            foreach (char c in value)
            {
                if (!char.IsLetterOrDigit(c) && c != '-' && c != ' ')
                {
                    throw new ArgumentException($"Поле '{fieldName}' содержит недопустимые символы. Разрешены только буквы, цифры, пробелы и дефисы.");
                }
            }

        }
    }
}
