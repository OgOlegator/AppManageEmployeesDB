using DeeplayTestApp.DB;
using DeeplayTestApp.DB.employeesDataSetTableAdapters;
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
    public partial class AuthorizationForm : Form
    {
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var loginString = LoginTextBox.Text;
            var passwordString = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(loginString) || string.IsNullOrEmpty(passwordString))
            {
                MessageBox.Show("Не заполнен логин или пароль");
                return;
            }

            try
            {
                var dataProfile = _usersTableAdapter.GetData(loginString, passwordString);

                if (dataProfile.Rows.Count <= 0)
                    throw new Exception();
                
            }
            catch
            {
                MessageBox.Show("Не удалось войти");
                return;
            }

            Close();

            new MainForm();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
                PasswordTextBox.PasswordChar = '\0';
            else if (!checkBoxShowPassword.Checked)
                PasswordTextBox.PasswordChar = '•';
        }
    }
}
