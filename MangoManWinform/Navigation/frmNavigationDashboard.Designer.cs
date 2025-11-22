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
            System.Windows.Forms.ToolStripButton btnOpeningStock1;
            System.Windows.Forms.ToolStripButton btnPurchase;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnPurchaseListView = new System.Windows.Forms.ToolStripButton();
            this.btnSale = new System.Windows.Forms.ToolStripButton();
            this.btnSaleListView = new System.Windows.Forms.ToolStripButton();
            this.btnStockinHand = new System.Windows.Forms.ToolStripButton();
            this.btnViewReport = new System.Windows.Forms.ToolStripButton();
            btnItemMaster = new System.Windows.Forms.ToolStripButton();
            btnOpeningStock1 = new System.Windows.Forms.ToolStripButton();
            btnPurchase = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(10, 10);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            btnItemMaster,
            btnOpeningStock1,
            btnPurchase,
            this.btnPurchaseListView,
            this.btnSale,
            this.btnSaleListView,
            this.btnStockinHand,
            this.btnViewReport,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(256, 773);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.AutoToolTip = true;
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(250, 80);
            this.toolStripLabel2.Text = "Inventory Menu";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(243, 0);
            // 
            // btnItemMaster
            // 
            btnItemMaster.AutoSize = false;
            btnItemMaster.BackColor = System.Drawing.SystemColors.ActiveCaption;
            btnItemMaster.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnItemMaster.Image = global::MangoManWinform.Properties.Resources.icons8_management_64__1_;
            btnItemMaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnItemMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnItemMaster.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnItemMaster.Name = "btnItemMaster";
            btnItemMaster.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnItemMaster.Size = new System.Drawing.Size(239, 68);
            btnItemMaster.Text = "Item Master";
            btnItemMaster.Click += new System.EventHandler(this.btnItemMaster_Click);
            // 
            // btnOpeningStock1
            // 
            btnOpeningStock1.AutoSize = false;
            btnOpeningStock1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnOpeningStock1.Image = global::MangoManWinform.Properties.Resources.icons8_management_64__2_;
            btnOpeningStock1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnOpeningStock1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnOpeningStock1.MergeIndex = -10;
            btnOpeningStock1.Name = "btnOpeningStock1";
            btnOpeningStock1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnOpeningStock1.Size = new System.Drawing.Size(240, 80);
            btnOpeningStock1.Text = "&Opening Stock";
            btnOpeningStock1.Click += new System.EventHandler(this.toolStripLabel5_Click);
            // 
            // btnPurchase
            // 
            btnPurchase.AutoSize = false;
            btnPurchase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPurchase.Image = global::MangoManWinform.Properties.Resources.icons8_inventory_64__3_;
            btnPurchase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnPurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnPurchase.MergeIndex = -10;
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            btnPurchase.Size = new System.Drawing.Size(240, 70);
            btnPurchase.Text = "&Purchase Details";
            btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnPurchaseListView
            // 
            this.btnPurchaseListView.AutoSize = false;
            this.btnPurchaseListView.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseListView.Image = global::MangoManWinform.Properties.Resources.icons8_checklist_64;
            this.btnPurchaseListView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPurchaseListView.Margin = new System.Windows.Forms.Padding(1);
            this.btnPurchaseListView.MergeIndex = -10;
            this.btnPurchaseListView.Name = "btnPurchaseListView";
            this.btnPurchaseListView.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnPurchaseListView.Size = new System.Drawing.Size(240, 80);
            this.btnPurchaseListView.Text = "&PurchaseListView";
            this.btnPurchaseListView.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // btnSale
            // 
            this.btnSale.AutoSize = false;
            this.btnSale.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Image = global::MangoManWinform.Properties.Resources.icons8_inventory_64__4_;
            this.btnSale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSale.Margin = new System.Windows.Forms.Padding(1);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(240, 80);
            this.btnSale.Text = "&Sale Details";
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnSaleListView
            // 
            this.btnSaleListView.AutoSize = false;
            this.btnSaleListView.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleListView.Image = global::MangoManWinform.Properties.Resources.icons8_inventory_64__1_;
            this.btnSaleListView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaleListView.Margin = new System.Windows.Forms.Padding(1);
            this.btnSaleListView.MergeIndex = -10;
            this.btnSaleListView.Name = "btnSaleListView";
            this.btnSaleListView.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSaleListView.Size = new System.Drawing.Size(240, 80);
            this.btnSaleListView.Text = "&SaleListView";
            this.btnSaleListView.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // btnStockinHand
            // 
            this.btnStockinHand.AutoSize = false;
            this.btnStockinHand.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockinHand.Image = global::MangoManWinform.Properties.Resources.icons8_inventory_64;
            this.btnStockinHand.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStockinHand.Margin = new System.Windows.Forms.Padding(1);
            this.btnStockinHand.MergeIndex = -10;
            this.btnStockinHand.Name = "btnStockinHand";
            this.btnStockinHand.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnStockinHand.Size = new System.Drawing.Size(240, 80);
            this.btnStockinHand.Text = "&Stock in hand";
            this.btnStockinHand.Click += new System.EventHandler(this.btnStockinHand_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.AutoSize = false;
            this.btnViewReport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Image = global::MangoManWinform.Properties.Resources.icons8_inventory_64__2_;
            this.btnViewReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewReport.MergeIndex = -10;
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnViewReport.Size = new System.Drawing.Size(240, 80);
            this.btnViewReport.Text = "&View Report";
            this.btnViewReport.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // frmNavigationDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 773);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmNavigationDashboard";
            this.Text = "MangoMan 1.0";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNavigationDashboard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPurchaseListView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnSale;
        private System.Windows.Forms.ToolStripButton btnSaleListView;
        private System.Windows.Forms.ToolStripButton btnStockinHand;
        private System.Windows.Forms.ToolStripButton btnViewReport;
    }
}