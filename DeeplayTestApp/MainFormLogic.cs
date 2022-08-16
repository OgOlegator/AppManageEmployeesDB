using System;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            var rowDeleted = dataGridView1.SelectedRows[0];
            var id = Convert.ToInt32(rowDeleted.Cells[0].Value);

            var command = new SqlCommand($"delete from [employees] where Id = {id}", DB.GetConnection());

            DB.OpenConnection();
            command.ExecuteNonQuery();

            employeesTableAdapter.Update(employeesDataSet.Employees);
            employeesTableAdapter.UpdateCommand(employeesDataSet.Employees);

            DB.CloseConnection();
        }

        private void CallAddForm(string mode, int id = 0)
        {
            var addForm = new AddForm(this, mode);
            addForm.Owner = this;
            addForm.ShowDialog();
        }

    }
}
