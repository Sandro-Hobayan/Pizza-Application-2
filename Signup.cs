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
    public partial class Signup : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HOBAYAN\OneDrive\Desktop\visual studio c#\Pizza Application 2\PizzarapDatabase.mdf"";Integrated Security=True");

        public Signup()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void checkshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkshowpass.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtemail.Text == "" || txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please fill all blank field", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();
                        string checkUsername = "SELECT * FROM account WHERE username = '" + txtuser.Text.Trim() + "'";

                        using (SqlCommand checkUser = new SqlCommand(checkUsername, con))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(txtuser.Text + " is already exist", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO account (email, username, password) " +
                                "VALUES(@email, @username, @pass)";


                                using (SqlCommand cmd = new SqlCommand(insertData, con))
                                {
                                    cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", txtuser.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered Successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form1 f1 = new Form1();
                                    f1.Show();
                                    this.Hide();
                                }
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
