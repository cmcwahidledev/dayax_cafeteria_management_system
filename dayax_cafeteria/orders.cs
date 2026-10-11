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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new product().Show(); this.Hide();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new payment().Show(); this.Hide();

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();

        }
        void ord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from orders", conn);

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
                SqlCommand cmd = new SqlCommand("insert into orders(productID, customerID, tableID, totalAmount)values(@pid, @cid, @tid, @am)", conn);

                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@tid", txttid.Text);
                cmd.Parameters.AddWithValue("@am", txtamount.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("orders saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ord();
                conn.Close();

                txtpid.Clear();
                txtcid.Clear();
                txttid.Clear();
                txtamount.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void orders_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ord();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update orders set productID=@pid ,customerID=@cid, tableID=@tid, totalAmount=@am where id=@ID", conn);

                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@tid", txttid.Text);
                cmd.Parameters.AddWithValue("@am", txtamount.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update orders success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                ord();


                txtpid.Clear();
                txtcid.Clear();
                txttid.Clear();
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


                SqlCommand cmd = new SqlCommand("delete from orders where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete orders success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                ord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from orders where id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
