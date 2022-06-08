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
                DataRow newRow = main.employeesDataSet1.Tables[0].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                newRow[0] = rc;
                newRow[1] = textBoxName.Text;
                newRow[2] = textBoxBirthday.Text;
                newRow[3] = textBoxSex.Text;
                newRow[4] = textBoxJobTitle.Text;
                newRow[5] = textBoxInformation.Text;
                main.employeesDataSet1.Tables[0].Rows.Add(newRow);
                main.employeesTableAdapter.Update(main.employeesDataSet1.Employees);
                main.employeesDataSet1.Tables[0].AcceptChanges();
                main.dataGridView1.Refresh();
                textBoxName.Text = "";
                textBoxBirthday.Text = "";
                textBoxSex.Text = "";
                textBoxJobTitle.Text = "";
                textBoxInformation.Text = "";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
