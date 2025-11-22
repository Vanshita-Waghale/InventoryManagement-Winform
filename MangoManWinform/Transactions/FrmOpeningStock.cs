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
        bool isLoading = false; // Prevent recursive events
        private object textSelectedItemid;

        public FrmOpeningStock()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            DeleteCommandText = "DELETE FROM tblOpeningStock WHERE OpeningStockID = @OpeningStockID";


        }

        protected override void OnLoad(EventArgs e)
        {
          base.OnLoad(e);

            // Load ComboBox items
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
            txtItem.SelectedIndexChanged += txtItem_SelectedIndexChanged;

            // Load all opening stock in grid automatically
            LoadOpeningStockGrid();

            ClearForm();
        }
        public SqlException CurrentException { get; private set; }
        public string DeleteCommandText { get; private set; }

        //int EditingOpeningStockID;
        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return; // Prevent recursion

            if (txtItem.SelectedValue == null || !int.TryParse(txtItem.SelectedValue.ToString(), out int itemId))
                return;

            isLoading = true;

            // Only load latest stock if NOT editing an existing record
            if (EditingOpeningStockID == 0)
            {
                DataTable res = Commands.GetData(
                    @"SELECT TOP 1 * FROM tblOpeningStock 
              WHERE ItemID = @ItemID 
              ORDER BY rcdt DESC",
                    new SqlParameter("ItemID", itemId)
                );

                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0];
                    txtQuantity.Text = row["Quantity"].ToString();
                    txtPurchaseRate.Text = row["PurchaseRate"].ToString();
                    txtNarration.Text = row["Narration"].ToString();
                }
                else
                {
                    txtQuantity.Clear();
                    txtPurchaseRate.Clear();
                    txtNarration.Clear();
                }
            }

            isLoading = false;
        }

        private void textSelectedItemid_TextChanged(object sender, EventArgs e)
        {

            if (txtItem.SelectedValue == null) return;

            int itemId = (int)txtItem.SelectedValue;

            txtQuantity.Text = "...";
            txtPurchaseRate.Text = "...";
            // whatever else you want to update
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

            // Validate Item
            string itemError = errorProvider1.GetError(txtItem);
            if (!string.IsNullOrWhiteSpace(itemError))
            {
                Errors += (Errors != null ? "\r\n" : "") + itemError;
                if (ErrorControl == null) ErrorControl = txtItem;
            }

            // Validate Quantity
            string quantityError = errorProvider1.GetError(txtQuantity);
            if (!string.IsNullOrWhiteSpace(quantityError))
            {
                Errors += (Errors != null ? "\r\n" : "") + quantityError;
                if (ErrorControl == null) ErrorControl = txtQuantity;
            }

            // Validate PurchaseRate
            string rateError = errorProvider1.GetError(txtPurchaseRate);
            if (!string.IsNullOrWhiteSpace(rateError))
            {
                Errors += (Errors != null ? "\r\n" : "") + rateError;
                if (ErrorControl == null) ErrorControl = txtPurchaseRate;
            }

            // If any errors exist, show message and return
            if (Errors != null)
            {
                MessageBox.Show($"Please fix the following errors:\r\n{Errors}", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorControl?.Focus();
                return;
            }

            // -------------------------------
            // Duplicate check for OpeningStock
            // -------------------------------
            string dupCheckQuery = @"SELECT OpeningStockID, Quantity FROM tblOpeningStock 
                             WHERE ItemID=@ItemID";
            SqlParameter[] dupParams = new SqlParameter[]
            {
        new SqlParameter("@ItemID", (int)txtItem.SelectedValue)
            };
            DataTable dupRow = Commands.GetData(dupCheckQuery, dupParams);

            if (dupRow.Rows.Count > 0 && EditingOpeningStockID == 0)
            {
                // Item already exists → update quantity
                int existingStockID = Convert.ToInt32(dupRow.Rows[0]["OpeningStockID"]);
                decimal existingQty = Convert.ToDecimal(dupRow.Rows[0]["Quantity"]);
                decimal newQty = existingQty + decimal.Parse(txtQuantity.Text);

                string updateQuery = @"UPDATE tblOpeningStock
                               SET Quantity=@Quantity, PurchaseRate=@PurchaseRate, Narration=@Narration
                               WHERE OpeningStockID=@OpeningStockID";

                SqlParameter[] updateParams = new SqlParameter[]
                {
            new SqlParameter("@Quantity", newQty),
            new SqlParameter("@PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
            new SqlParameter("@Narration", txtNarration.Text),
            new SqlParameter("@OpeningStockID", existingStockID)
                };

                Commands.ExecuteNonQuery(updateQuery, updateParams);

                MessageBox.Show("Quantity updated for existing item.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadOpeningStockGrid();
                return;
            }

            // -------------------------------
            // Else, insert/update as usual
            // -------------------------------
            SqlParameter[] paras = new SqlParameter[]
            {
        new SqlParameter("@OpeningStockID", EditingOpeningStockID),
        new SqlParameter("@ItemID", (int)txtItem.SelectedValue),
        new SqlParameter("@Quantity", decimal.Parse(txtQuantity.Text)),
        new SqlParameter("@PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
        new SqlParameter("@Narration", txtNarration.Text)
            };

            string CommandText = EditingOpeningStockID == 0
                ? @"INSERT INTO tblOpeningStock(ItemID, Quantity, PurchaseRate, Narration) 
           VALUES(@ItemID, @Quantity, @PurchaseRate, @Narration)"
                : @"UPDATE tblOpeningStock SET ItemID=@ItemID, Quantity=@Quantity, PurchaseRate=@PurchaseRate, 
           Narration=@Narration WHERE OpeningStockID=@OpeningStockID";

            try
            {
                int result = Commands.ExecuteNonQuery(CommandText, paras);
                if (result > 0)
                {
                    MessageBox.Show("Opening stock saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadOpeningStockGrid();
                }
                else
                {
                    MessageBox.Show("Error saving opening stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving opening stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtItem.Focus();
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
                ClearForm(); // Reset form and hide delete button
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

        private void ClearForm()
        {
            txtItem.SelectedIndex = -1;  // Clear ComboBox selection
            txtQuantity.Clear();
            txtPurchaseRate.Clear();
            txtNarration.Clear();
            EditingOpeningStockID = 0;   // Reset editing ID
            txtItem.Focus();
        }


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

        private void LoadOpeningStockGrid()
        {
            string query = @"
        SELECT os.OpeningStockID, i.ItemName, os.Quantity, os.PurchaseRate, os.Narration
        FROM tblOpeningStock os
        INNER JOIN tblItem i ON os.ItemID = i.ItemID
        ORDER BY i.ItemName";

            DataTable dt = Commands.GetData(query);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns["OpeningStockID"] != null)
                dataGridView1.Columns["OpeningStockID"].Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            string query = @"
        SELECT os.OpeningStockID, i.ItemName, os.Quantity, os.PurchaseRate, os.Narration
        FROM tblOpeningStock os
        INNER JOIN tblItem i ON os.ItemID = i.ItemID
        WHERE i.ItemName LIKE @Search OR os.OpeningStockID LIKE @Search
        ORDER BY i.ItemName";

            SqlParameter[] searchParams = new SqlParameter[]
            {
        new SqlParameter("Search", "%" + searchText + "%")
            };

            DataTable dt = Commands.GetData(query, searchParams);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No records found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns["OpeningStockID"] != null)
                dataGridView1.Columns["OpeningStockID"].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadOpeningStockGrid();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            EditingOpeningStockID = Convert.ToInt32(row.Cells["OpeningStockID"].Value);

            isLoading = true; // prevent SelectedIndexChanged from clearing form

            // Select ComboBox value based on ItemID
            txtItem.SelectedValue = Commands.GetData("SELECT ItemID FROM tblOpeningStock WHERE OpeningStockID=@ID",
                new SqlParameter("ID", EditingOpeningStockID)).Rows[0]["ItemID"];

            // Fill all other fields
            txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            txtPurchaseRate.Text = row.Cells["PurchaseRate"].Value.ToString();
            txtNarration.Text = row.Cells["Narration"].Value.ToString();

            btnDelete.Visible = true;

            isLoading = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadOpeningStockGrid();
        }
        private void label2_Click(object sender, EventArgs e)
        {

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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

       
    }
}

