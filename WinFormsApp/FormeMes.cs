using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormeMes : Form
    {
        public FormeMes()
        {
            InitializeComponent();
        }

        private void FormeMes_Load(object sender, EventArgs e)
        {

        }
        public void SetupGrid(string title, string[] columns)
        {
            this.Text = title;
            dataGridViewReport.Columns.Clear();

            foreach (var col in columns)
            {
                dataGridViewReport.Columns.Add(col, col);
            }
        }

        public void AddRow(params object[] values)
        {
            dataGridViewReport.Rows.Add(values);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
