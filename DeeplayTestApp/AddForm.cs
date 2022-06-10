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
        public AddForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var mainForm = Owner as Form1; 
            DataRow newRow = mainForm.employeesDataSet.Employees.NewRow();
            if (mainForm == null)
                return;
            
            int id;
            try
            {
                id = mainForm.employeesDataSet.Employees.Max(x => x.Id) + 1;
            }
            catch
            {
                id = 1;
            }

            newRow[0] = id;
            newRow[1] = textBoxName.Text;
            newRow[2] = textBoxBirthday.Text;
            newRow[3] = comboBoxSex.Text;
            newRow[4] = comboBoxJobTitle.Text;

            if (comboBoxJobTitle.Text == Constants.Supervisor)
            {
                var subdivision = mainForm.employeesDataSet.Employees
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
                    newRow[5] = mainForm.employeesDataSet.Employees.
                                 FirstOrDefault(x => x.AdditionalInformation == textBoxSubdivision.Text)?.Name;
                }
                catch
                {
                    newRow[5] = "";
                }
            }
            newRow[6] = textBoxSubdivision.Text;

            mainForm.employeesDataSet.Employees.Rows.Add(newRow);
            mainForm.employeesTableAdapter.Update(mainForm.employeesDataSet);
            mainForm.employeesDataSet.Employees.AcceptChanges();
            mainForm.dataGridView1.Refresh();
            textBoxName.Text = "";
            textBoxBirthday.Text = "";
            comboBoxSex.Text = "";
            comboBoxJobTitle.Text = "";
            textBoxSubdivision.Text = "";
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
