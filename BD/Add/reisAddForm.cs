﻿using MySql.Data.MySqlClient;
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
    public partial class reisAddForm : Form
    {
        public reisAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || dateTimePicker1.Value.ToString() == "" || dateTimePicker2.Value.ToString() == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `reis` (  `Plane_id`,`Date_go`, `Date_back`,`Class`, `Place`,`CarrierName`) VALUES( @Plane_id,@Date_go,@Date_back,@Class,@Place,@CarrierName); ", dB.GetConnection());
            command.Parameters.Add("@Plane_id", MySqlDbType.Int64).Value = textBox1.Text;
            command.Parameters.Add("@Date_go", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
            command.Parameters.Add("@Date_back", MySqlDbType.Date).Value = dateTimePicker2.Value.Date;
            command.Parameters.Add("@Class", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@Place", MySqlDbType.Int64).Value = textBox6.Text;
            command.Parameters.Add("@CarrierName", MySqlDbType.VarChar).Value = textBox5.Text;
            

            dB.OpenConnect();

            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("УСПЕШНО");
                textBox1.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                dateTimePicker1.Text = string.Empty;
                dateTimePicker2.Text = string.Empty;
            }
            else MessageBox.Show("Error");

            dB.ClodeConnect();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
