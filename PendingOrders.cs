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
using System.Windows.Markup;

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

        private void display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM orders", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = (dt);

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lblstatus.Text == "Paid")
            {
                MessageBox.Show("Already paid");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Paid?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lblstatus.Text == "Not paid yet")
                    {
                        lblstatus.Text = "Paid";
                    }

                    if (con.State != ConnectionState.Open)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE orders SET Status = '" + lblstatus.Text + "' WHERE Orderid = '" + lblid.Text + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Order Paid!");


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error connecting database" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con.Close();
                            display();
                        }
                    }
                }
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (lblorder.Text == "On process")
            {
                lblorder.ForeColor = Color.Yellow;
            }
            else
            {
                lblorder.ForeColor = Color.DarkGreen;
            }

            if(lblstatus.Text == "Not paid yet")
            {
                lblstatus.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblstatus.ForeColor = Color.DarkGreen;
            }
        }

        private void AddtoRecent()
        {
            if (lblstatus.Text == "Not paid yet" || lblorder.Text == "On process")
            {
                MessageBox.Show("Transaction is not complete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblid.Text == "" || lbltotal.Text == "")
                {
                    MessageBox.Show("Select order first", "No selected order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Order done?", "Order information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            string insertData = "INSERT INTO doneorders (Orderid, Pizza, Size, Crusttype, Extratoppings, Total, Status, Orderr) " +
                                    "VALUES(@Orderid, @Pizza, @Size, @Crusttype, @Extratoppings, @Total, @Status, @Orderr)";


                            using (SqlCommand cmd = new SqlCommand(insertData, con))
                            {
                                cmd.Parameters.AddWithValue("@Orderid", lblid.Text.Trim());
                                cmd.Parameters.AddWithValue("@Pizza", lblpizza.Text.Trim());
                                cmd.Parameters.AddWithValue("@Size", lblsize.Text.Trim());
                                cmd.Parameters.AddWithValue("@Crusttype", lblcrust.Text.Trim());
                                cmd.Parameters.AddWithValue("@Extratoppings", lbltoppings.Text.Trim());
                                cmd.Parameters.AddWithValue("@Total", lbltotal.Text.Trim());
                                cmd.Parameters.AddWithValue("@Status", lblstatus.Text.Trim());
                                cmd.Parameters.AddWithValue("@Orderr", lblorder.Text.Trim());

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Order done", "Order information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error, connecting database", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddtoRecent();
            DeleteToPending();
            display();
        }

        private void DeleteToPending()
        {
            if(lblstatus.Text == "" && lblorder.Text == "")
            {

            }
            else
            {
                if (lblstatus.Text == "Paid" && lblorder.Text == "Received")
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "DELETE FROM orders WHERE Orderid = '" + lblid.Text + "'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblorder.Text == "Received")
            {
                MessageBox.Show("Already Received");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Received?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lblorder.Text == "On process")
                    {
                        lblorder.Text = "Received";
                    }
                    else
                    {
                        MessageBox.Show("Already Received");
                    }

                    if (con.State != ConnectionState.Open)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE orders SET Orderr = '" + lblorder.Text + "' WHERE Orderid = '" + lblid.Text + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Order Received!");


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error connecting database" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con.Close();
                            display();
                        }
                    }
                }
            }

            
        }

        private void lblid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM orders WHERE Order id = @Order id";
                cmd.Parameters.AddWithValue("@Order id", txtsearch.Text);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
