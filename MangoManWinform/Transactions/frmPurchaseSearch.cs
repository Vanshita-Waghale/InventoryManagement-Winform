using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoManWinform.Transactions
{
    public partial class frmPurchaseSearch : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public int SelectedPurchaseID { get; private set; } = 0;  // <-- To pass back
        private DataTable dt;

        public frmPurchaseSearch()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();

            DataTable dt = Commands.GetData(
                @"SELECT p.PurchaseID, p.PurchaseNo, p.PurchaseDate, 
                     i.ItemName, i.UnitName, 
                     p.Quantity, p.PurchaseRate, 
                     LEFT(p.Narration, 25) AS Narration
              FROM tblPurchase p
              LEFT JOIN tblItem i ON i.ItemID = p.ItemID");

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dt;
            dataGridView2.Columns["PurchaseID"].Visible = false;
            //dataGridView2.Columns["ItemID"].Visible = false;
            dataGridView2.Columns["PurchaseNo"].HeaderText = "Purchase No";
            dataGridView2.Columns["PurchaseNo"].Width = 100;
            dataGridView2.Columns["PurchaseDate"].HeaderText = "Purchase Date";
            dataGridView2.Columns["PurchaseDate"].Width = 100;
            dataGridView2.Columns["ItemName"].HeaderText = "Item Name";  
            dataGridView2.Columns["ItemName"].Width = 250;
            dataGridView2.Columns["UnitName"].HeaderText = "Unit";
            dataGridView2.Columns["UnitName"].Width = 50;
            dataGridView2.Columns["Quantity"].HeaderText = "Qty";
            dataGridView2.Columns["Quantity"].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["PurchaseRate"].HeaderText = "Rate";
            dataGridView2.Columns["PurchaseRate"].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns["PurchaseRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["Narration"].HeaderText = "Narration";
            dataGridView2.Columns["Narration"].Width = 300;
            dataGridView2.Columns["Narration"].MinimumWidth = 100;
            dataGridView2.Columns["Narration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.DefaultCellStyle.Font = new Font("Arial" ,9F, FontStyle.Bold);
        }
        private void frmPurchaseSearch_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoGenerateColumns = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            if (dataGridView2.CurrentRow != null)
            {
                SelectedPurchaseID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["PurchaseID"].Value);
                this.DialogResult = DialogResult.OK; // return control to caller
            }
            else
            {
                MessageBox.Show("Please select a record first.");
            }
        }
    }
}
