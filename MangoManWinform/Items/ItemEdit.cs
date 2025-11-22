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

namespace MangoManWinform.Items
{
    public partial class ItemEdit : Form
    {

        private int PrimaryKeyValue; // ID of the item being edited
        MangoMaan.DAL.CommonCommands cmd;
        private int result;
        private string originalHSN;


        public ItemEdit(int itemId) // constructor requires the item ID
        {
            InitializeComponent();
            cmd = new MangoMaan.DAL.CommonCommands();
            PrimaryKeyValue = itemId;

            LoadItem(PrimaryKeyValue); // load existing item
            btnDelete.Visible = true;  // delete button visible only in edit

            // Prevent changing HSN for existing item
            txtHSN.ReadOnly = true;
        }

        private void LoadItem(int id)
        {
            DataTable dt = cmd.GetData($"SELECT * FROM tblItem WHERE ItemID = {id}");
            if (dt.Rows.Count == 0) return;

            DataRow dr = dt.Rows[0];
            txtHSN.Text = dr["HSN"].ToString();
            originalHSN = txtHSN.Text; // save original HSN
            txtItemName.Text = dr["ItemName"].ToString();
            txtUnitName.Text = dr["UnitName"].ToString();
            txtDescr.Text = dr["Description"].ToString();
            txtPurchaseRate.Text = dr["PurchaseRate"].ToString();
            txtSaleRate.Text = dr["SaleRate"].ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {// === VALIDATION ===
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
                MessageBox.Show("Please enter a valid Purchase Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurchaseRate.Focus();
                return;
            }

            if (!decimal.TryParse(txtSaleRate.Text, out decimal saleRate) || saleRate < 0)
            {
                MessageBox.Show("Please enter a valid Sale Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaleRate.Focus();
                return;
            }

            // === DUPLICATE CHECK (exclude current record) ===
            string checkQuery = @"
        SELECT COUNT(*) 
        FROM tblItem 
        WHERE ItemName = @ItemName AND HSN = @HSN AND ItemID <> @ItemID";

            SqlParameter[] checkParams = new SqlParameter[]
            {
        new SqlParameter("ItemName", txtItemName.Text.Trim()),
        new SqlParameter("HSN", txtHSN.Text.Trim()),
        new SqlParameter("ItemID", PrimaryKeyValue) // exclude current
            };

            int existingCount = Convert.ToInt32(cmd.ExecuteScalar(checkQuery, checkParams));
            if (existingCount > 0)
            {
                MessageBox.Show("An item with the same Name and HSN already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return;
            }

            // === UPDATE RECORD ===
            string updateQuery = @"
        UPDATE tblItem SET 
            HSN = @HSN,
            ItemName = @ItemName,
            UnitName = @UnitName,
            Description = @Descr,
            PurchaseRate = @PurchaseRate,
            SaleRate = @SaleRate,
            redt = GETDATE()
        WHERE ItemID = @ItemID";

            SqlParameter[] updateParams = new SqlParameter[]
            {
        new SqlParameter("HSN", txtHSN.Text.Trim()),
        new SqlParameter("ItemName", txtItemName.Text.Trim()),
        new SqlParameter("UnitName", txtUnitName.Text.Trim()),
        new SqlParameter("Descr", txtDescr.Text.Trim()),
        new SqlParameter("PurchaseRate", purchaseRate),
        new SqlParameter("SaleRate", saleRate),
        new SqlParameter("ItemID", PrimaryKeyValue)
            };

            try
            {
                int rows = cmd.ExecuteNonQuery(updateQuery, updateParams);
                if (rows > 0)
                {
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close or remove the form (if using panel)
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                        if (this.Parent.FindForm() is frmItemMaster parentForm)
                        {
                            parentForm.LoadItems();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Discard all changes?", "Cancel Edit",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                result = cmd.ExecuteNonQuery(
                    @"DELETE FROM tblItem WHERE ItemID=@ItemID",
                    new SqlParameter("ItemID", PrimaryKeyValue));

                if (result > 0)
                {
                    MessageBox.Show("Record deleted successfully.", "Item",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // tell parent to refresh
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtHSN_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(originalHSN) && txtHSN.Text != originalHSN)
            {
                MessageBox.Show("HSN cannot be changed for an existing item. You can only edit other fields.",
                    "HSN Fixed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtHSN.Text = originalHSN; // Reset to original
                txtHSN.Focus();
            }
        }
    }
}
