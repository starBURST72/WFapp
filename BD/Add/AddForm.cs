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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeAddForm form = new EmployeeAddForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientAddForm form = new ClientAddForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlanesAddForm form = new PlanesAddForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reisAddForm form = new reisAddForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HotelAddForm form = new HotelAddForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PerevodAddForm form = new PerevodAddForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RouteAddForm form = new RouteAddForm();
            form.Show();
        }
    }
}
