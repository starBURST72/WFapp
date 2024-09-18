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
    public partial class ClientAddForm : Form
    {
        public ClientAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `clients` (`Route_id`, `Surname`, `Name`, `Lastname`, `Address`, `Phone_number`, `Birthday`) VALUES (@Route_id, @Surname, @Name, @Lastname, @Address, @Phone_number, @Birthday);", dB.GetConnection());
            command.Parameters.Add("@Route_id", MySqlDbType.Int64).Value = textBox1.Text;
            command.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@Address", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@Phone_number", MySqlDbType.Int64).Value = textBox6.Text;
            command.Parameters.Add("@Birthday", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) MessageBox.Show("УСПЕШНО");
            else MessageBox.Show("Error");

            dB.ClodeConnect();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Text = string.Empty;
           
        }
    }
}
