using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Logic.Logic logic = new Logic.Logic();

        public Form1()
        {
            InitializeComponent();
            comboBoxGender.Items.Add("Не выбран");
            comboBoxGender.Items.Add("Мужской");
            comboBoxGender.Items.Add("Женский");

            comboBoxGender.SelectedIndex = 0;

            LoadPatients();
        }

        private void LoadPatients()
        {
            dataGridViewPatients.Rows.Clear();

            List<Patient> patients = logic.GetAllPatients();

            foreach (Patient patient in patients)
            {
                dataGridViewPatients.Rows.Add(
                    patient.Id,
                    patient.LastName,
                    patient.FirstName,
                    patient.Patronymic,
                    GetGenderName(patient.Gender),
                    patient.Diagnosis,
                    patient.Department,
                    patient.TreatmentStatus
                );
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Patient patient = GetPatientFromForm();

            try
            {
                logic.AddPatient(patient);

                LoadPatients();
                ClearForm();

                MessageBox.Show(
                    "Пациент успешно добавлен.",
                    "Добавление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out int id))
            {
                MessageBox.Show(
                    "Выберите пациента из таблицы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Patient patient = GetPatientFromForm();
            patient.Id = id;

            try
            {
                logic.UpdatePatient(patient);

                LoadPatients();
                ClearForm();

                MessageBox.Show(
                    "Данные пациента изменены.",
                    "Изменение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out int id))
            {
                MessageBox.Show(
                    "Выберите пациента из таблицы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить выбранного пациента?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool deleted = logic.DeletePatient(id);

                if (deleted)
                {
                    LoadPatients();
                    ClearForm();

                    MessageBox.Show(
                        "Пациент удалён.",
                        "Удаление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxSearch.Text, out int id))
            {
                MessageBox.Show(
                    "Введите корректный номер!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Patient patient = logic.GetPatient(id);

            if (patient == null)
            {
                MessageBox.Show(
                    "Пациент с таким номером не найден!",
                    "Поиск",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ShowPatientInForm(patient);
        }

        private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridViewPatients.Rows[e.RowIndex];

            textBoxId.Text = row.Cells[0].Value?.ToString();
            textBoxLastName.Text = row.Cells[1].Value?.ToString();
            textBoxFirstName.Text = row.Cells[2].Value?.ToString();
            textBoxPatronymic.Text = row.Cells[3].Value?.ToString();
            textBoxDiagnosis.Text = row.Cells[5].Value?.ToString();
            textBoxDepartment.Text = row.Cells[6].Value?.ToString();
            textBoxTreatmentStatus.Text = row.Cells[7].Value?.ToString();

            string gender = row.Cells[4].Value?.ToString();

            if (gender == "Мужской")
            {
                comboBoxGender.SelectedIndex = 1;
            }
            else if (gender == "Женский")
            {
                comboBoxGender.SelectedIndex = 2;
            }
            else
            {
                comboBoxGender.SelectedIndex = 0;
            }
        }

        private void buttonGroupDiagnosis_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<Patient>> groups = logic.GroupByDiagnosis();

            if (groups.Count == 0)
            {
                MessageBox.Show("Список пациентов пуст.");
                return;
            }

            string result = "Пациенты по диагнозам:\n\n";

            foreach (var group in groups)
            {
                result += "Диагноз: " + group.Key + "\n";

                foreach (Patient patient in group.Value)
                {
                    result += "  - " +
                              patient.LastName + " " +
                              patient.FirstName +
                              " (Id: " + patient.Id + ")\n";
                }

                result += "\n";
            }

            MessageBox.Show(
                result,
                "Группировка по диагнозу",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonCountDepartment_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> departments = logic.CountPatientsByDepartment();

            if (departments.Count == 0)
            {
                MessageBox.Show("Список пациентов пуст.");
                return;
            }

            string result = "Количество пациентов по отделениям:\n\n";

            foreach (var department in departments)
            {
                result += department.Key +
                          ": " +
                          department.Value +
                          "\n";
            }

            MessageBox.Show(
                result,
                "Пациенты по отделениям",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private Patient GetPatientFromForm()
        {
            Patient patient = new Patient();

            patient.FirstName = textBoxFirstName.Text.Trim();
            patient.LastName = textBoxLastName.Text.Trim();
            patient.Patronymic = textBoxPatronymic.Text.Trim();
            patient.Diagnosis = textBoxDiagnosis.Text.Trim();
            patient.Department = textBoxDepartment.Text.Trim();
            patient.TreatmentStatus = textBoxTreatmentStatus.Text.Trim();

            if (comboBoxGender.SelectedIndex == 1)
            {
                patient.Gender = Gender.Male;
            }
            else if (comboBoxGender.SelectedIndex == 2)
            {
                patient.Gender = Gender.Female;
            }
            else
            {
                patient.Gender = Gender.NotSelected;
            }

            return patient;
        }

        private void ShowPatientInForm(Patient patient)
        {
            textBoxId.Text = patient.Id.ToString();
            textBoxFirstName.Text = patient.FirstName;
            textBoxLastName.Text = patient.LastName;
            textBoxPatronymic.Text = patient.Patronymic;
            textBoxDiagnosis.Text = patient.Diagnosis;
            textBoxDepartment.Text = patient.Department;
            textBoxTreatmentStatus.Text = patient.TreatmentStatus;

            if (patient.Gender == Gender.Male)
            {
                comboBoxGender.SelectedIndex = 1;
            }
            else if (patient.Gender == Gender.Female)
            {
                comboBoxGender.SelectedIndex = 2;
            }
            else
            {
                comboBoxGender.SelectedIndex = 0;
            }
        }

        private void ClearForm()
        {
            textBoxId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPatronymic.Clear();
            textBoxDiagnosis.Clear();
            textBoxDepartment.Clear();
            textBoxTreatmentStatus.Clear();

            comboBoxGender.SelectedIndex = 0;

            textBoxFirstName.Focus();
        }

        private string GetGenderName(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "Мужской";

                case Gender.Female:
                    return "Женский";

                default:
                    return "Не выбран";
            }
        }
    }
}
