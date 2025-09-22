using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoManWinform.Navigation
{
    public partial class frmNavigationDashboard : Form
    {
        public frmNavigationDashboard()
        {
            InitializeComponent();
        }

        private void frmNavigationDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnItemMaster_Click(object sender, EventArgs e)
        {
            Items.frmItemMaster frm = new Items.frmItemMaster();
            frm.MdiParent = this;//Multiple document interface
            frm.Show();
        }

        private void btnOpeningStock_Click(object sender, EventArgs e)
        {
            Transactions.FrmOpeningStock frm = new Transactions.FrmOpeningStock();
            frm.MdiParent = this;//Multiple document interface
            frm.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Transactions.frmPurchase frm = new Transactions.frmPurchase();
            frm.MdiParent = this; // Set MDI parent
            frm.Show();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Transactions.frmSale frm = new Transactions.frmSale();
            frm.MdiParent = this; // Set MDI parent
            frm.Show();
        }
    }
}

