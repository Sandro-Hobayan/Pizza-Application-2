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
    public partial class CreateOrder : Form
    {
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

            lbltoppings1.Text = $"{extracheese}   {mushrooms}   {onions}";
            lbltoppings2.Text = $"{tomatoes}   {pineapple}   {peppers}";

            //toppings total
            float toppingstotal = extracheesecost + mushroomscost + onionscost + tomatoescost + pineapplecost + pepperscost;
            lbltoppingstotal.Text = toppingstotal.ToString();

            //overall total
            float overalltotal = float.Parse(lblpizzatotal.Text) + float.Parse(lbltoppingstotal.Text);
            lbloveralltotal.Text = overalltotal.ToString();
        }
    }
}
