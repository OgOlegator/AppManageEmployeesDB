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
        private SqlConnection sqlConnection = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["DeeplayTestApp.Properties.Settings.employeesConnectionString"].ConnectionString);
            sqlConnection.Open();

            //Данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Employees".
            //При необходимости она может быть перемещена или удалена.
            employeesTableAdapter.Fill(employeesDataSet.Employees);
        }

        private void AddButton_Click(object sender, EventArgs e) => AddEmployee();

        private void ChangeButton_Click(object sender, EventArgs e) => ChangeEmployee();

        private void DeleteButton_Click(object sender, EventArgs e) => DeleteEmployee();
    }
}
