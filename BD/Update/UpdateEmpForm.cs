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
    public partial class UpdateEmpForm : Form
    {
        public UpdateEmpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `employees` SET `Name` = @name, `Surname` = @surname, `Lastname` = @lastname, `Birthday` = @birthday, `Salary` = @salary, `Address` = @address, `AgentNum` = @agentnum WHERE `employees`.`Rab_id` = @ID;", dB.GetConnection());
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = textBox4.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@birthday", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
            command.Parameters.Add("@salary", MySqlDbType.Int64).Value = textBox5.Text;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@agentnum", MySqlDbType.Int64).Value = textBox7.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }

        private void UppForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
