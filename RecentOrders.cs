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

namespace Pizza_Application_2
{
    public partial class RecentOrders : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HOBAYAN\source\repos\Pizza-Application-2\DatabasePizza2.mdf;Integrated Security=True");

        public RecentOrders()
        {
            InitializeComponent();
        }

        private void display()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM doneorders", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv2.AutoGenerateColumns = false;
            dgv2.DataSource = (dt);

            con.Close();
        }

        private void RecentOrders_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to delete data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dr == DialogResult.OK)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "DELETE FROM doneorders WHERE Orderid = '" + lblid.Text + "'";
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    display();
                }
                catch
                {
                    MessageBox.Show("Error Occured");
                }
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvrow = dgv2.Rows[e.RowIndex];
                lblid.Text = dgvrow.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to delete all data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dr == DialogResult.OK)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "DELETE FROM doneorders";
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    display();
                }
                catch
                {
                    MessageBox.Show("Error Occured");
                }
            }
        }
    }
}
