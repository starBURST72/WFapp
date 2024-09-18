using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КР_УБД_V_1._0
{
    public partial class RouteAddForm : Form
    {
        public RouteAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `route` ( `Rab_id`,`Hotel_id`,`Reis_id`, `RouteName`,`Country`, `City`) VALUES( @Hotel_id,@Rab_id,@Reis_id,@RouteName,@Country,@City); ", dB.GetConnection());
            command.Parameters.Add("@Hotel_id", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@Rab_id", MySqlDbType.Int64).Value = textBox1.Text;
            command.Parameters.Add("@Reis_id", MySqlDbType.Int64).Value = textBox3.Text;
            command.Parameters.Add("@RouteName", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@Country", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@City", MySqlDbType.VarChar).Value = textBox6.Text;

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("УСПЕШНО");
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else MessageBox.Show("Error");

            dB.ClodeConnect();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
