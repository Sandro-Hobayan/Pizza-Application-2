using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Application_2
{
    public partial class Dashboard : Form
    {
        public static Dashboard instance;
        public Button btnacc;

        public Dashboard()
        {
            InitializeComponent();
            instance = this;
            btnacc = btnaccount;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void ClearPanel()
        {
            pnlmain.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearPanel();
            label2.Text = "Create order";
            CreateOrder co = new CreateOrder() { TopLevel = false, TopMost = true };
            pnlmain.Controls.Add(co);
            co.Show();
        }

        private void btnaccount_Click(object sender, EventArgs e)
        {
            if(panel5.Height == 114)
            {
                panel5.Height = 37;
            }
            else
            {
                panel5.Height = 114;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to log out?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accounts acc = new Accounts();
            acc.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to exit?", "Close the application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearPanel();
            label2.Text = "Recent orders";
            RecentOrders ro = new RecentOrders() { TopLevel = false, TopMost = true };
            pnlmain.Controls.Add(ro);
            ro.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearPanel();
            label2.Text = "Pending orders";
            PendingOrders po = new PendingOrders() { TopLevel = false, TopMost = true };
            pnlmain.Controls.Add(po);
            po.Show();
        }
    }
}
