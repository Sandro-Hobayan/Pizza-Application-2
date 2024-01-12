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

        private void RecentOrders_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM doneorders", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv2.AutoGenerateColumns = false;
            dgv2.DataSource = (dt);

            con.Close();
        }
    }
}
