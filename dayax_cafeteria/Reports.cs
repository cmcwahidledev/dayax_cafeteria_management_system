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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new product().Show(); this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem.ToString() == "PRODUCT")
            {
                proReport rpt = new proReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "CUSTOMER")
            {
                custReport rpt = new custReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "TABLES")
            {
                tabReport rpt = new tabReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "ORDERS")
            {
                ordReport rpt = new ordReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "PAYMENT")
            {
                payReport rpt = new payReport();
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Insert(0, "Choose select");
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new payment().Show(); this.Hide();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            new product().Show(); this.Hide();

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
