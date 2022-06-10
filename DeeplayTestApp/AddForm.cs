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
    public partial class AddForm : Form
    {
        private Form1 _mainForm;
        private string _mode;
        private int _IdRowUpdate;

        public AddForm(Form1 form, string mode)
        {
            InitializeComponent();
            _mainForm = form;
            _mode = mode;

            if(_mode == Constants.ModeUpdate)
            {
                if (_mainForm.dataGridView1.SelectedRows == null)
                {
                    MessageBox.Show("Не выбрана строка для изменения");
                    Close();
                }

                foreach(employeesDataSet.EmployeesRow row in _mainForm.dataGridView1.SelectedRows)
                {
                    _IdRowUpdate = row.Id;
                    textBoxName.Text = row.Name;
                    textBoxBirthday.Text = row.Birthday.ToString();
                    comboBoxJobTitle.Text = row.JobTitle;
                    comboBoxSex.Text = row.Sex;
                    textBoxSubdivision.Text = row.Subdivision;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = _mainForm.employeesDataSet.Employees.NewRow();

            newRow[0] = _mode == Constants.ModeUpdate ? _IdRowUpdate : GetNewId();
            newRow[1] = textBoxName.Text;
            newRow[2] = textBoxBirthday.Text;
            newRow[3] = comboBoxSex.Text;
            newRow[4] = comboBoxJobTitle.Text;

            if (comboBoxJobTitle.Text == Constants.Supervisor)
            {
                var subdivision = _mainForm.employeesDataSet.Employees
                    .Where(x => x.Subdivision == textBoxSubdivision.Text).Select(x => x.JobTitle == Constants.Supervisor);
                if (subdivision.Count() == 0)
                    newRow[5] = textBoxSubdivision.Text;
                else
                {
                    MessageBox.Show("В этом отделе уже есть руководитель");
                    return;
                }
            }
            else if (comboBoxJobTitle.Text == Constants.Director)
            {
                newRow[5] = "";
            }
            else
            {
                try
                {
                    newRow[5] = _mainForm.employeesDataSet.Employees.
                                 FirstOrDefault(x => x.AdditionalInformation == textBoxSubdivision.Text)?.Name;
                }
                catch
                {
                    newRow[5] = "";
                }
            }
            newRow[6] = textBoxSubdivision.Text;

            UpdateDatabase(newRow);
            ClearFields();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            textBoxBirthday.Text = "";
            comboBoxSex.Text = "";
            comboBoxJobTitle.Text = "";
            textBoxSubdivision.Text = "";
        }

        private void UpdateDatabase(DataRow updateRow)
        {
            _mainForm.employeesDataSet.Employees.Rows.Add(updateRow);
            _mainForm.employeesTableAdapter.Update(_mainForm.employeesDataSet);
            _mainForm.employeesDataSet.Employees.AcceptChanges();
            _mainForm.dataGridView1.Refresh();
        }

        private int GetNewId()
        {
            int id;
            try
            {
                id = _mainForm.employeesDataSet.Employees.Max(x => x.Id) + 1;
            }
            catch
            {
                id = 1;
            }
            return id;
        }
    }
}
