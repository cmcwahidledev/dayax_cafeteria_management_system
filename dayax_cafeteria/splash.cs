using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayax_cafeteria
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
            guna2CircleProgressBar1.Value = value;
            guna2CircleProgressBar1.Text = value.ToString("%");
            label1.Text = value+"%";
            if (value > 99)
            {
                timer1.Stop();
                new login().Show();
                this.Hide();
            }

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();
        }
    }
}
