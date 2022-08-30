using System;
using System.Windows.Forms;
using DeeplayTestApp.DB;
using DeeplayTestApp;

namespace DeeplayTestApp.Forms
{
    public partial class MainForm : Form
    {
        public JobTitleDirectory DirectoryJobTitles;
        public SubDivisionDirectory DirectorySubDivision;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeesDataSet.Employees". При необходимости она может быть перемещена или удалена.
            employeesTableAdapter.Fill(employeesDataSet.Employees);

            //Заполнение значений выпадающих списков из справочников
            DirectoryJobTitles = new JobTitleDirectory();
            DirectorySubDivision = new SubDivisionDirectory();

            var listJobTitles = DirectoryJobTitles.GetJobTitles();
            var listSubDivisions = DirectorySubDivision.GetSubDivisions();

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
            if (CheckField(comboBoxSubDivision.Text) &&
                CheckField(comboBoxJobTitle.Text))
                employeesTableAdapter.AddAllFilterForDgv(employeesDataSet.Employees, comboBoxSubDivision.Text, comboBoxJobTitle.Text);

            else if (!CheckField(comboBoxSubDivision.Text) &&
                     !CheckField(comboBoxJobTitle.Text))
                employeesTableAdapter.Fill(employeesDataSet.Employees);

            else if (!CheckField(comboBoxSubDivision.Text))
                employeesTableAdapter.AddJobTitleFilterForDgv(employeesDataSet.Employees, comboBoxJobTitle.Text);

            else if (!CheckField(comboBoxJobTitle.Text))
                employeesTableAdapter.AddSubDivisionFilterForDgv(employeesDataSet.Employees, comboBoxSubDivision.Text);

            bool CheckField(string field)
                => field != Constants.FilterAllValues && field != string.Empty;
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            comboBoxJobTitle.Text = string.Empty;
            comboBoxSubDivision.Text = string.Empty;
            employeesTableAdapter.Fill(employeesDataSet.Employees);
        }
    }
}
