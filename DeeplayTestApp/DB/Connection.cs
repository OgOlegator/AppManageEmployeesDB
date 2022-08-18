using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DeeplayTestApp.DB
{
    public class Connection
    {
        private SqlConnection _sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["DeeplayTestApp.Properties.Settings.employeesConnectionString"].ConnectionString);

        public void OpenConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
                _sqlConnection.Close();
        }

        public SqlConnection GetConnection()
            => _sqlConnection;
    }
}
