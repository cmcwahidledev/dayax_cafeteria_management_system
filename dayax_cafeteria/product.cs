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
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pro();
        }
        void pro()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from product", conn);

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
                SqlCommand cmd = new SqlCommand("insert into product(product_name, category, price)values(@name, @cat, @price)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@cat", txtcate.Text);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("product saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pro();
                conn.Close();

                txtname.Clear();
                txtcate.Clear();
                txtprice.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pro();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("delete from product where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete product success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                pro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update product set product_name=@name ,category=@cat, price=@price where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@cat", txtcate.Text);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update product success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                pro();


                txtname.Clear();
                txtcate.Clear();
                txtprice.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from product where id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            new tables().Show(); this.Hide();

        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            new payment().Show(); this.Hide();

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();

        }
    }
}
