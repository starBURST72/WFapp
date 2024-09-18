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
    public partial class PerevodAddForm : Form
    {
        public PerevodAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Value.ToString() == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `perevods` ( `Dolgnost`, `Reason`, `Date`) VALUES( @Dolgnost, @Reason,@Date); ", dB.GetConnection());
            command.Parameters.Add("@Dolgnost", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Reason", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Date", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1)
            {


                MySqlCommand command1 = new MySqlCommand("UPDATE `perevods_employees` SET `Rab_id` = @Rab_id WHERE `perevods_employees`.`Perevod_id`=LAST_INSERT_ID();", dB.GetConnection());
                command1.Parameters.Add("@Rab_id", MySqlDbType.Int64).Value = textBox3.Text;
                if (command1.ExecuteNonQuery() == 1) { 
                MessageBox.Show("Запись и связь создалась успешно"); textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Text = string.Empty; 
                }

            else MessageBox.Show("Error");

            }
            else MessageBox.Show("Error");

            dB.ClodeConnect();
           
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
