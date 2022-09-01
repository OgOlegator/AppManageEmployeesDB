using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeeplayTestApp.Forms
{
    public partial class ProfileEmployeeForm : Form
    {
        private readonly MainForm _mainForm;

        public ProfileEmployeeForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            //Если не удалось заполнить поля, то форма не откроется
            if(!SetValuesFields())
                return;

            ShowDialog();
        }

        private void PromoteButton_Click(object sender, EventArgs e)
        {
            if(!TryGetNextLevelJobTitle(textBoxJobTitle.Text, textBoxSubDivision.Text, out var newJobTitle))
                return;

            var id = int.Parse(_mainForm.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var sex = _mainForm.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            _mainForm.employeesTableAdapter.UpdateQuery(textBoxName.Text, textBoxBirthday.Text, sex, 
                                                        newJobTitle, textBoxSubDivision.Text, id);

            textBoxJobTitle.Text = newJobTitle;
        }

        private bool TryGetNextLevelJobTitle(string currentJobTitle, string currentSubDivision, out string nextLevelJobTitle)
        {
            if(currentJobTitle == Constants.Director)
            {
                MessageBox.Show($"Нельзя повысить сотрудника находящегося в должности {currentJobTitle}");
                nextLevelJobTitle = "";
                return false;
            }

            var directoryJobTitles = _mainForm.DirectoryJobTitles.GetDirectoryJobTitle();

            var currentLevel = directoryJobTitles.FirstOrDefault(x => x.Name == currentJobTitle).Level;
            nextLevelJobTitle = directoryJobTitles.FirstOrDefault(x => x.Level == currentLevel - 1).Name;

            switch (nextLevelJobTitle)
            {
                case Constants.Supervisor:
                    if (_mainForm.employeesTableAdapter.ScalarQueryCountEmployeesWithSameJobTitleAndSubdivision
                        (currentJobTitle, currentSubDivision) > 0)
                    {
                        MessageBox.Show($"Нельзя повысить сотрудника в должность {nextLevelJobTitle}, так как в этом отделе он уже есть", 
                            "Erorr",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); 

                        return false;
                    }
                    break;
                case Constants.Director:
                    if (_mainForm.employeesTableAdapter.ScalarQueryCountEmployeesJobTitle(currentJobTitle) > 0)
                    {
                        MessageBox.Show($"Нельзя повысить сотрудника в должность {nextLevelJobTitle}, так как уже есть сотрудник с такой должностью",
                            "Erorr",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    break;
                case null:
                    MessageBox.Show($"Ошибка при повышении сотрудника",
                            "Erorr",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }

            return true;
        }

        private bool SetValuesFields()
        {
            var dataRow = _mainForm.dataGridView1.CurrentRow;

            if (dataRow == null)
            {
                MessageBox.Show("Выберите строку для изменения");
                return false;
            }

            textBoxName.Text = (string)dataRow.Cells[1].Value;
            textBoxBirthday.Text = dataRow.Cells[2].Value.ToString();
            textBoxJobTitle.Text = (string)dataRow.Cells[4].Value;
            textBoxSubDivision.Text = (string)dataRow.Cells[5].Value;
            textBoxAdditionalInfo.Text = (string)dataRow.Cells[6].Value;
            textBoxSalary.Text = "salary?";

            return true;
        }
    }
}
