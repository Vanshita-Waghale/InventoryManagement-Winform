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

namespace MangoManWinform.Transactions
{
    public partial class FrmOpeningStock : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public FrmOpeningStock()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            ClearForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("Select ItemID, ItemName from tblItem Order by ItemName");
            base.OnLoad(e);
        }

        private void FrmOpeningStock_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        bool isUpdating = false; // Prevents infinite loops between controls

        public SqlException CurrentException { get; private set; }
        public string DeleteCommandText { get; private set; }

        int EditingOpeningStockID;
        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isUpdating) return;

            //isUpdating = true;
            //textSelectedItemid.Text =
            //    (txtItem.SelectedIndex >= 0) ? txtItem.SelectedIndex.ToString() : "";
            //isUpdating = false;
            if (txtItem.SelectedIndex >= 0)
            {
                DataTable res = Commands.GetData(
                    "SELECT * FROM tblOpeningStock WHERE ItemID = @ItemID",
                    new SqlParameter("ItemID", (int)txtItem.SelectedValue)
                );

                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0];
                    EditingOpeningStockID = (int)row["OpeningStockID"];
                    txtQuantity.Text = row["Quantity"].ToString();
                    txtPurchaseRate.Text = row["PurchaseRate"].ToString();
                    txtNarration.Text = row["Narration"].ToString();
                    btnDelete.Visible = true; // Show delete button if record exists
                }
                else
                {
                    ClearForm(true);
                }
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
            this.ValidateChildren();
            this.Validate(false);
            this.ValidateChildren(ValidationConstraints.None);
            string Errors = null;
            string ErrorText = null;
            Control ErrorControl = null;

            ErrorText = errorProvider1.GetError(txtItem);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtItem; }

            }

            ErrorText = errorProvider1.GetError(txtQuantity);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtQuantity; }

            }
            ErrorText = errorProvider1.GetError(txtPurchaseRate);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtPurchaseRate; }

            }



            if (Errors != null)
            {
                MessageBox.Show($"Please fix following validation errors before saving.\r\n{Errors}", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (ErrorControl != null)
                {
                    ErrorControl.Focus();
                }
                return;
            }
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("OpeningStockID", EditingOpeningStockID),
                new SqlParameter("ItemID", (int)txtItem.SelectedValue),
                new SqlParameter("Quantity",  decimal.Parse(txtQuantity.Text)),
                new SqlParameter("PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
                new SqlParameter("Narration", txtNarration.Text),
            };
            string CommandText;
            if (EditingOpeningStockID == 0)
            {
                CommandText = @"Insert into tblOpeningStock( ItemID, Quantity, PurchaseRate, Narration, rcdt)
            Values(@ItemID, @Quantity, @PurchaseRate, @Narration, GetDate())";
            }
            else
            {
                CommandText = @"Update tblOpeningStock set ItemID = @ItemID, Quantity = @Quantity, PurchaseRate = @PurchaseRate, Narration = @Narration, redt = GetDate() where OpeningStockID = @OpeningStockID";

                int Result = Commands.ExecuteNonQuery(CommandText, paras);
                if (Result > 0)
                {
                    MessageBox.Show("Opening Stock saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    string errorMessage = "Error saving Opening Stock. Please try again.";

                    if (Commands.CurrentException is Exception ex)
                    {
                        errorMessage += "\r\nDetails: " + ex.Message;
                    }

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                txtItem.Focus();
            }
        }
        void ClearForm(bool PreventItem = false)
        {
            if (PreventItem)
            {
                txtItem.SelectedIndex = 0;
            }

            txtQuantity.Text = "0";
            txtPurchaseRate.Text = "0";
            txtNarration.Text = "";
            EditingOpeningStockID = 0;
            btnDelete.Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure  want to delete this Opening Stock record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }


            SqlParameter paraItemID = new SqlParameter("ItemID", (int)txtItem.SelectedValue);
            string ConflictCheckCommandText = "Select CASE WHEN EXISTS (SELECT OpeningStockID from tblOpeningStock where ItemID = @ItemID) THEN 1 ELSE 0 END";
            Commandscalar(ConflictCheckCommandText, paraItemID);
            //int ConflictCount = Commands.ExecuteScalar(ConflictCheckCommandText, new SqlParameter("OpeningStockID", EditingOpeningStockID));
            //if (EditingOpeningStockID == 0)
            //{
            //    MessageBox.Show("No Opening Stock record selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //string DeleteCommandText = @"Delete from tblOpeningStock where OpeningStockID = @OpeningStockID";
            int Result = Commands.ExecuteNonQuery(DeleteCommandText, new SqlParameter("OpeningStockID", EditingOpeningStockID));

            if (Result > 0)
            {
                MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
                                                                                        



            else               
            {
                string errorMessage = "Error saving Opening Stock. Please try again.";

                if (Commands.CurrentException is Exception ex)
                {
                    errorMessage += "\r\nDetails: " + ex.Message;
                }

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtItem.Focus();
        }

        private void Commandscalar(object conflictCheckCommand, object paraItemID)
        {
            throw new NotImplementedException();
        }
    }
}

