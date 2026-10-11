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
    public partial class customer : Form
    {
        public customer()
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();

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
        void cus()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from customer", conn);

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
                SqlCommand cmd = new SqlCommand("insert into customer(fullname, phone, address)values(@name, @ph, @add)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ph", txtph.Text);
                cmd.Parameters.AddWithValue("@add", txtadd.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("customer saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cus();
                conn.Close();

                txtname.Clear();
                txtph.Clear();
                txtadd.Clear();
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


                SqlCommand cmd = new SqlCommand("update customer set fullname=@name ,phone=@ph, address=@add where id=ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ph", txtph.Text);
                cmd.Parameters.AddWithValue("@add", txtadd.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update customer success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                cus();


                txtname.Clear();
                txtph.Clear();
                txtadd.Clear();
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


                SqlCommand cmd = new SqlCommand("delete from customer where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete customer success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                cus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customer_Load(object sender, EventArgs e)
        {
            cus();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cus();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from customer where id='" + txtsearch.Text + "'", conn);
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
