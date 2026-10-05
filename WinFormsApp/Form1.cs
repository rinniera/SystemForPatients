using DataAccessLayer;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly IRepository<Patient> repository;
        private readonly Logic.Logic logic;


        public Form1()
        {
            InitializeComponent();

            repository = new EntityRepository<Patient>(); 
            logic = new Logic.Logic(repository);

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

            for (int i = 0; i < patients.Count; i++)
            {
                string pol = "";

                if (patients[i].Gender == Gender.Male)
                    pol = "Мужской";
                else if (patients[i].Gender == Gender.Female)
                    pol = "Женский";
                else
                    pol = "Не выбран";

                dataGridViewPatients.Rows.Add(
                    patients[i].Id,
                    patients[i].LastName,
                    patients[i].FirstName,
                    patients[i].Patronymic,
                    pol,
                    patients[i].Diagnosis,
                    patients[i].Department,
                    patients[i].TreatmentStatus);
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
                MessageBox.Show("Пациент успешно добавлен.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(textBoxId.Text, out id) == false)
            {
                MessageBox.Show("Выберите пациента из таблицы.");
                return;
            }

            Patient patient = GetPatientFromForm();
            patient.Id = id;

            try
            {
                logic.UpdatePatient(patient);
                LoadPatients();
                ClearForm();
                MessageBox.Show("Данные пациента изменены.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(textBoxId.Text, out id) == false)
            {
                MessageBox.Show("Выберите пациента из таблицы.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить выбранного пациента?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (logic.DeletePatient(id))
                {
                    LoadPatients();
                    ClearForm();
                    MessageBox.Show("Пациент удалён.");
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(textBoxSearch.Text, out id) == false)
            {
                MessageBox.Show("Введите корректный номер!");
                return;
            }

            Patient patient = logic.GetPatient(id);

            if (patient == null)
            {
                MessageBox.Show("Пациент с таким номером не найден!");
                return;
            }

            ShowPatientInForm(patient);
        }
        private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            textBoxId.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxLastName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxFirstName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxPatronymic.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxDiagnosis.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxDepartment.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxTreatmentStatus.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[7].Value.ToString();

            string pol = dataGridViewPatients.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (pol == "Мужской")
                comboBoxGender.SelectedIndex = 1;
            else if (pol == "Женский")
                comboBoxGender.SelectedIndex = 2;
            else
                comboBoxGender.SelectedIndex = 0;
        }
        private void buttonGroupDiagnosis_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<Patient>> groups = logic.GroupByDiagnosis();

            if (groups.Count == 0)
            {
                MessageBox.Show("Список пациентов пуст.");
                return;
            }

            FormeMes reportForm = new FormeMes();
            reportForm.SetupGrid("Группировка по диагнозу", new string[] { "Диагноз", "ID", "Фамилия", "Имя" });

            foreach (var g in groups)
            {
                foreach (Patient p in g.Value)
                {
                    reportForm.AddRow(g.Key, p.Id, p.LastName, p.FirstName);
                }
            }

            reportForm.ShowDialog();
        }

        private void buttonCountDepartment_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> deps = logic.CountPatientsByDepartment();

            if (deps.Count == 0)
            {
                MessageBox.Show("Список пациентов пуст.");
                return;
            }

            FormeMes reportForm = new FormeMes();
            reportForm.SetupGrid("Пациенты по отделениям", new string[] { "Отделение", "Количество пациентов" });

            foreach (var d in deps)
            {
                reportForm.AddRow(d.Key, d.Value);
            }

            reportForm.ShowDialog();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private Patient GetPatientFromForm()
        {
            Patient patient = new Patient();

            patient.FirstName = textBoxFirstName.Text;
            patient.LastName = textBoxLastName.Text;
            patient.Patronymic = textBoxPatronymic.Text;
            patient.Diagnosis = textBoxDiagnosis.Text;
            patient.Department = textBoxDepartment.Text;
            patient.TreatmentStatus = textBoxTreatmentStatus.Text;

            if (comboBoxGender.SelectedIndex == 1)
                patient.Gender = Gender.Male;
            else if (comboBoxGender.SelectedIndex == 2)
                patient.Gender = Gender.Female;
            else
                patient.Gender = Gender.NotSelected;

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
                comboBoxGender.SelectedIndex = 1;
            else if (patient.Gender == Gender.Female)
                comboBoxGender.SelectedIndex = 2;
            else
                comboBoxGender.SelectedIndex = 0;
        }
        private void ClearForm()
        {
            textBoxId.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxPatronymic.Text = "";
            textBoxDiagnosis.Text = "";
            textBoxDepartment.Text = "";
            textBoxTreatmentStatus.Text = "";

            comboBoxGender.SelectedIndex = 0;

            textBoxFirstName.Focus();
        }

    }
}