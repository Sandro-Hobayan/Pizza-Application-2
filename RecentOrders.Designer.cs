namespace Pizza_Application_2
{
    partial class RecentOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.orderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pizza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderid,
            this.pizza,
            this.size,
            this.crust,
            this.toppings,
            this.total,
            this.status,
            this.order});
            this.dgv2.Location = new System.Drawing.Point(21, 29);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(841, 392);
            this.dgv2.TabIndex = 0;
            // 
            // orderid
            // 
            this.orderid.DataPropertyName = "Orderid";
            this.orderid.HeaderText = "Order ID";
            this.orderid.Name = "orderid";
            // 
            // pizza
            // 
            this.pizza.DataPropertyName = "Pizza";
            this.pizza.HeaderText = "Pizza";
            this.pizza.Name = "pizza";
            // 
            // size
            // 
            this.size.DataPropertyName = "Size";
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            // 
            // crust
            // 
            this.crust.DataPropertyName = "Crusttype";
            this.crust.HeaderText = "Crust type";
            this.crust.Name = "crust";
            // 
            // toppings
            // 
            this.toppings.DataPropertyName = "Extratoppings";
            this.toppings.HeaderText = "Extra toppings";
            this.toppings.Name = "toppings";
            // 
            // total
            // 
            this.total.DataPropertyName = "Total";
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // order
            // 
            this.order.DataPropertyName = "Orderr";
            this.order.HeaderText = "Order";
            this.order.Name = "order";
            // 
            // RecentOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 623);
            this.Controls.Add(this.dgv2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecentOrders";
            this.Text = "RecentOrders";
            this.Load += new System.EventHandler(this.RecentOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pizza;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn crust;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppings;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
    }
}