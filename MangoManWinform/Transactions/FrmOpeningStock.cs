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
using MangoMaan.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MangoManWinform.Transactions
{
    public partial class FrmOpeningStock : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        int EditingOpeningStockID = 0;
        bool isUpdating = false;

        public FrmOpeningStock()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            DeleteCommandText = "DELETE FROM tblOpeningStock WHERE OpeningStockID = @OpeningStockID";


        }

        protected override void OnLoad(EventArgs e)
        {
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
            txtItem.SelectedIndexChanged += txtItem_SelectedIndexChanged;
            base.OnLoad(e);
            ClearForm(true);

        }

        private void FrmOpeningStock_Load(object sender, EventArgs e)
        {
            e.Cancel = true; // This will prevent the form from closing


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        //bool isUpdating = false; // Prevents infinite loops between controls

        public SqlException CurrentException { get; private set; }
        public string DeleteCommandText { get; private set; }

        //int EditingOpeningStockID;
        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtItem.SelectedValue == null || !int.TryParse(txtItem.SelectedValue.ToString(), out int itemId))
                return;

            DataTable res = Commands.GetData(
            @"SELECT TOP 1 * FROM tblOpeningStock 
             WHERE ItemID = @ItemID 
             ORDER BY rcdt DESC", // or use OpeningStockID DESC if rcdt isn't reliable
             new SqlParameter("ItemID", itemId)
             );

            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0];
                EditingOpeningStockID = Convert.ToInt32(row["OpeningStockID"]);
                txtQuantity.Text = row["Quantity"].ToString();
                txtPurchaseRate.Text = row["PurchaseRate"].ToString();
                txtNarration.Text = row["Narration"].ToString();
                btnDelete.Visible = true;
            }
            else
            {
                ClearForm(false);
            }
        }

        private void textSelectedItemid_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            if (int.TryParse(textSelectedItemid.Text, out int index) &&
                index >= 0 && index < txtItem.Items.Count)
            {
                isUpdating = true;
                txtItem.SelectedIndex = index;
                isUpdating = false;
            }
            else
            {
                isUpdating = true;
                txtItem.SelectedIndex = -1; // Deselect
                isUpdating = false;
            }
        }

        private void txtItem_Validating(object sender, CancelEventArgs e)
        {
            if (txtItem.SelectedIndex == -1) // -1 means no selection
            {
                errorProvider1.SetError(txtItem, "Please select an item.");
            }
            else
            {
                errorProvider1.SetError(txtItem, string.Empty); // clear error
            }
        }


        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(txtQuantity.Text, out value))
            {
                errorProvider1.SetError(txtQuantity, "Please enter a valid numeric value.");
            }
            else if (value <= 0)
            {
                errorProvider1.SetError(txtQuantity, "Quantity must be greater than zero.");
            }
            else
            {
                errorProvider1.SetError(txtQuantity, null);
            }
        }

        private void txtPurchaseRate_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(txtPurchaseRate.Text, out value))
            {
                errorProvider1.SetError(txtPurchaseRate, "Please enter a valid numeric value.");
            }

            else
            {
                errorProvider1.SetError(txtPurchaseRate, null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Trigger validation for all controls
            this.ValidateChildren();

            string Errors = null;
            Control ErrorControl = null;

            // Validate txtItem
            string itemError = errorProvider1.GetError(txtItem);
            if (!string.IsNullOrWhiteSpace(itemError))
            {
                Errors += itemError;
               
                if (ErrorControl == null)
                {
                    ErrorControl = txtItem;
                }
            }

            // Validate txtQuantity
            string quantityError = errorProvider1.GetError(txtQuantity);
            if (!string.IsNullOrWhiteSpace(quantityError))
            {
                Errors += (Errors != null ? "\r\n" : "") + quantityError;
                if (ErrorControl == null)
                {
                    ErrorControl = txtItem;
                }
            }

            // Validate txtPurchaseRate
            string rateError = errorProvider1.GetError(txtPurchaseRate);
            if (!string.IsNullOrWhiteSpace(rateError))
            {
                Errors += (Errors != null ? "\r\n" : "") + rateError;
                if (ErrorControl == null)
                {
                    ErrorControl = txtItem;
                }
            }

            // If any errors exist, show message and return
            if (Errors != null)
            {
                MessageBox.Show($"Please fix the following errors:\r\n{Errors}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorControl?.Focus();
                return;
            }

            // Prepare parameters
            SqlParameter[] paras = new SqlParameter[]
            {
        new SqlParameter("OpeningStockID", EditingOpeningStockID),
        new SqlParameter("ItemID", (int)txtItem.SelectedValue),
        new SqlParameter("Quantity", decimal.Parse(txtQuantity.Text)),
        new SqlParameter("PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
        new SqlParameter("Narration", txtNarration.Text),
            };

            // Choose command based on insert or update
            string CommandText = EditingOpeningStockID == 0
                ? @"INSERT INTO tblOpeningStock(ItemID, Quantity, PurchaseRate, Narration, rcdt)
           VALUES(@ItemID, @Quantity, @PurchaseRate, @Narration, GETDATE())"
                : @"UPDATE tblOpeningStock SET ItemID = @ItemID, Quantity = @Quantity, PurchaseRate = @PurchaseRate,
           Narration = @Narration, redt = GETDATE() WHERE OpeningStockID = @OpeningStockID";

            // Execute command
            int result = Commands.ExecuteNonQuery(CommandText, paras);

            // Show result
            if (result > 0)
            {
                MessageBox.Show("Opening Stock saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true);
            }
            else
            {
                string errorMessage = "Error saving Opening Stock.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtItem.Focus();
        }
        private void ClearForm(bool resetItem = false)
        {
            if (resetItem && txtItem.Items.Count > 0)
                txtItem.SelectedIndex = 0;

            txtQuantity.Text = "0";
            txtPurchaseRate.Text = "0";
            txtNarration.Text = "";
            EditingOpeningStockID = 0;
            btnDelete.Visible = false;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            // Ensure a record is selected
            if (EditingOpeningStockID == 0)
            {
                MessageBox.Show("No Opening Stock record selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this Opening Stock record?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            // Execute delete
            SqlParameter param = new SqlParameter("OpeningStockID", EditingOpeningStockID);
            int result = Commands.ExecuteNonQuery(DeleteCommandText, param);

            if (result > 0)
            {
                MessageBox.Show("Opening Stock record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true); // Reset form and hide delete button
            }
            else
            {
                string errorMessage = "Error deleting Opening Stock record.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtItem.Focus();
        }
        //    if (EditingOpeningStockID == 0)
        //    {
        //        MessageBox.Show("No record selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (MessageBox.Show("Are you sure you want to delete this Opening Stock record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        //        return;

        //    int result = Commands.ExecuteNonQuery(DeleteCommandText, new SqlParameter("OpeningStockID", EditingOpeningStockID));

        //    if (result > 0)
        //    {
        //        MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ClearForm(true);
        //    }
        //    else
        //    {
        //        string errorMessage = "Error deleting Opening Stock.";
        //        if (Commands.CurrentException is Exception ex)
        //            errorMessage += "\r\nDetails: " + ex.Message;

        //        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    txtItem.Focus();
        //}


        private void Commandscalar(object conflictCheckCommand, object paraItemID)
        {
            throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while exiting: " + ex.Message);
            }

        }
    }
}

