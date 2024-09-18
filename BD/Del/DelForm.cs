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
    public partial class DelForm : Form
    {
        public DelForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelEmpForm form = new DelEmpForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelCliForm form = new DelCliForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DelPlaForm form = new DelPlaForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelReisForm form = new DelReisForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DelHotForm form = new DelHotForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DelPerForm form = new DelPerForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DelRouForm form = new DelRouForm();
            form.Show();
        }
    }
}
