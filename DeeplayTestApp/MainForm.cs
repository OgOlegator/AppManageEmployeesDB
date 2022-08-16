using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace DeeplayTestApp
{
    public partial class MainForm : Form
    {
        public DataBase DB;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DB = new DataBase();

            DB.OpenConnection();

            //Данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Employees".
            //При необходимости она может быть перемещена или удалена.
            employeesTableAdapter.Fill(employeesDataSet.Employees);
            employeesTableAdapter.UpdateCommand(employeesDataSet.Employees);

            DB.CloseConnection();
        }

        private void AddButton_Click(object sender, EventArgs e) => AddEmployee();

        private void ChangeButton_Click(object sender, EventArgs e) => ChangeEmployee();

        private void DeleteButton_Click(object sender, EventArgs e) => DeleteEmployee();

        private void updateCommandToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.employeesTableAdapter.UpdateCommand(this.employeesDataSet.Employees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
