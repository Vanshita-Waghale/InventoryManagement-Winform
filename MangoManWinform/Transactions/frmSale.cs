using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoManWinform.Transactions
{
    public partial class frmSale : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        int EditingSaleStockID = 0;
        bool isUpdating = false;
        private object cmbItem;
        private string OriginalSaleNo = string.Empty;
        private bool isLoading = false;  // also helpful to prevent unwanted reloads


        public string SelectCommandText { get; private set; }
        public int EditingSaleID { get; private set; }
        public frmSale()
        {
            InitializeComponent();
            //FormTitle = "Sale";

            Commands = new MangoMaan.DAL.CommonCommands();
            object result = Commands.ExecuteScalar("Select Max(SaleNo) from tblSale");
            int NewSaleNo = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 0;
            NewSaleNo += 1;
        }

        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtItem.SelectedValue != null)
            {
                int ItemID = (int)txtItem.SelectedValue;
                string SelectedCommandText = "SELECT UnitName FROM tblItem WHERE ItemID = @ItemID";

                using (SqlConnection Conn = new SqlConnection(MangoMaan.DAL.CommonCommands.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SelectedCommandText, Conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
                        SqlDataAdapter ada = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        ada.Fill(dt);

                        lblUnit.Text = dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : string.Empty;
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {   //VALIDATION
            if (string.IsNullOrWhiteSpace(cmbtxtSaleNo.Text) || !int.TryParse(cmbtxtSaleNo.Text, out int saleNo))
            {
                MessageBox.Show("Please enter a valid Sale Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbtxtSaleNo.Focus();
                return;
            }

            if (txtItem.SelectedValue == null)
            {
                MessageBox.Show("Please select an Item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItem.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid Quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSaleRate.Text) || !decimal.TryParse(txtSaleRate.Text, out decimal rate) || rate < 0)
            {
                MessageBox.Show("Please enter a valid Sale Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaleRate.Focus();
                return;
            }

            if (cmbCustomerName.SelectedValue == null)
            {
                MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomerName.Focus();
                return;
            }

            int itemId = (int)txtItem.SelectedValue;
            int customerId = (int)cmbCustomerName.SelectedValue;
            CalculateSaleAmount();

            decimal saleAmt = 0m;
            if (!decimal.TryParse(txtSaleAmt.Text, out saleAmt))
                saleAmt = 0m;

            //  DUPLICATE CHECK 
            if (EditingSaleID == 0)
            {
                string dupCheckQuery = @"SELECT SaleID, Quantity FROM tblSale 
                                 WHERE SaleNo=@SaleNo AND ItemID=@ItemID AND CustomerID=@CustomerID";
                SqlParameter[] dupParams = new SqlParameter[]
                {
            new SqlParameter("@SaleNo", saleNo),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@CustomerID", customerId)
                };

                DataTable dupRow = Commands.GetData(dupCheckQuery, dupParams);

                if (dupRow.Rows.Count > 0)
                {
                    int existingSaleID = Convert.ToInt32(dupRow.Rows[0]["SaleID"]);
                    decimal existingQty = Convert.ToDecimal(dupRow.Rows[0]["Quantity"]);
                    decimal newQty = existingQty + qty;
                    decimal newAmt = newQty * rate;

                    string updateQuery = @"UPDATE tblSale 
                                   SET Quantity=@Quantity, SaleAmt=@SaleAmt 
                                   WHERE SaleID=@SaleID";

                    SqlParameter[] updateParams = new SqlParameter[]
                    {
                new SqlParameter("@Quantity", newQty),
                new SqlParameter("@SaleAmt", newAmt),
                new SqlParameter("@SaleID", existingSaleID)
                    };

                    Commands.ExecuteNonQuery(updateQuery, updateParams);
                    MessageBox.Show("Quantity updated for existing item.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm(true);
                    LoadSaleGrid();
                    return;
                }
            }

            // INSERT / UPDATE
            SqlParameter[] paras;
            string CommandText;

            if (EditingSaleID == 0) // Insert
            {
                CommandText = @"INSERT INTO tblSale(SaleNo, ItemID, CustomerID, Quantity, SaleRate, SaleAmt, Narration, SaleDate) 
                        VALUES(@SaleNo, @ItemID, @CustomerID, @Quantity, @SaleRate, @SaleAmt, @Narration, @SaleDate)";
                paras = new SqlParameter[]
                {
            new SqlParameter("@SaleNo", saleNo),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@CustomerID", customerId),
            new SqlParameter("@Quantity", qty),
            new SqlParameter("@SaleRate", rate),
            new SqlParameter("@SaleAmt", saleAmt),
            new SqlParameter("@Narration", txtNarration.Text.Trim()),
            new SqlParameter("@SaleDate", txtSaleDate.Value)
                };
            }
            else // Update
            {
                CommandText = @"UPDATE tblSale 
                        SET ItemID=@ItemID, CustomerID=@CustomerID, Quantity=@Quantity, 
                            SaleRate=@SaleRate, SaleAmt=@SaleAmt, Narration=@Narration, SaleDate=@SaleDate 
                        WHERE SaleID=@SaleID";
                paras = new SqlParameter[]
                {
            new SqlParameter("@SaleID", EditingSaleID),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@CustomerID", customerId),
            new SqlParameter("@Quantity", qty),
            new SqlParameter("@SaleRate", rate),
            new SqlParameter("@SaleAmt", saleAmt),
            new SqlParameter("@Narration", txtNarration.Text.Trim()),
            new SqlParameter("@SaleDate", txtSaleDate.Value)
                };
            }

            try
            {
                int result = Commands.ExecuteNonQuery(CommandText, paras);
                if (result > 0)
                {
                    MessageBox.Show("Sale entry saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(true);
                    LoadSaleGrid();
                }
                else
                {
                    MessageBox.Show("Error saving sale entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving sale entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbtxtSaleNo.Focus();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a record is selected
            if (EditingSaleID == 0)
            {
                MessageBox.Show("No Sale record selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this Sale record?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            // Execute delete
            SqlParameter param = new SqlParameter("@SaleID", EditingSaleID);
            string DeleteCommandText = "DELETE FROM tblSale WHERE SaleID = @SaleID";

            int result = Commands.ExecuteNonQuery(DeleteCommandText, param);

            if (result > 0)
            {
                MessageBox.Show("Sale record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true); // Reset form and hide delete button
            }
            else
            {
                string errorMessage = "Error deleting Sale record.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtItem.Focus(); // or cmbItem.Focus() depending on your control name
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
        private void txtItem_SelectedValueChanged(object sender, EventArgs e)
        {
          
            try
            {
                // --- Validate selection ---
                if (txtItem.SelectedValue == null ||
                    !int.TryParse(txtItem.SelectedValue.ToString(), out int itemId))
                {
                    lblUnit.Text = string.Empty;
                    return;
                }

                // --- Always load the unit name for the selected item ---
                lblUnit.Text = GetUnitName(itemId);

                // --- If editing an existing sale, do not override loaded data ---
                if (EditingSaleID != 0)
                    return;

                // --- For a new sale entry, clear fields that should not auto-fill ---
                txtQuantity.Clear();
                txtSaleRate.Clear();
               
                // Keep focus workflow smooth
                txtQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading item details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GetUnitName(int itemId)
        {
            object unit = Commands.ExecuteScalar(
                "SELECT UnitName FROM tblItem WHERE ItemID=@ItemID",
                new SqlParameter("ItemID", itemId)
            );
            return unit != null ? unit.ToString() : string.Empty;
        }

        private void ClearForm(bool resetItem = false)
        {
            if (resetItem && txtItem.Items.Count > 0)
                txtItem.SelectedIndex = -1;

            cmbCustomerName.SelectedIndex = -1;
            txtSaleDate.Value = DateTime.Now;
            txtQuantity.Clear();
            txtSaleRate.Clear();
            txtSaleAmt.Clear();
            txtNarration.Clear();
            EditingSaleStockID = 0;
            EditingSaleID = 0;
            btnDelete.Visible = false;

            // Only allow new SaleNo for new entries
            cmbtxtSaleNo.Enabled = true;
            GenerateSaleNo();
        }


        private void GenerateSaleNo()
        {
            object result = Commands.ExecuteScalar("SELECT MAX(SaleNo) FROM tblSale");
            int NewSaleNo = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
            cmbtxtSaleNo.Text = NewSaleNo.ToString();
        }
        private void LoadSaleGrid(string searchText = "")
        {
            string query = @"
        SELECT s.SaleID, 
               s.SaleNo, 
               i.ItemName, 
               c.CustomerName,   -- New column
               s.Quantity, 
               s.SaleRate, 
               s.SaleAmt, 
               s.Narration, 
               s.SaleDate
        FROM tblSale s
        INNER JOIN tblItem i ON s.ItemID = i.ItemID
        INNER JOIN tblCustomer c ON s.CustomerID = c.CustomerID";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query += " WHERE i.ItemName LIKE @Search OR c.CustomerName LIKE @Search OR s.SaleNo LIKE @Search";
            }

            query += " ORDER BY s.SaleNo";

            SqlParameter[] parameters = null;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@Search", "%" + searchText + "%")
                };
            }

            DataTable dt = Commands.GetData(query, parameters);
            dataGridView1.DataSource = dt;

            // Hide ID column
            if (dataGridView1.Columns["SaleID"] != null)
                dataGridView1.Columns["SaleID"].Visible = false;

            if (dt.Rows.Count == 0 && !string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("No records found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnLoad(EventArgs e)
        {    base.OnLoad(e);

            // Load Items into txtItem (assuming it's a ComboBox)
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");

            // Load Customers into cmbCustomerName
            cmbCustomerName.ValueMember = "CustomerID";
            cmbCustomerName.DisplayMember = "CustomerName";
            cmbCustomerName.DataSource = Commands.GetData("SELECT CustomerID, CustomerName FROM tblCustomer ORDER BY CustomerName");
            cmbCustomerName.SelectedIndex = -1; // No default selection

            // Clear and prepare form
            ClearForm(true);
            LoadSaleGrid();  // Show sales list
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            // If textbox is empty, show all records
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadSaleGrid(); // show all
            }
            else
            {
                LoadSaleGrid(searchText); // filter as user types
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSaleGrid(); // Reload all records
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            EditingSaleID = Convert.ToInt32(row.Cells["SaleID"].Value);

            isLoading = true;

            // Store and lock SaleNo
            OriginalSaleNo = row.Cells["SaleNo"].Value.ToString();
            cmbtxtSaleNo.Text = OriginalSaleNo;
            cmbtxtSaleNo.Enabled = false;

            // Set Item
            txtItem.SelectedValue = Commands.GetData(
                $"SELECT ItemID FROM tblSale WHERE SaleID = {EditingSaleID}"
            ).Rows[0][0];

            // Set Customer
            cmbCustomerName.SelectedValue = Commands.ExecuteScalar(
                "SELECT CustomerID FROM tblSale WHERE SaleID=@SaleID",
                new SqlParameter("@SaleID", EditingSaleID)
            );

            // Set other fields
            txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            txtSaleRate.Text = row.Cells["SaleRate"].Value.ToString();
            txtSaleAmt.Text = row.Cells["SaleAmt"].Value.ToString();
            txtNarration.Text = row.Cells["Narration"].Value.ToString();
            txtSaleDate.Value = Convert.ToDateTime(row.Cells["SaleDate"].Value);

            btnDelete.Visible = true;

            isLoading = false;
        }


        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            LoadSaleGrid(searchText);
        }
        private void cmbtxtSaleNo_TextChanged(object sender, EventArgs e)
        {

            if (EditingSaleID != 0 && cmbtxtSaleNo.Text != OriginalSaleNo)
            {
                MessageBox.Show("You cannot change the Sale Number for an existing entry.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbtxtSaleNo.Text = OriginalSaleNo; // reset back
            }
        }
       
        private void CalculateSaleAmount()
        {
            if (decimal.TryParse(txtQuantity.Text, out decimal qty) &&
                decimal.TryParse(txtSaleRate.Text, out decimal rate))
            {
                decimal amount = qty * rate;
                txtSaleAmt.Text = amount.ToString("F2");
            }
            else
            {
                txtSaleAmt.Text = "0.00";
            }
        }
        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            CalculateSaleAmount();

        }
        private void txtSaleRate_TextChanged_1(object sender, EventArgs e)
        {
            CalculateSaleAmount();
        }
        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            using (FrmAddNewItem addItemForm = new FrmAddNewItem())
            {
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload items from tblItem
                    txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
                    txtItem.DisplayMember = "ItemName";
                    txtItem.ValueMember = "ItemID";

                    // Auto-select the newly added item
                    txtItem.SelectedValue = addItemForm.NewItemID;
                }
            }
        }


        private void btnAddNewCust_Click(object sender, EventArgs e)
        {
            using (frmAddCust addCust = new frmAddCust())
            {
                if (addCust.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload customers
                    cmbCustomerName.DataSource = Commands.GetData("SELECT CustomerID, CustomerName FROM tblCustomer ORDER BY CustomerName");
                    cmbCustomerName.DisplayMember = "CustomerName";
                    cmbCustomerName.ValueMember = "CustomerID";


                    // Auto-select the new customer
                    cmbCustomerName.SelectedValue = addCust.NewCustomerID;
                }
            }
        }

        private void LoadCustomers()
        {
            DataTable dt = Commands.GetData("SELECT CustomerID, CustomerName FROM tblCustomer ORDER BY CustomerName");
            cmbCustomerName.DataSource = dt;
            cmbCustomerName.DisplayMember = "CustomerName";
            cmbCustomerName.ValueMember = "CustomerID";
            cmbCustomerName.SelectedIndex = -1;
        }

       

        private void txtNarration_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }
        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtSaleRate_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
