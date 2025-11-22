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

namespace MangoManWinform.Transactions
{
    public partial class FrmAddNewItem : Form
    {
        public int NewItemID { get; private set; } = 0;

        public FrmAddNewItem()
        {
            InitializeComponent();
            // Make Enter key act like Tab
            this.KeyPreview = true;
            this.KeyDown += FrmAddNewItem_KeyDown;
        }

        private void FrmAddNewItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevent beep
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        

        private void txtHSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaleRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHSN.Text))
            {
                MessageBox.Show("Please enter HSN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHSN.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter Item Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("Please enter Unit Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            if (!decimal.TryParse(txtPurchaseRate.Text, out decimal purchaseRate) || purchaseRate < 0)
            {
                MessageBox.Show("Enter valid Purchase Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurchaseRate.Focus();
                return;
            }

            if (!decimal.TryParse(txtSaleRate.Text, out decimal saleRate) || saleRate < 0)
            {
                MessageBox.Show("Enter valid Sale Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaleRate.Focus();
                return;
            }

            try
            {
                var cmd = new MangoMaan.DAL.CommonCommands();

                // Duplicate check
                object existing = cmd.ExecuteScalar(
                    "SELECT ItemID FROM tblItem WHERE ItemName=@ItemName AND HSN=@HSN",
                    new SqlParameter("@ItemName", txtItemName.Text.Trim()),
                    new SqlParameter("@HSN", txtHSN.Text.Trim())
                );

                if (existing != null)
                {
                    MessageBox.Show("Item already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert and fetch new ItemID safely
                object newId = cmd.ExecuteScalar(
                    @"INSERT INTO tblItem (HSN, ItemName, UnitName, Description, PurchaseRate, SaleRate, rcdt)
              OUTPUT INSERTED.ItemID
              VALUES (@HSN, @ItemName, @UnitName, @Descr, @PurchaseRate, @SaleRate, GETDATE())",
                    new SqlParameter("@HSN", txtHSN.Text.Trim()),
                    new SqlParameter("@ItemName", txtItemName.Text.Trim()),
                    new SqlParameter("@UnitName", txtUnitName.Text.Trim()),
                    new SqlParameter("@Descr", txtDescr.Text.Trim()),
                    new SqlParameter("@PurchaseRate", purchaseRate),
                    new SqlParameter("@SaleRate", saleRate)
                );

                NewItemID = Convert.ToInt32(newId);

                MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
