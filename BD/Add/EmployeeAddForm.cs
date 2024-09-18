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
    public partial class EmployeeAddForm : Form
    {
        public EmployeeAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || dateTimePicker1.Value.ToString() == "")
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            //if (Check()) return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Employees` ( `Name`, `Surname`, `Lastname`,`Birthday`,`Salary`,`Address`,`AgentNum`    ) VALUES( @name, @surname, @lastname, @birthday, @salary, @address, @agentnum); ", dB.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@birthday", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
            command.Parameters.Add("@salary", MySqlDbType.Int64).Value = textBox5.Text;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@agentnum", MySqlDbType.Int64).Value = textBox7.Text;

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
            textBox7.Clear();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //public Boolean Check()
        //{
        //    DB dB = new DB();

        //    DataTable table = new DataTable();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `authors` WHERE `name` = @name, `second_name` = @sname, `father_name` = @fname", dB.GetConnection());
        //    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
        //    command.Parameters.Add("@sname", MySqlDbType.VarChar).Value = textBox2.Text;
        //    command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = textBox3.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);

        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такой автор уже существует");
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
