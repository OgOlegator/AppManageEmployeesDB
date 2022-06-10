using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeeplayTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Employees". При необходимости она может быть перемещена или удалена.
            employeesTableAdapter.Fill(this.employeesDataSet.Employees);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this, Constants.ModeAdd);
            addForm.Owner = this;
            addForm.ShowDialog();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this, Constants.ModeUpdate);
            addForm.Owner = this;
            addForm.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?",
                                  "Удаление",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Warning,
                                  MessageBoxDefaultButton.Button2);
            
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            //Фактически будет только 1 строка так как свойство MultiSelect для DataGridView отключено
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                dataGridView1.Rows.Remove(row);
        }
    }
}
