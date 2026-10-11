using dayax_cafeteria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayax_cafeteria
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        void pay()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from payment", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pro();
            pay();
            cus();
            ord();
        }
        private void pro()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from product", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblpro.Text = result.ToString();
            }
            else
            {
                lblpro.Text = "0";
            }
            conn.Close();
        }
        private void cus()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from customer", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblcust.Text = result.ToString();
            }
            else
            {
                lblcust.Text = "0";
            }
            conn.Close();
        }
        private void ord()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from orders", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblorder.Text = result.ToString();
            }
            else
            {
                lblorder.Text = "0";
            }
            conn.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new product().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pay();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new tables().Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new payment().Show(); this.Hide();

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }
    }
}
