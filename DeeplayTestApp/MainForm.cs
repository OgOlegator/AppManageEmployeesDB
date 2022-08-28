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
        private JobTitleDirectory _directoryJobTitles;
        private SubDivisionDirectory _directorySubDivision;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Employees". При необходимости она может быть перемещена или удалена.
            employeesTableAdapter.Fill(employeesDataSet.Employees);

            //Заполнение значений выпадающих списков из справочников
            _directoryJobTitles = new JobTitleDirectory();
            _directorySubDivision = new SubDivisionDirectory();

            var listJobTitles = _directoryJobTitles.GetJobTitles();
            var listSubDivisions = _directorySubDivision.GetDirectorySubDivison();

            listJobTitles.Add(Constants.FilterAllValues);
            listSubDivisions.Add(Constants.FilterAllValues);

            comboBoxJobTitle.Items.AddRange(listJobTitles.ToArray());
            comboBoxSubDivision.Items.AddRange(listSubDivisions.ToArray());
        }

        private void AddButton_Click(object sender, EventArgs e) => AddEmployee();

        private void ChangeButton_Click(object sender, EventArgs e) => ChangeEmployee();

        private void DeleteButton_Click(object sender, EventArgs e) => DeleteEmployee();

        private void StartFilterButton_Click(object sender, EventArgs e)
        {
            if (comboBoxSubDivision.Text != Constants.FilterAllValues &&
                comboBoxJobTitle.Text != Constants.FilterAllValues)
                employeesTableAdapter.AddAllFilterForDgv(employeesDataSet.Employees, comboBoxSubDivision.Text, comboBoxJobTitle.Text);

            else if (comboBoxSubDivision.Text == Constants.FilterAllValues)
                employeesTableAdapter.AddJobTitleFilterForDgv(employeesDataSet.Employees, comboBoxJobTitle.Text);

            else if (comboBoxJobTitle.Text == Constants.FilterAllValues)
                employeesTableAdapter.AddSubDivisionFilterForDgv(employeesDataSet.Employees, comboBoxSubDivision.Text);
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
            => employeesTableAdapter.Fill(employeesDataSet.Employees);
    }
}
