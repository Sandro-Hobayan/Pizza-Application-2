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
    public partial class PendingOrders : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HOBAYAN\source\repos\Pizza-Application-2\DatabasePizza2.mdf;Integrated Security=True");

        public PendingOrders()
        {
            InitializeComponent();
        }

        private void PendingOrders_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM orders", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = (dt);

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow dgvrow = dgv1.Rows[e.RowIndex];
                lblpizza.Text = dgvrow.Cells[1].Value.ToString();
                lblsize.Text = dgvrow.Cells[2].Value.ToString();
                lblcrust.Text = dgvrow.Cells[3].Value.ToString();
                lbltoppings.Text = dgvrow.Cells[4].Value.ToString();
                lblid.Text = dgvrow.Cells[0].Value.ToString();
                lbltotal.Text = dgvrow.Cells[5].Value.ToString();
                lblstatus.Text = dgvrow.Cells[6].Value.ToString();
                lblorder.Text = dgvrow.Cells[7].Value.ToString();
            }
        }
    }
}
