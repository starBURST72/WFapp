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
    public partial class HotelAddForm : Form
    {
        public HotelAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `hotel` ( `HotelName`, `Class`, `Categories`) VALUES( @HotelName, @Class, @Categories); ", dB.GetConnection());
            command.Parameters.Add("@HotelName", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Class", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Categories", MySqlDbType.VarChar).Value = textBox3.Text;

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) MessageBox.Show("УСПЕШНО");
            else MessageBox.Show("Error");

            dB.ClodeConnect();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        //public Boolean Check()
        //{
        //    DB dB = new DB();

        //    DataTable table = new DataTable();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UL", dB.GetConnection());
        //    command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = textBox1.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);

        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такой пользователь есть");
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
