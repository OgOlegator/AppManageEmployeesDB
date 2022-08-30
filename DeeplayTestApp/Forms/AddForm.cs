using System;
using System.Linq;
using System.Windows.Forms;
using DeeplayTestApp.DB;

namespace DeeplayTestApp.Forms
{
    public partial class AddForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly int _idChangeRow;
        private readonly Constants.Mode _mode;

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
            if (!CheckFields())     //Проверка заполненности полей
                return;

            if (!CheckJobTitles())  //Проверка на наличие сотрудников в должности Руководитель(для конкретного отдела) и Директор(для всей компании)
                return;

            switch (_mode)
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
            textBoxName.Text = string.Empty;
            birthdayPicker.Value = DateTime.Today;
            comboBoxSex.Text = string.Empty;
            comboBoxJobTitle.Text = string.Empty;
            comboBoxSubDivision.Text = string.Empty;
        }

        private void SetComboBoxFieldsFromDb()
        {
            //Заполнение значений выпадающих списков из справочников
            comboBoxJobTitle.Items.AddRange(_mainForm.DirectoryJobTitles.GetJobTitles().ToArray());
            comboBoxSubDivision.Items.AddRange(_mainForm.DirectorySubDivision.GetSubDivisions().ToArray());
        }

        private bool CheckFields()
        {
            var message = "Не заполнены поля:";
            var statusCheck = true;

            if (string.IsNullOrEmpty(textBoxName.Text))
            { 
                message += "\n- ФИО";
                statusCheck = false;
            }
            if(string.IsNullOrEmpty(comboBoxSex.Text))
            { 
                message += "\n- Пол";
                statusCheck = false;
            }
            if (string.IsNullOrEmpty(comboBoxJobTitle.Text))
            {
                message += "\n- Должность";
                statusCheck = false;
            }
            if (string.IsNullOrEmpty(comboBoxSubDivision.Text))
            {
                message += "\n- Подразделение";
                statusCheck = false;
            }

            if (!statusCheck)
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return statusCheck;
        }

        private bool CheckJobTitles()
        {   
            switch(comboBoxJobTitle.Text)
            {
                case Constants.Supervisor:
                    if (_mainForm.employeesTableAdapter.ScalarQueryCountEmployeesWithSameJobTitleAndSubdivision
                        (Constants.Supervisor, comboBoxSubDivision.Text) > 0)
                    {
                        MessageBox.Show($"Нельзя добавить еще одного сотрудника в должности {Constants.Supervisor} " +
                            "для выбранного отдела",
                            "Erorr",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    break;
                case Constants.Director:
                    if(_mainForm.employeesTableAdapter.ScalarQueryCountEmployeesJobTitle(Constants.Director) > 0)
                    {
                        MessageBox.Show($"Нельзя добавить еще одного сотрудника в должности {Constants.Director}",
                            "Erorr", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    break;
            }

            return true;
        }
    }
}
