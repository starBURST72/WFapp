using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace КР_УБД_V_1._0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

           MySqlCommand command = new MySqlCommand("SELECT * FROM `perevods` ;", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
             dataGridView1.DataSource = table;
        }



        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelForm form = new DelForm();
            form.Show();
        }

       

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `employees`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void routeУДКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `route`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void reisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `reis`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `planes`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `hotel`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void публикацииПоАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void topRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT route.RouteName,count(clients.Route_id) FROM `clients` JOIN route ON clients.Route_id = route.Route_id GROUP BY route.RouteName;", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void публикацийПоТипуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ID клиента:");
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT clients.Client_id,CONCAT(clients.Surname,' ', clients.Name,' ', clients.Lastname) AS FIO, route.RouteName  FROM `clients` JOIN route ON route.Route_id = clients.Route_id WHERE "+result+" IN (clients.Client_id);", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void публикацийПоМаршToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ID маршрута:");
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT route.Route_id, CONCAT(clients.Surname,' ', clients.Name,' ', clients.Lastname),route.RouteName AS FIO FROM `clients` JOIN route ON route.Route_id = clients.Route_id WHERE " + result + " IN (route.Route_Id);", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void публикацийЗаОпределённыйПериодВыпускаЖурналаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT SUBDATE(reis.Date_go, INTERVAL reis.Date_back DAY), route.RouteName FROM `reis` JOIN route ON route.Reis_id = reis.Reis_id;", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void переводыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `perevods`", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void запрос1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT route.RouteName, CONCAT(employees.Surname,' ', employees.Name,' ', employees.Lastname) AS FIO  FROM `employees` JOIN `route` ON route.Rab_id = employees.Rab_id;", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void поСотрудникуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ID сотрудника:");
            DB dB = new DB();
            DateTime date = DateTime.Now;

            MySqlCommand command = new MySqlCommand("SELECT  CONCAT(employees.Surname,' ', employees.Name,' ', employees.Lastname) AS FIO, perevods.Dolgnost,perevods.Reason,perevods.Date   FROM `employees` JOIN `perevods_employees` ON perevods_employees.Rab_id = employees.Rab_id JOIN `perevods` ON perevods.Perevod_id= perevods_employees.Perevod_id WHERE " + result + " IN (employees.Rab_id);", dB.GetConnection());
            dB.OpenConnect();
            using (var reader = command.ExecuteReader())
            using (var writer = new StreamWriter(@"C:\dump\poSotrudniky_"+date.ToString("d")+"_"+result+".txt"))
            {
                while (reader.Read())
                {
                    writer.WriteLine(reader[0].ToString() + "|" + reader[1].ToString() + "|" + reader[2].ToString() + "|" + reader[3].ToString());
                }
            }
           
        }

        private void последнихРейсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            DB dB = new DB();
            DateTime date = DateTime.Now;

            MySqlCommand command = new MySqlCommand("SELECT reis.Reis_id,route.RouteName,hotel.HotelName FROM `route` JOIN `reis` ON reis.Reis_id = route.Reis_id JOIN `hotel` ON hotel.Hotel_id= route.Hotel_id ORDER BY reis.Reis_id DESC LIMIT 10 ;", dB.GetConnection());
            dB.OpenConnect();
            using (var reader = command.ExecuteReader())
            using (var writer = new StreamWriter(@"C:\dump\10Poslednih_" + date.ToString("d") +".txt"))
            {
                while (reader.Read())
                {
                    writer.WriteLine(reader[0].ToString() + "|" + reader[1].ToString() + "|" + reader[2].ToString());
                }
            }
        }

        private void поМаршрутуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ID маршрута:");
            DB dB = new DB();
            DateTime date = DateTime.Now;

            MySqlCommand command = new MySqlCommand("SELECT route.RouteName,route.Country, route.City FROM `route` WHERE " + result + " IN (route.Route_id);", dB.GetConnection());
            dB.OpenConnect();
            using (var reader = command.ExecuteReader())
            using (var writer = new StreamWriter(@"C:\dump\poMarshrutu_" + date.ToString("d") + "_" + result + ".txt"))
            {
                while (reader.Read())
                {
                    writer.WriteLine(reader[0].ToString() + "|" + reader[1].ToString() + "|" + reader[2].ToString());
                }
            }

        }

        private void поПеревозчикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ID маршрута:");
            DB dB = new DB();
            DateTime date = DateTime.Now;

            MySqlCommand command = new MySqlCommand("SELECT reis.CarrierName,planes.plane_id,planes.Categories FROM `reis` JOIN `planes` ON reis.Plane_id=planes.Plane_id GROUP BY reis.CarrierName;", dB.GetConnection());
            dB.OpenConnect();
            using (var reader = command.ExecuteReader())
            using (var writer = new StreamWriter(@"C:\dump\Perevozchiki_" + date.ToString("d") + "_" + result + ".txt"))
            {
                while (reader.Read())
                {
                    writer.WriteLine(reader[0].ToString() + "|" + reader[1].ToString() + "|" + reader[2].ToString());
                }
            }
        }

        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph form = new Graph();
            form.Show();
        }
    }
}
