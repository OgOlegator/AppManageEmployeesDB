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
using DeeplayTestApp.DB;

namespace DeeplayTestApp
{
    public partial class MainForm : Form
    {
        public Connection ConnectDB;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Subdivision". При необходимости она может быть перемещена или удалена.
            subdivisionTableAdapter.Fill(employeesDataSet.Subdivision);
            employeesTableAdapter.Fill(employeesDataSet.Employees);
            jobTitle1TableAdapter.Fill(employeesDataSet.JobTitle1);
            
            ConnectDB = new Connection();
        }

        private void AddButton_Click(object sender, EventArgs e) => AddEmployee();

        private void ChangeButton_Click(object sender, EventArgs e) => ChangeEmployee();

        private void DeleteButton_Click(object sender, EventArgs e) => DeleteEmployee();

        private void StartFilterButton_Click(object sender, EventArgs e)
            => employeesTableAdapter.AddFilterWithDgv(employeesDataSet.Employees, comboBoxSubDivision.Text, comboBoxJobTitle.Text);

        private void ClearFilterButton_Click(object sender, EventArgs e)
            => employeesTableAdapter.Fill(employeesDataSet.Employees);
    }
}
