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
    public partial class CreateOrder : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HOBAYAN\source\repos\Pizza-Application-2\DatabasePizza2.mdf;Integrated Security=True");
        private List<string> selectedtoppings = new List<string>();

        public CreateOrder()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblsizetimes.Text = "x";
            lblcrustplus.Text = "+";

            //Pizza
            float cost;
            if (radhawaian.Checked == true)
            {
                lblpizza.Text = "Hawaian";
                cost = 100;
                lblpizzacost.Text = cost.ToString();
            }
            else if (radhamandcheese.Checked == true)
            {
                lblpizza.Text = "Ham and Cheese";
                cost = 120;
                lblpizzacost.Text = cost.ToString();
            }
            else if (radpepperoni.Checked == true)
            {
                lblpizza.Text = "Pepperoni";
                cost = 80;
                lblpizzacost.Text = cost.ToString();
            }
            else if (radveggie.Checked == true)
            {
                lblpizza.Text = "Veggie";
                cost = 70;
                lblpizzacost.Text = cost.ToString();
            }


            //Size
            float sizecost;
            if(radsmall.Checked == true)
            {
                lblsize.Text = "Small";
                sizecost = 1;
                lblsizecost.Text = sizecost.ToString();
            }
            else if(radmedium.Checked == true)
            {
                lblsize.Text = "Medium";
                sizecost = 2;
                lblsizecost.Text = sizecost.ToString();
            }
            else if(radlarge.Checked == true)
            {
                lblsize.Text = "Large";
                sizecost = 3;
                lblsizecost.Text = sizecost.ToString();
            }
            else if(radextralarge.Checked == true)
            {
                lblsize.Text = "Extra large";
                sizecost = 4;
                lblsizecost.Text = sizecost.ToString();
            }


            //crust
            float crustcost;
            if(radthick.Checked == true)
            {
                lblcrust.Text = "Thick";
                crustcost = 0;
                lblcrustcost.Text = crustcost.ToString();
            }
            else if(radthin.Checked == true)
            {
                lblcrust.Text = "Thin";
                crustcost = 40;
                lblcrustcost.Text = crustcost.ToString();
            }
            else if(radioButton12.Checked == true)
            {
                lblcrust.Text = "No crust";
                crustcost = 80;
                lblcrustcost.Text = crustcost.ToString();
            }

            //pizza total
            float pizzatotal = float.Parse(lblpizzacost.Text) * float.Parse(lblsizecost.Text) + float.Parse(lblcrustcost.Text);
            lblpizzatotal.Text = pizzatotal.ToString();


            //Extra toppings
            string extracheese = "", mushrooms = "", onions = "", tomatoes = "", pineapple = "", peppers = "";
            float extracheesecost, mushroomscost, onionscost, tomatoescost, pineapplecost, pepperscost;
            if(chkextracheese.Checked == true)
            {
                extracheese += chkextracheese.Text;
                extracheesecost = 20;
            }
            else
            {
                extracheesecost = 0;
            }

            if(chkmushrooms.Checked == true)
            {
                mushrooms += chkmushrooms.Text;
                mushroomscost = 15;
            }
            else
            {
                mushroomscost = 0;
            }

            if(chkonions.Checked == true)
            {
                onions += chkonions.Text;
                onionscost = 10;
            }
            else
            {
                onionscost = 0;
            }

            if (chktomatoes.Checked == true)
            {
                tomatoes += chktomatoes.Text;
                tomatoescost = 20;
            }
            else
            {
                tomatoescost = 0;
            }

            if(chkpineapple.Checked == true)
            {
                pineapple += chkpineapple.Text;
                pineapplecost = 20;
            }
            else
            {
                pineapplecost = 0;
            }

            if(chkpeppers.Checked == true)
            {
                peppers += chkpeppers.Text;
                pepperscost = 10;
            }
            else
            {
                pepperscost = 0;
            }

            lbltoppings1.Text = $"- {extracheese}   {mushrooms}   {onions} \n \n {tomatoes}   {pineapple}   {peppers}";

            //toppings total
            float toppingstotal = extracheesecost + mushroomscost + onionscost + tomatoescost + pineapplecost + pepperscost;
            lbltoppingstotal.Text = toppingstotal.ToString();

            //order
            if(radnotpaid.Checked == true)
            {
                lblorderstatus.Text = "Not paid yet";
            }
            else
            {
                lblorderstatus.Text = "Paid";
            }

            //order status
            if(radonprocess.Checked == true)
            {
                lblorder.Text = "On process";
            }
            else
            {
                lblorder.Text = "Received";
            }

            //overall total
            float overalltotal = float.Parse(lblpizzatotal.Text) + float.Parse(lbltoppingstotal.Text);
            lbloveralltotal.Text = overalltotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblpizza.Text == "" || lbloveralltotal.Text == "")
            {
                MessageBox.Show("Please make order first", "No order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Place order?", "Order Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (con.State != ConnectionState.Open)
                    {
                        try
                        {
                            con.Open();
                            string insertData = "INSERT INTO orders (Pizza, Size, Crusttype, Extratoppings, Total, Status, Orderr) " +
                                    "VALUES(@Pizza, @Size, @Crusttype, @Extratoppings, @Total, @Status, @Orderr)";


                            using (SqlCommand cmd = new SqlCommand(insertData, con))
                            {
                                cmd.Parameters.AddWithValue("@Pizza", lblpizza.Text.Trim());
                                cmd.Parameters.AddWithValue("@Size", lblsize.Text.Trim());
                                cmd.Parameters.AddWithValue("@Crusttype", lblcrust.Text.Trim());
                                cmd.Parameters.AddWithValue("@Extratoppings", lbltoppings1.Text.Trim());
                                cmd.Parameters.AddWithValue("@Total", lbloveralltotal.Text.Trim());
                                cmd.Parameters.AddWithValue("@Status", lblorderstatus.Text.Trim());
                                cmd.Parameters.AddWithValue("@Orderr", lblorder.Text.Trim());

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Order placed", "Order information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CreateOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
