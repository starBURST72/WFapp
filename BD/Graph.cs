using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace КР_УБД_V_1._0
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
            
            MySqlCommand command = new MySqlCommand("SELECT clients.CLient_id,reis.Date_go FROM `clients` JOIN `route` ON clients.Route_id=route.Route_id JOIN `reis` ON route.Reis_id=reis.Reis_id ;", dB.GetConnection());
            dB.OpenConnect();
            using (var reader = command.ExecuteReader())
                while (reader.Read())
                {
                    chart1.Series["Спрос"].Points.AddXY(reader[1].ToString(), reader[0].ToString());
                }
        }
        public void chart()
        {
            try
            { }
            catch(Exception)
            {
                throw;
            }
            finally { }
        }
    }
}
