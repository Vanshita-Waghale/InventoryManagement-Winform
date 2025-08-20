namespace MangoManWinform.Navigation
{
    partial class frmNavigationDashboard
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
            System.Windows.Forms.ToolStripButton btnItemMaster;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNavigationDashboard));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpeningStock = new System.Windows.Forms.ToolStripLabel();
            this.btnSale = new System.Windows.Forms.ToolStripLabel();
            this.btnPurchase = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnItemMaster = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnItemMaster
            // 
            btnItemMaster.AutoSize = false;
            btnItemMaster.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnItemMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnItemMaster.Image")));
            btnItemMaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnItemMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnItemMaster.Margin = new System.Windows.Forms.Padding(6);
            btnItemMaster.Name = "btnItemMaster";
            btnItemMaster.Size = new System.Drawing.Size(150, 50);
            btnItemMaster.Text = "Item Master";
            btnItemMaster.Click += new System.EventHandler(this.btnItemMaster_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            btnItemMaster,
            this.btnOpeningStock,
            this.btnSale,
            this.btnPurchase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1076, 62);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpeningStock
            // 
            this.btnOpeningStock.Image = ((System.Drawing.Image)(resources.GetObject("btnOpeningStock.Image")));
            this.btnOpeningStock.Name = "btnOpeningStock";
            this.btnOpeningStock.Size = new System.Drawing.Size(126, 59);
            this.btnOpeningStock.Text = "&Opening Stock";
            this.btnOpeningStock.Click += new System.EventHandler(this.btnOpeningStock_Click);
            // 
            // btnSale
            // 
            this.btnSale.Image = ((System.Drawing.Image)(resources.GetObject("btnSale.Image")));
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(57, 59);
            this.btnSale.Text = "&Sale";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchase.Image")));
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(87, 59);
            this.btnPurchase.Text = "&Purchase";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Location = new System.Drawing.Point(0, 62);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1076, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // frmNavigationDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 695);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmNavigationDashboard";
            this.Text = "MangoMan 1.0";
            this.Load += new System.EventHandler(this.frmNavigationDashboard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel btnOpeningStock;
        private System.Windows.Forms.ToolStripLabel btnSale;
        private System.Windows.Forms.ToolStripLabel btnPurchase;
    }
}