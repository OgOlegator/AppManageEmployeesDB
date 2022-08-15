using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeeplayTestApp
{
    public partial class AddForm : Form
    {
        private MainForm _mainForm;
        private string _mode;
        private SqlConnection _sqlConnection;

        public AddForm(MainForm form, SqlConnection sqlConnection, string mode)             //Конструктор для добавления строки
        {
            InitializeComponent();
            _mainForm = form;
            _mode = mode;
            _sqlConnection = sqlConnection;

            //if(mode == Constants.ModeUpdate)
            //    foreach (var rowEmployee in _mainForm.employeesDataSet.Employees.Where(x => x.Id == id))
            //    {
            //        textBoxName.Text = rowEmployee.Name;
            //        birthdayPicker.Value = rowEmployee.Birthday;
            //        comboBoxJobTitle.Text = rowEmployee.JobTitle;
            //        comboBoxSex.Text = rowEmployee.Sex;
            //        textBoxSubdivision.Text = rowEmployee.Subdivision;
            //    }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var command = 
                new SqlCommand("INSERT INTO [employees] (Name, Birthday, Sex, JobTitle, Subdivision) " +
                $"VALUES (@Name, @Birthday, @Sex, @JobTitle, @Subdivision)", 
                _sqlConnection);

            var date = birthdayPicker.Value.Date;

            command.Parameters.AddWithValue("Name", textBoxName.Text);
            command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Sex", comboBoxSex.Text);
            command.Parameters.AddWithValue("JobTitle", comboBoxJobTitle.Text);
            command.Parameters.AddWithValue("Subdivision", textBoxSubdivision.Text);

            command.ExecuteNonQuery();
            _mainForm.employeesTableAdapter.Update(_mainForm.employeesDataSet);
            _mainForm.dataGridView1.Refresh();
            ClearFields();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            birthdayPicker = null;
            comboBoxSex.Text = "";
            comboBoxJobTitle.Text = "";
            textBoxSubdivision.Text = "";
        }

        private void UpdateDatabase()//DataRow updateRow)
        {
            // _mainForm.employeesDataSet.Employees.Rows.Add(updateRow);
            _mainForm.employeesTableAdapter.Update(_mainForm.employeesDataSet);
            _mainForm.employeesDataSet.Employees.AcceptChanges();
            _mainForm.dataGridView1.Refresh();
        }
    }
}
