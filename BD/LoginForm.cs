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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string LoginUser = LoginTextBox.Text;
            string PasswordUser = PasswordTextBox.Text;

            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UL AND `password` = @UP", dB.GetConnection());
            command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = PasswordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Успешно");
                this.Close();
            }
            else MessageBox.Show("Error 1000-7");

            
        }
    }
}
