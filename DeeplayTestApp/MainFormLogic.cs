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

            
        }

        private void CallAddForm(string mode, int id = 0)
        {
            var addForm = new AddForm(this, _sqlConnection, mode);
            addForm.Owner = this;
            addForm.ShowDialog();
        }

    }
}
