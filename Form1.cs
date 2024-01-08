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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HOBAYAN\source\repos\Pizza-Application-2\Database1.mdf;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkshowpass.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Signup su = new Signup();
            su.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to exit?", "Close the application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.No)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please fiil all blank field", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();

                        string selectData = "SELECT * FROM account WHERE username = @username AND password = @pass";
                        using (SqlCommand cmd = new SqlCommand(selectData, con))
                        {
                            cmd.Parameters.AddWithValue("@username", txtuser.Text);
                            cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged In Successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                Dashboard home = new Dashboard();
                                home.Show();

                                Dashboard.instance.btnacc.Text = txtuser.Text;

                            }
                            else
                            {
                                MessageBox.Show("Incorrect username or password", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting database" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
