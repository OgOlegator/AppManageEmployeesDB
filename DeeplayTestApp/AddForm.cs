using System;
using System.Linq;
using System.Windows.Forms;
using DeeplayTestApp.DB;

namespace DeeplayTestApp
{
    public partial class AddForm : Form
    {
        private MainForm _mainForm;
        private int _idChangeRow;
        private Constants.Mode _mode;

        public AddForm(MainForm form, Constants.Mode mode)             
        {
            InitializeComponent();
            _mainForm = form;
            _mode = mode;

            SetComboBoxFieldsFromDb();

            if (_mode == Constants.Mode.Change)
            {
                var dataRow = _mainForm.dataGridView1.CurrentRow;

                if (dataRow == null)
                {
                    MessageBox.Show("Выберите строку для изменения");
                    Close();
                    return;
                }

                _idChangeRow = (int)dataRow.Cells[0].Value;
                textBoxName.Text = (string)dataRow.Cells[1].Value;
                birthdayPicker.Value = (DateTime)dataRow.Cells[2].Value;
                comboBoxSex.Text = (string)dataRow.Cells[3].Value;
                comboBoxJobTitle.Text = (string)dataRow.Cells[4].Value;
                comboBoxSubDivision.Text = (string)dataRow.Cells[5].Value;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            switch(_mode)
            {
                case Constants.Mode.Create:
                    {
                        _mainForm.employeesTableAdapter.Insert(textBoxName.Text, birthdayPicker.Value.Date,
                                                               comboBoxSex.Text, comboBoxJobTitle.Text,
                                                               comboBoxSubDivision.Text);
                        break;
                    }
                case Constants.Mode.Change:
                    {
                        _mainForm.employeesTableAdapter.UpdateQuery(textBoxName.Text, birthdayPicker.Value.Date.ToString(),
                                                               comboBoxSex.Text, comboBoxJobTitle.Text,
                                                               comboBoxSubDivision.Text, _idChangeRow);
                        break;
                    }
            }

            _mainForm.employeesTableAdapter.Fill(_mainForm.employeesDataSet.Employees);

            ClearFields();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            birthdayPicker.Value = DateTime.Today;
            comboBoxSex.Text = "";
            comboBoxJobTitle.Text = "";
            comboBoxSubDivision.Text = "";
        }

        private void SetComboBoxFieldsFromDb()
        {
            //Заполнение значений выпадающих списков из справочников
            var directoryJobTitles = new JobTitleDirectory();
            var directorySubDivision = new SubDivisionDirectory();

            comboBoxJobTitle.Items.AddRange(directoryJobTitles.GetJobTitles().ToArray());
            comboBoxSubDivision.Items.AddRange(directorySubDivision.GetSubDivisions().ToArray());
        }
    }
}
