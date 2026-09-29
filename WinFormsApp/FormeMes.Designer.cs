namespace WinFormsApp
{
    partial class FormeMes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewReport = new DataGridView();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Dock = DockStyle.Fill;
            dataGridViewReport.Location = new Point(0, 0);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.RowHeadersVisible = false;
            dataGridViewReport.RowHeadersWidth = 51;
            dataGridViewReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReport.Size = new Size(800, 450);
            dataGridViewReport.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.Dock = DockStyle.Bottom;
            buttonClose.Location = new Point(0, 421);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(800, 29);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormeMes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClose);
            Controls.Add(dataGridViewReport);
            Name = "FormeMes";
            Text = "Список";
            Load += FormeMes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewReport;
        private Button buttonClose;
    }
}