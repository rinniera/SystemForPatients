using System;
using System.Collections.Generic;
using Logic;
using Model;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Logic.Logic logic = new Logic.Logic();

            bool start = true;

            while (start)
            {
                Console.Clear();

                Console.WriteLine(" Система учёта пациентов в больнице ");
                Console.WriteLine();
                Console.WriteLine("1. Показать всех пациентов");
                Console.WriteLine("2. Добавить пациента");
                Console.WriteLine("3. Найти пациента");
                Console.WriteLine("4. Изменить пациента");
                Console.WriteLine("5. Удалить пациента");
                Console.WriteLine("6. Группировка пациентов по диагнозу");
                Console.WriteLine("7. Количество пациентов по отделениям");
                Console.WriteLine("0. Выход");
                Console.WriteLine();

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ShowAllPatients(logic);
                        break;

                    case "2":
                        AddPatient(logic);
                        break;

                    case "3":
                        FindPatient(logic);
                        break;

                    case "4":
                        UpdatePatient(logic);
                        break;

                    case "5":
                        DeletePatient(logic);
                        break;

                    case "6":
                        GroupPatientsByDiagnosis(logic);
                        break;

                    case "7":
                        CountPatientsByDepartment(logic);
                        break;

                    case "0":
                        start = false;
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню нет.");
                        break;
                }

                if (start)
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                    Console.ReadKey();
                }
            }
        }
        static void AddPatient(Logic.Logic logic)
        {
            Console.WriteLine("Добавить нового пациента: ");
            Console.WriteLine();

            Patient patient = new Patient();

            Console.Write("Введите имя: ");
            patient.FirstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            patient.LastName = Console.ReadLine();

            Console.Write("Введите отчество (если есть): ");
            patient.Patronymic = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Выберите пол:");
            Console.WriteLine("1. Мужской");
            Console.WriteLine("2. Женский");
            Console.Write("Вы выбрали: ");

            string genderChoice = Console.ReadLine();

            if (genderChoice == "1")
            {
                patient.Gender = Gender.Male;
            }
            else if (genderChoice == "2")
            {
                patient.Gender = Gender.Female;
            }
            else
            {
                patient.Gender = Gender.NotSelected;
            }

            Console.WriteLine();

            Console.Write("Введите диагноз: ");
            patient.Diagnosis = Console.ReadLine();

            Console.Write("Введите отделение: ");
            patient.Department = Console.ReadLine();

            Console.Write("Введите статус лечения: ");
            patient.TreatmentStatus = Console.ReadLine();

            try
            {
                logic.AddPatient(patient);

                Console.WriteLine();
                Console.WriteLine(
                    "Пациент добавлен. Его номер в списке: " + patient.Id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void ShowAllPatients(Logic.Logic logic)
        {
            Console.WriteLine("Список пациентов: ");
            Console.WriteLine();

            List<Patient> patients = logic.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            foreach (Patient patient in patients)
            {
                ShowPatient(patient);
            }
        }

        static void FindPatient(Logic.Logic logic)
        {
            Console.WriteLine("Поиск пациента в системе:");
            Console.WriteLine();

            Console.Write("Введите номер пациента: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Номер должен быть числом!");
                return;
            }

            Patient patient = logic.GetPatient(id);

            if (patient == null)
            {
                Console.WriteLine("Пациент с таким номером не найден!");
                return;
            }

            Console.WriteLine();
            ShowPatient(patient);
        }

        static void UpdatePatient(Logic.Logic logic)
        {
            Console.WriteLine("Изменение данных о пациенте:");
            Console.WriteLine();

            Console.Write("Введите номер пациента: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Номер должен быть числом!");
                return;
            }

            Patient existingPatient = logic.GetPatient(id);

            if (existingPatient == null)
            {
                Console.WriteLine("Пациент с таким номером не найден!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Текущие данные пациента:");
            ShowPatient(existingPatient);

            Console.WriteLine();
            Console.WriteLine("Введите новые данные (нажмите клавишу Enter, чтобы оставить поля без изменений).");
            Console.WriteLine();

            Patient updatedPatient = new Patient
            {
                Id = existingPatient.Id,
                FirstName = existingPatient.FirstName,
                LastName = existingPatient.LastName,
                Patronymic = existingPatient.Patronymic,
                Gender = existingPatient.Gender,
                Diagnosis = existingPatient.Diagnosis,
                Department = existingPatient.Department,
                TreatmentStatus = existingPatient.TreatmentStatus
            };

            Console.Write($"Имя ({existingPatient.FirstName}): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.FirstName = input;
            }

            Console.Write($"Фамилия ({existingPatient.LastName}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.LastName = input;
            }

            Console.Write($"Отчество ({existingPatient.Patronymic}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.Patronymic = input;
            }

            Console.WriteLine();
            Console.WriteLine($"Текущий пол: {GetGenderName(existingPatient.Gender)}");
            Console.WriteLine("Выберите пол:");
            Console.WriteLine("1. Мужской");
            Console.WriteLine("2. Женский");
            Console.Write("Ваш выбор (нажмите клавишу Enter, чтобы оставить поле без изменений): ");

            string genderChoice = Console.ReadLine();

            if (genderChoice == "1")
            {
                updatedPatient.Gender = Gender.Male;
            }
            else if (genderChoice == "2")
            {
                updatedPatient.Gender = Gender.Female;
            }

            Console.WriteLine();

            Console.Write($"Диагноз ({existingPatient.Diagnosis}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.Diagnosis = input;
            }

            Console.Write($"Отделение ({existingPatient.Department}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.Department = input;
            }

            Console.Write($"Статус лечения ({existingPatient.TreatmentStatus}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                updatedPatient.TreatmentStatus = input;
            }

            try
            {
                logic.UpdatePatient(updatedPatient);

                Console.WriteLine();
                Console.WriteLine("Данные пациента успешно изменены!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void DeletePatient(Logic.Logic logic)
        {
            Console.WriteLine("Удаление пациента из системы:");
            Console.WriteLine();

            Console.Write("Введите номер пациента: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Номер должен быть числом!");
                return;
            }

            Patient patient = logic.GetPatient(id);

            if (patient == null)
            {
                Console.WriteLine("Пациент с таким номером не найден!");
                return;
            }

            Console.WriteLine();
            ShowPatient(patient);

            Console.WriteLine();
            Console.Write("Удалить этого пациента? (да/нет): ");

            string answer = Console.ReadLine();

            if (answer.ToLower() == "да")
            {
                bool deleted = logic.DeletePatient(id);

                if (deleted)
                {
                    Console.WriteLine("Пациент удалён.");
                }
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
            }
        }

        static void GroupPatientsByDiagnosis(Logic.Logic logic)
        {
            Console.WriteLine("Количество пациентов с диагнозами:");
            Console.WriteLine();

            Dictionary<string, List<Patient>> groups =
                logic.GroupByDiagnosis();

            if (groups.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine("Диагноз: " + group.Key);

                foreach (Patient patient in group.Value)
                {
                    Console.WriteLine(
                        "  " +
                        patient.LastName + " " +
                        patient.FirstName + " " +
                        patient.Patronymic +
                        " (Id: " + patient.Id + ")");
                }

                Console.WriteLine();
            }
        }

        static void CountPatientsByDepartment(Logic.Logic logic)
        {
            Console.WriteLine("Количество пациентов в отделениях:");
            Console.WriteLine();

            Dictionary<string, int> departments =
                logic.CountPatientsByDepartment();

            if (departments.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            foreach (var department in departments)
            {
                Console.WriteLine(
                    department.Key + ": " +
                    department.Value + " пациент(ов)");
            }
        }

        static void ShowPatient(Patient patient)
        {
            Console.WriteLine("Номер: " + patient.Id);
            Console.WriteLine(
                "ФИО: " +
                patient.LastName + " " +
                patient.FirstName + " " +
                patient.Patronymic);
            Console.WriteLine("Пол: " + GetGenderName(patient.Gender));
            Console.WriteLine("Диагноз: " + patient.Diagnosis);
            Console.WriteLine("Отделение: " + patient.Department);
            Console.WriteLine("Статус лечения: " + patient.TreatmentStatus);
            Console.WriteLine();
        }
        static string GetGenderName(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "Мужской";

                case Gender.Female:
                    return "Женский";

                default:
                    return "Не указан";
            }
        }
    }
}