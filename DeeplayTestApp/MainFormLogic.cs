using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeeplayTestApp
{
    public partial class MainForm
    {
        private void AddEmployee()
        {
            CallAddForm(Constants.ModeAdd);
        }

        private void ChangeEmployee()
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Не выбрана строка для изменения");
                return;
            }

            var id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            
            CallAddForm(Constants.ModeUpdate, id);
        }

        private void DeleteEmployee()
        {
            DialogResult dr = MessageBox.Show("Удалить запись?",
                                  "Удаление",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Warning,
                                  MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Cancel)
                return;

            //Фактически будет только 1 строка так как свойство MultiSelect для DataGridView отключено
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
                employeesTableAdapter.Update(employeesDataSet);
                employeesDataSet.Employees.AcceptChanges();
                dataGridView1.Refresh();
            }
        }

        private void CallAddForm(string mode, int id = 0)
        {
            AddForm addForm = mode == Constants.ModeUpdate ?
                new AddForm(this, mode, id) :
                new AddForm(this, mode);

            addForm.Owner = this;
            addForm.ShowDialog();
        }

    }
}
