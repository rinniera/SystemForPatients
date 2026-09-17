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

            int btnY = 20;
            int btnWidth = 110;
            int btnHeight = 32;
            int btnGap = 10;

            this.buttonAdd.Location = new System.Drawing.Point(20, btnY);
            this.buttonAdd.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            this.buttonUpdate.Location = new System.Drawing.Point(20 + (btnWidth + btnGap), btnY);
            this.buttonUpdate.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);

            this.buttonDelete.Location = new System.Drawing.Point(20 + 2 * (btnWidth + btnGap), btnY);
            this.buttonDelete.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            this.buttonClear.Location = new System.Drawing.Point(20 + 3 * (btnWidth + btnGap), btnY);
            this.buttonClear.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);

            this.textBoxSearch.Location = new System.Drawing.Point(500, btnY + 5);
            this.textBoxSearch.Size = new System.Drawing.Size(140, 23);

            this.buttonSearch.Location = new System.Drawing.Point(650, btnY);
            this.buttonSearch.Size = new System.Drawing.Size(110, btnHeight);
            this.buttonSearch.Text = "Найти по номеру";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            int leftLabelX = 20;
            int leftBoxX = 100;
            int boxWidthLeft = 200;

            int rightLabelX = 340;
            int rightBoxX = 460;
            int boxWidthRight = 300;

            int rowY = 75;
            int rowStep = 32;

            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(leftLabelX, rowY + 3);
            this.labelId.Text = "Номер:";
            this.textBoxId.Location = new System.Drawing.Point(leftBoxX, rowY);
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(boxWidthLeft, 23);
            this.textBoxId.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(leftLabelX, rowY + rowStep + 3);
            this.labelLastName.Text = "Фамилия:";
            this.textBoxLastName.Location = new System.Drawing.Point(leftBoxX, rowY + rowStep);
            this.textBoxLastName.Size = new System.Drawing.Size(boxWidthLeft, 23);

            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(leftLabelX, rowY + 2 * rowStep + 3);
            this.labelFirstName.Text = "Имя:";
            this.textBoxFirstName.Location = new System.Drawing.Point(leftBoxX, rowY + 2 * rowStep);
            this.textBoxFirstName.Size = new System.Drawing.Size(boxWidthLeft, 23);

            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Location = new System.Drawing.Point(leftLabelX, rowY + 3 * rowStep + 3);
            this.labelPatronymic.Text = "Отчество:";
            this.textBoxPatronymic.Location = new System.Drawing.Point(leftBoxX, rowY + 3 * rowStep);
            this.textBoxPatronymic.Size = new System.Drawing.Size(boxWidthLeft, 23);

            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(leftLabelX, rowY + 4 * rowStep + 3);
            this.labelGender.Text = "Пол:";
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Location = new System.Drawing.Point(leftBoxX, rowY + 4 * rowStep);
            this.comboBoxGender.Size = new System.Drawing.Size(boxWidthLeft, 23);

            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Location = new System.Drawing.Point(rightLabelX, rowY + 3);
            this.labelDiagnosis.Text = "Диагноз:";
            this.textBoxDiagnosis.Location = new System.Drawing.Point(rightBoxX, rowY);
            this.textBoxDiagnosis.Size = new System.Drawing.Size(boxWidthRight, 23);

            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Location = new System.Drawing.Point(rightLabelX, rowY + rowStep + 3);
            this.labelDepartment.Text = "Отделение:";
            this.textBoxDepartment.Location = new System.Drawing.Point(rightBoxX, rowY + rowStep);
            this.textBoxDepartment.Size = new System.Drawing.Size(boxWidthRight, 23);

            this.labelTreatmentStatus.AutoSize = true;
            this.labelTreatmentStatus.Location = new System.Drawing.Point(rightLabelX, rowY + 2 * rowStep + 3);
            this.labelTreatmentStatus.Text = "Статус лечения:";
            this.textBoxTreatmentStatus.Location = new System.Drawing.Point(rightBoxX, rowY + 2 * rowStep);
            this.textBoxTreatmentStatus.Size = new System.Drawing.Size(boxWidthRight, 23);

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

            int analyticsY = 490;

            this.buttonGroupDiagnosis.Location = new System.Drawing.Point(20, analyticsY);
            this.buttonGroupDiagnosis.Size = new System.Drawing.Size(230, 32);
            this.buttonGroupDiagnosis.Text = "Группировка по диагнозу";
            this.buttonGroupDiagnosis.UseVisualStyleBackColor = true;
            this.buttonGroupDiagnosis.Click += new System.EventHandler(this.buttonGroupDiagnosis_Click);

            this.buttonCountDepartment.Location = new System.Drawing.Point(260, analyticsY);
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