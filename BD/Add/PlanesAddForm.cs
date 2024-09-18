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
    public partial class PlanesAddForm : Form
    {
        public PlanesAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `planes` ( `Categories`, `AirportFrom`, `AirportTo`, `Seats`,`FlyDur`) VALUES( @Categories, @AirportFrom,@AirportTo,@Seats,@FlyDur); ", dB.GetConnection());
            command.Parameters.Add("@Categories", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@AirportFrom", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@AirportTo", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@Seats", MySqlDbType.Int64).Value = textBox4.Text;
            command.Parameters.Add("@FlyDur", MySqlDbType.Int64).Value = textBox5.Text;

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) MessageBox.Show("УСПЕШНО");
            else MessageBox.Show("Error");

            dB.ClodeConnect();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
