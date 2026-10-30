using DataAccessLayer;
using Logic;
using Model;
using Ninject;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{

    public class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            using (var ctx = kernel.Get<PatientDBContext>())
            {
                ctx.Database.EnsureCreated();
            }

            var logic = kernel.Get<ILogic>();

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

                if (choice == "1")
                {
                    ShowAllPatients(logic);
                }
                else if (choice == "2")
                {
                    AddPatient(logic);
                }
                else if (choice == "3")
                {
                    FindPatient(logic);
                }
                else if (choice == "4")
                {
                    UpdatePatient(logic);
                }
                else if (choice == "5")
                {
                    DeletePatient(logic);
                }
                else if (choice == "6")
                {
                    GroupPatientsByDiagnosis(logic);
                }
                else if (choice == "7")
                {
                    CountPatientsByDepartment(logic);
                }
                else if (choice == "0")
                {
                    start = false;
                }
                else
                {
                    Console.WriteLine("Такого пункта меню нет.");
                }

                if (start)
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                    Console.ReadKey();
                }
            }
        }

        static void AddPatient(ILogic logic)
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
                Console.WriteLine("Пациент добавлен. Его номер: " + patient.Id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void ShowAllPatients(ILogic logic)
        {
            Console.WriteLine("Список пациентов: ");
            Console.WriteLine();

            List<Patient> patients = logic.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                ShowPatient(patients[i]);
            }
        }
        static void FindPatient(ILogic logic)
        {
            Console.WriteLine("Поиск пациента в системе:");
            Console.WriteLine();

            Console.Write("Введите номер пациента: ");
            string input = Console.ReadLine();

            int id = 0;
            bool ok = int.TryParse(input, out id);

            if (ok == false)
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

        static void UpdatePatient(ILogic logic)
        {
            Console.WriteLine("Изменение данных о пациенте:");
            Console.WriteLine("Список пациентов:");
            Console.WriteLine();

            List<Patient> patients = logic.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                ShowPatient(patients[i]);
            }

            Console.Write("Введите номер пациента, данные которого хотите изменить: ");
            string input = Console.ReadLine();

            int id = 0;
            bool ok = int.TryParse(input, out id);

            if (ok == false)
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
            Console.WriteLine("Введите новые данные (Enter - оставить как было).");
            Console.WriteLine();

            Patient updatedPatient = new Patient();
            updatedPatient.Id = existingPatient.Id;
            updatedPatient.FirstName = existingPatient.FirstName;
            updatedPatient.LastName = existingPatient.LastName;
            updatedPatient.Patronymic = existingPatient.Patronymic;
            updatedPatient.Gender = existingPatient.Gender;
            updatedPatient.Diagnosis = existingPatient.Diagnosis;
            updatedPatient.Department = existingPatient.Department;
            updatedPatient.TreatmentStatus = existingPatient.TreatmentStatus;

            Console.Write("Имя (" + existingPatient.FirstName + "): ");
            input = Console.ReadLine();
            if (input != "")
            {
                updatedPatient.FirstName = input;
            }

            Console.Write("Фамилия (" + existingPatient.LastName + "): ");
            input = Console.ReadLine();
            if (input != "")
            {
                updatedPatient.LastName = input;
            }

            Console.Write("Отчество (" + existingPatient.Patronymic + "): ");
            input = Console.ReadLine();
            if (input != "")
            {
                updatedPatient.Patronymic = input;
            }

            Console.WriteLine();
            Console.WriteLine("Текущий пол: " + GetGenderName(existingPatient.Gender));
            Console.WriteLine("Выберите пол:");
            Console.WriteLine("1. Мужской");
            Console.WriteLine("2. Женский");
            Console.Write("Ваш выбор (Enter - не менять): ");

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

            Console.Write("Диагноз (" + existingPatient.Diagnosis + "): ");
            input = Console.ReadLine();
            if (input != "")
            {
                updatedPatient.Diagnosis = input;
            }

            Console.Write("Отделение (" + existingPatient.Department + "): ");
            input = Console.ReadLine();
            if (input != "")
            {
                updatedPatient.Department = input;
            }

            Console.Write("Статус лечения (" + existingPatient.TreatmentStatus + "): ");
            input = Console.ReadLine();
            if (input != "")
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

        static void DeletePatient(ILogic logic)
        {

            Console.WriteLine("Удаление пациента из системы:");
            Console.WriteLine("Список пациентов:");
            Console.WriteLine();

            List<Patient> patients = logic.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                ShowPatient(patients[i]);
            }

            Console.WriteLine();

            Console.Write("Введите номер пациента, которого хотите удалить: ");
            string input = Console.ReadLine();

            int id = 0;
            bool ok = int.TryParse(input, out id);

            if (ok == false)
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

            if (answer == "да" || answer == "Да")
            {
                if (logic.DeletePatient(id))
                {
                    Console.WriteLine("Пациент удалён.");
                }
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
            }
        }
        static void GroupPatientsByDiagnosis(ILogic logic)
        {
            Console.WriteLine("Количество пациентов с диагнозами:");
            Console.WriteLine();

            Dictionary<string, List<Patient>> groups = logic.GroupByDiagnosis();

            if (groups.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            foreach (var g in groups)
            {
                Console.WriteLine("Диагноз: " + g.Key);

                foreach (Patient p in g.Value)
                {
                    Console.WriteLine("  " + p.LastName + " " + p.FirstName + " " + p.Patronymic + " (Id: " + p.Id + ")");
                }

                Console.WriteLine();
            }
        }
        static void CountPatientsByDepartment(ILogic logic)
        {
            Console.WriteLine("Количество пациентов в отделениях:");
            Console.WriteLine();

            Dictionary<string, int> deps = logic.CountPatientsByDepartment();

            if (deps.Count == 0)
            {
                Console.WriteLine("Список пациентов пуст!");
                return;
            }

            foreach (var d in deps)
            {
                Console.WriteLine(d.Key + ": " + d.Value + " пациент(ов)");
            }
        }

        static void ShowPatient(Patient patient)
        {
            Console.WriteLine("Номер: " + patient.Id);
            Console.WriteLine("ФИО: " + patient.LastName + " " + patient.FirstName + " " + patient.Patronymic);
            Console.WriteLine("Пол: " + GetGenderName(patient.Gender));
            Console.WriteLine("Диагноз: " + patient.Diagnosis);
            Console.WriteLine("Отделение: " + patient.Department);
            Console.WriteLine("Статус лечения: " + patient.TreatmentStatus);
            Console.WriteLine();
        }

        static string GetGenderName(Gender gender)
        {
            if (gender == Gender.Male)
            {
                return "Мужской";
            }
            else if (gender == Gender.Female)
            {
                return "Женский";
            }
            else
            {
                return "Не указан";
            }
        }
    }
}
