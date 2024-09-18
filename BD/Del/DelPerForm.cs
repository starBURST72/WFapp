using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace КР_УБД_V_1._0
{
    public partial class DelPerForm : Form
    {
        public DelPerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `perevods` WHERE `perevods`.`Perevod_id` = @ID", dB.GetConnection());
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);


        }
    }
}
