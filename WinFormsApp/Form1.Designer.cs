namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewPatients;

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.Label labelTreatmentStatus;

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.TextBox textBoxDiagnosis;
        private System.Windows.Forms.TextBox textBoxDepartment;
        private System.Windows.Forms.TextBox textBoxTreatmentStatus;

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClear;

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;

        private System.Windows.Forms.Button buttonGroupDiagnosis;
        private System.Windows.Forms.Button buttonCountDepartment;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dataGridViewPatients = new System.Windows.Forms.DataGridView();
            this.labelId = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelDiagnosis = new System.Windows.Forms.Label();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.labelTreatmentStatus = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.textBoxDiagnosis = new System.Windows.Forms.TextBox();
            this.textBoxDepartment = new System.Windows.Forms.TextBox();
            this.textBoxTreatmentStatus = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonGroupDiagnosis = new System.Windows.Forms.Button();
            this.buttonCountDepartment = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).BeginInit();
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(780, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система учёта пациентов";
            this.Name = "Form1";

            this.buttonAdd.Location = new System.Drawing.Point(20, 20);
            this.buttonAdd.Size = new System.Drawing.Size(110, 32);
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            this.buttonUpdate.Location = new System.Drawing.Point(140, 20);
            this.buttonUpdate.Size = new System.Drawing.Size(110, 32);
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);

            this.buttonDelete.Location = new System.Drawing.Point(260, 20);
            this.buttonDelete.Size = new System.Drawing.Size(110, 32);
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            this.buttonClear.Location = new System.Drawing.Point(380, 20);
            this.buttonClear.Size = new System.Drawing.Size(110, 32);
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);

            this.textBoxSearch.Location = new System.Drawing.Point(500, 25);
            this.textBoxSearch.Size = new System.Drawing.Size(140, 23);

            this.buttonSearch.Location = new System.Drawing.Point(650, 20);
            this.buttonSearch.Size = new System.Drawing.Size(110, 32);
            this.buttonSearch.Text = "Найти по номеру";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(20, 78);
            this.labelId.Text = "Номер:";
            this.textBoxId.Location = new System.Drawing.Point(100, 75);
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(200, 23);
            this.textBoxId.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(20, 110);
            this.labelLastName.Text = "Фамилия:";
            this.textBoxLastName.Location = new System.Drawing.Point(100, 107);
            this.textBoxLastName.Size = new System.Drawing.Size(200, 23);

            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(20, 142);
            this.labelFirstName.Text = "Имя:";
            this.textBoxFirstName.Location = new System.Drawing.Point(100, 139);
            this.textBoxFirstName.Size = new System.Drawing.Size(200, 23);

            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Location = new System.Drawing.Point(20, 174);
            this.labelPatronymic.Text = "Отчество:";
            this.textBoxPatronymic.Location = new System.Drawing.Point(100, 171);
            this.textBoxPatronymic.Size = new System.Drawing.Size(200, 23);

            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(20, 206);
            this.labelGender.Text = "Пол:";
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Location = new System.Drawing.Point(100, 203);
            this.comboBoxGender.Size = new System.Drawing.Size(200, 23);

            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Location = new System.Drawing.Point(340, 78);
            this.labelDiagnosis.Text = "Диагноз:";
            this.textBoxDiagnosis.Location = new System.Drawing.Point(460, 75);
            this.textBoxDiagnosis.Size = new System.Drawing.Size(300, 23);

            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Location = new System.Drawing.Point(340, 110);
            this.labelDepartment.Text = "Отделение:";
            this.textBoxDepartment.Location = new System.Drawing.Point(460, 107);
            this.textBoxDepartment.Size = new System.Drawing.Size(300, 23);

            this.labelTreatmentStatus.AutoSize = true;
            this.labelTreatmentStatus.Location = new System.Drawing.Point(340, 142);
            this.labelTreatmentStatus.Text = "Статус лечения:";
            this.textBoxTreatmentStatus.Location = new System.Drawing.Point(460, 139);
            this.textBoxTreatmentStatus.Size = new System.Drawing.Size(300, 23);

            this.dataGridViewPatients.AllowUserToAddRows = false;
            this.dataGridViewPatients.AllowUserToDeleteRows = false;
            this.dataGridViewPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPatients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridViewPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatients.Location = new System.Drawing.Point(20, 260);
            this.dataGridViewPatients.Name = "dataGridViewPatients";
            this.dataGridViewPatients.ReadOnly = true;
            this.dataGridViewPatients.RowHeadersVisible = false;
            this.dataGridViewPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatients.Size = new System.Drawing.Size(740, 210);
            this.dataGridViewPatients.TabIndex = 0;
            this.dataGridViewPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatients_CellClick);

            this.dataGridViewPatients.Columns.Add("Id", "Номер");
            this.dataGridViewPatients.Columns.Add("LastName", "Фамилия");
            this.dataGridViewPatients.Columns.Add("FirstName", "Имя");
            this.dataGridViewPatients.Columns.Add("Patronymic", "Отчество");
            this.dataGridViewPatients.Columns.Add("Gender", "Пол");
            this.dataGridViewPatients.Columns.Add("Diagnosis", "Диагноз");
            this.dataGridViewPatients.Columns.Add("Department", "Отделение");
            this.dataGridViewPatients.Columns.Add("TreatmentStatus", "Статус лечения");

            this.buttonGroupDiagnosis.Location = new System.Drawing.Point(20, 490);
            this.buttonGroupDiagnosis.Size = new System.Drawing.Size(230, 32);
            this.buttonGroupDiagnosis.Text = "Группировка по диагнозу";
            this.buttonGroupDiagnosis.UseVisualStyleBackColor = true;
            this.buttonGroupDiagnosis.Click += new System.EventHandler(this.buttonGroupDiagnosis_Click);

            this.buttonCountDepartment.Location = new System.Drawing.Point(260, 490);
            this.buttonCountDepartment.Size = new System.Drawing.Size(250, 32);
            this.buttonCountDepartment.Text = "Количество по отделениям";
            this.buttonCountDepartment.UseVisualStyleBackColor = true;
            this.buttonCountDepartment.Click += new System.EventHandler(this.buttonCountDepartment_Click);

            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);

            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelDiagnosis);
            this.Controls.Add(this.labelDepartment);
            this.Controls.Add(this.labelTreatmentStatus);

            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.textBoxDiagnosis);
            this.Controls.Add(this.textBoxDepartment);
            this.Controls.Add(this.textBoxTreatmentStatus);

            this.Controls.Add(this.dataGridViewPatients);

            this.Controls.Add(this.buttonGroupDiagnosis);
            this.Controls.Add(this.buttonCountDepartment);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}