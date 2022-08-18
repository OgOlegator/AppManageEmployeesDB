using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeeplayTestApp
{
    public partial class AddForm : Form
    {
        private MainForm _mainForm;
        private int _idChangeRow;
        private Constants.Mode _mode;

        public AddForm(MainForm form, Constants.Mode mode)             //Конструктор для добавления строки
        {
            InitializeComponent();
            _mainForm = form;
            _mode = mode;

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
                textBoxSubdivision.Text = (string)dataRow.Cells[5].Value;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;

            switch(_mode)
            {
                case Constants.Mode.Create:
                    {
                        command = GetCommandCreate();
                        break;
                    }
                case Constants.Mode.Change:
                    {
                        command = GetCommandUpdate();
                        break;
                    }
            }

            _mainForm.UpdateDB(command);

            ClearFields();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            birthdayPicker = null;
            comboBoxSex.Text = "";
            comboBoxJobTitle.Text = "";
            textBoxSubdivision.Text = "";
        }

        private SqlCommand GetCommandCreate()
        {
            var command = new SqlCommand("INSERT INTO [employees] (Name, Birthday, Sex, JobTitle, Subdivision) " +
                                         "VALUES (@Name, @Birthday, @Sex, @JobTitle, @Subdivision)",
                                         _mainForm.ConnectDB.GetConnection());

            var date = birthdayPicker.Value.Date;

            command.Parameters.AddWithValue("Name", textBoxName.Text);
            command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Sex", comboBoxSex.Text);
            command.Parameters.AddWithValue("JobTitle", comboBoxJobTitle.Text);
            command.Parameters.AddWithValue("Subdivision", textBoxSubdivision.Text);

            return command;
        }

        private SqlCommand GetCommandUpdate()
        {
            var command = new SqlCommand("UPDATE [employees] SET Name = @Name, Birthday = @Birthday, Sex = @Sex, JobTitle = @JobTitle, " +
                                                 "Subdivision = @Subdivision WHERE Id = @Id",
                                                 _mainForm.ConnectDB.GetConnection());

            var date = birthdayPicker.Value.Date;

            command.Parameters.AddWithValue("Name", textBoxName.Text);
            command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Sex", comboBoxSex.Text);
            command.Parameters.AddWithValue("JobTitle", comboBoxJobTitle.Text);
            command.Parameters.AddWithValue("Subdivision", textBoxSubdivision.Text);
            command.Parameters.AddWithValue("Id", _idChangeRow);

            return command;
        }
    }
}
