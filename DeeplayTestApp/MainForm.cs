using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DeeplayTestApp.DB;

namespace DeeplayTestApp
{
    public partial class MainForm : Form
    {
        public Connection ConnectDB;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectDB = new Connection();
            FillDB();
        }

        private void AddButton_Click(object sender, EventArgs e) => AddEmployee();

        private void ChangeButton_Click(object sender, EventArgs e) => ChangeEmployee();

        private void DeleteButton_Click(object sender, EventArgs e) => DeleteEmployee();

    }
}
