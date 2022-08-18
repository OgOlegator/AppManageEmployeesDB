using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeeplayTestApp
{
    public partial class MainForm
    {
        private void AddEmployee()
        {
            CallAddForm(Constants.Mode.Create);
        }

        private void ChangeEmployee()
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Не выбрана строка для изменения");
                return;
            }
            
            CallAddForm(Constants.Mode.Change);
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

            var command = new SqlCommand($"delete from [employees] where Id = {id}", ConnectDB.GetConnection());

            UpdateDB(command);
        }

        private void CallAddForm(Constants.Mode mode, DataGridViewRow dataRow = null)
            => new AddForm(this, mode).ShowDialog();
        

        public void UpdateDB(SqlCommand command)
        {
            if (ConnectDB == null)
                return;

            ConnectDB.OpenConnection();
            command.ExecuteNonQuery();
            employeesTableAdapter.UpdateCommand(employeesDataSet.Employees);
            ConnectDB.CloseConnection();
        }

        public void FillDB()
        {
            if (ConnectDB == null)
                return;

            ConnectDB.OpenConnection();
            employeesTableAdapter.Fill(employeesDataSet.Employees);
            ConnectDB.CloseConnection();
        }
    }
}
