using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace КР_УБД_V_1._0
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=kursach");

        public void OpenConnect()
        {
            if(connection.State==System.Data.ConnectionState.Closed) connection.Open();
        }

        public void ClodeConnect()
        {
            if (connection.State == System.Data.ConnectionState.Open) connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
