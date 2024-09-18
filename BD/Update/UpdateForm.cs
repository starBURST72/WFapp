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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmpForm form = new UpdateEmpForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateClientForm form = new UpdateClientForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdatePlanesForm form = new UpdatePlanesForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateReisForm form = new UpdateReisForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateHotelForm form = new UpdateHotelForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdatePerevodForm form = new UpdatePerevodForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateRouteForm form = new UpdateRouteForm();
            form.Show();
        }
    }
}
