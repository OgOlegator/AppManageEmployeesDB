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
