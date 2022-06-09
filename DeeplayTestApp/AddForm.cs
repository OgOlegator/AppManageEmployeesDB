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
            Form1 main = Owner as Form1;
            if (main != null)
            {
                DataRow newRow = main.employeesDataSet.Employees.NewRow();

                int id;
                try
                {
                    id = main.employeesDataSet.Employees.Max(x => x.Id) + 1;
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

                if (comboBoxJobTitle.Text == "Руководитель")
                    newRow[5] = textBoxSubdivision.Text;
                else
                {
                    newRow[5] = textBoxSubdivision.Text;
                    //newRow[5] = main.employeesDataSet.Employees.
                    //    Where(x => x.AdditionalInformation == textBoxSubdivision.Text).Select(x => x.Name);
                }
                newRow[6] = textBoxSubdivision.Text;

                main.employeesDataSet.Employees.Rows.Add(newRow);
                main.employeesTableAdapter.Update(main.employeesDataSet);
                main.employeesDataSet.Employees.AcceptChanges(); 
                main.dataGridView1.Refresh();
                textBoxName.Text = "";
                textBoxBirthday.Text = "";
                comboBoxSex.Text = "";
                comboBoxJobTitle.Text = "";
                textBoxSubdivision.Text = "";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
