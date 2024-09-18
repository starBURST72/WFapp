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
    public partial class   UpdatePerevodForm : Form
    {
        public UpdatePerevodForm()
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
            MySqlCommand command = new MySqlCommand("UPDATE `Perevods` SET `Dolgnost` = @Dolgnost, `Reason` = @Reason,  `Date` = @Date WHERE `Perevods`.`Perevod_id` = @ID;", dB.GetConnection());
            command.Parameters.Add("@Perevod_id", MySqlDbType.Int64).Value = textBox3.Text;
            command.Parameters.Add("@Reason", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Dolgnost", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Birthday", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
            

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) MessageBox.Show("УСПЕШНО");
            else MessageBox.Show("Error");

            dB.ClodeConnect();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
            dateTimePicker1.Text = string.Empty;


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
