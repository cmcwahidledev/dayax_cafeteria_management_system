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
using System.Xml.Linq;

namespace dayax_cafeteria
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new product().Show(); this.Hide();

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();

        }
        void am()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from payment", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into payment(orderID, amount)values(@oid, @am)", conn);

                cmd.Parameters.AddWithValue("@oid", txtoid.Text);
                cmd.Parameters.AddWithValue("@am", txtamount.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("payment saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                am();
                conn.Close();

                txtoid.Clear();
                txtamount.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update payment set orderID=@oid, amount=@am where id=@ID", conn);

                cmd.Parameters.AddWithValue("@oid", txtoid.Text);
                cmd.Parameters.AddWithValue("@am", txtamount.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update tables success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                am();


                txtoid.Clear();
                txtamount.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("delete from payment where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete tables success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                am();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from payment where id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void payment_Load(object sender, EventArgs e)
        {
            am();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            am();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
