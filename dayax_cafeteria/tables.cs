using Microsoft.SqlServer.Server;
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
    public partial class tables : Form
    {
        public tables()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new product().Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comstatus.Items.Insert(0, "Status");
            comstatus.SelectedIndex = 0;
            tab();
        }

        private void hireDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }
        void tab()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from tables", conn);

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
                SqlCommand cmd = new SqlCommand("insert into tables(tableName, status)values(@name, @status)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@status", comstatus.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("table saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tab();
                conn.Close();

                txtname.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tab();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("delete from tables where id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete tables success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                tab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from tables where id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=dayax_cafeteria;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update tables set tableName=@name, status=@Status where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@Status", comstatus.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update tables success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                tab();


                txtname.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            new product().Show(); this.Hide();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new customer().Show(); this.Hide();

        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            new orders().Show(); this.Hide();

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            new payment().Show(); this.Hide();

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();

        }
    }
}
