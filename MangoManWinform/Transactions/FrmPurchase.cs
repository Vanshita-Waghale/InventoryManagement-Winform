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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MangoManWinform.Transactions
{
  
  public partial class frmPurchase : Form

    {
        MangoMaan.DAL.CommonCommands Commands;
        int EditingOpeningStockID = 0;
        bool isUpdating = false;
        private object cmbItem;
        bool isLoading = false;
        private string OriginalPurchaseNo = string.Empty;



        public string SelectCommandText { get; private set; }
        public int EditingPurchaseID { get; private set; }

        public frmPurchase()
        {
            InitializeComponent();
            //FormTitle = "Purchase";

            Commands = new MangoMaan.DAL.CommonCommands();
            object result = Commands.ExecuteScalar("Select Max(PurchaseNo) from tblPurchase");
            int NewPurchaseNo = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 0;
            NewPurchaseNo += 1;

        }
        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);

            Commands = new MangoMaan.DAL.CommonCommands();

            // Bind suppliers
            DataTable dtSup = Commands.GetData("SELECT SupplierID, SupplierName FROM tblSupplier ORDER BY SupplierName");
            cmbSupplierName.DataSource = dtSup;
            cmbSupplierName.DisplayMember = "SupplierName";
            cmbSupplierName.ValueMember = "SupplierID";
            cmbSupplierName.SelectedIndex = -1;

            // Bind items
            DataTable dtItems = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
            txtItem.DataSource = dtItems;
            txtItem.DisplayMember = "ItemName";
            txtItem.ValueMember = "ItemID";
            txtItem.SelectedIndex = -1;

            // Load purchase grid and prepare form
            LoadPurchaseGrid();
            GeneratePurchaseNo();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        { 
            // VALIDATION
            if (string.IsNullOrWhiteSpace(cmbtxtPurchaseNo.Text) || !int.TryParse(cmbtxtPurchaseNo.Text, out int purchaseNo))
            {
                MessageBox.Show("Please enter a valid Purchase Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbtxtPurchaseNo.Focus();
                return;
            }

            if (txtItem.SelectedValue == null || !int.TryParse(txtItem.SelectedValue.ToString(), out int itemId))
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

            if (string.IsNullOrWhiteSpace(txtPurchaseRate.Text) || !decimal.TryParse(txtPurchaseRate.Text, out decimal rate) || rate < 0)
            {
                MessageBox.Show("Please enter a valid Purchase Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurchaseRate.Focus();
                return;
            }

            if (cmbSupplierName.SelectedValue == null || !int.TryParse(cmbSupplierName.SelectedValue.ToString(), out int supplierId))
            {
                MessageBox.Show("Please select a Supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplierName.Focus();
                return;
            }

            // compute amount and show in UI
            decimal purchaseAmount = qty * rate;
            txtPurchaseAmt.Text = purchaseAmount.ToString("F2");

            // DUPLICATE CHECK for new inserts
            if (EditingPurchaseID == 0)
            {
                string dupCheckQuery = @"SELECT PurchaseID, Quantity FROM tblPurchase 
                                 WHERE PurchaseNo=@PurchaseNo AND ItemID=@ItemID AND SupplierID=@SupplierID";
                SqlParameter[] dupParams = new SqlParameter[]
                {
            new SqlParameter("@PurchaseNo", purchaseNo),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@SupplierID", supplierId)
                };

                DataTable dupRow = Commands.GetData(dupCheckQuery, dupParams);
                if (dupRow.Rows.Count > 0)
                {
                    int existingPurchaseID = Convert.ToInt32(dupRow.Rows[0]["PurchaseID"]);
                    decimal existingQty = Convert.ToDecimal(dupRow.Rows[0]["Quantity"]);
                    decimal newQty = existingQty + qty;
                    decimal newAmt = newQty * rate;

                    string updateQuery = @"UPDATE tblPurchase 
                                   SET Quantity=@Quantity, PurchaseRate=@PurchaseRate, PurchaseAmount=@PurchaseAmount 
                                   WHERE PurchaseID=@PurchaseID";

                    SqlParameter[] updateParams = new SqlParameter[]
                    {
                new SqlParameter("@Quantity", newQty),
                new SqlParameter("@PurchaseRate", rate),
                new SqlParameter("@PurchaseAmount", newAmt),
                new SqlParameter("@PurchaseID", existingPurchaseID)
                    };

                    Commands.ExecuteNonQuery(updateQuery, updateParams);
                    MessageBox.Show("Quantity and Purchase Amount updated for existing item.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(true);
                    LoadPurchaseGrid();
                    return;
                }
            }

            // INSERT or UPDATE
            SqlParameter[] paras;
            string CommandText;

            if (EditingPurchaseID == 0) // Insert
            {
                CommandText = @"INSERT INTO tblPurchase 
                        (PurchaseNo, ItemID, SupplierID, Quantity, PurchaseRate, PurchaseAmount, Narration, PurchaseDate)
                        VALUES(@PurchaseNo, @ItemID, @SupplierID, @Quantity, @PurchaseRate, @PurchaseAmount, @Narration, @PurchaseDate)";
                paras = new SqlParameter[]
                {
            new SqlParameter("@PurchaseNo", purchaseNo),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@SupplierID", supplierId),
            new SqlParameter("@Quantity", qty),
            new SqlParameter("@PurchaseRate", rate),
            new SqlParameter("@PurchaseAmount", purchaseAmount),
            new SqlParameter("@Narration", txtNarration.Text.Trim()),
            new SqlParameter("@PurchaseDate", txtPurchaseDate.Value)
                };
            }
            else // Update existing
            {
                CommandText = @"UPDATE tblPurchase
                        SET ItemID=@ItemID, SupplierID=@SupplierID, Quantity=@Quantity,
                            PurchaseRate=@PurchaseRate, PurchaseAmount=@PurchaseAmount, Narration=@Narration, PurchaseDate=@PurchaseDate
                        WHERE PurchaseID=@PurchaseID";
                paras = new SqlParameter[]
                {
            new SqlParameter("@PurchaseID", EditingPurchaseID),
            new SqlParameter("@ItemID", itemId),
            new SqlParameter("@SupplierID", supplierId),
            new SqlParameter("@Quantity", qty),
            new SqlParameter("@PurchaseRate", rate),
            new SqlParameter("@PurchaseAmount", purchaseAmount),
            new SqlParameter("@Narration", txtNarration.Text.Trim()),
            new SqlParameter("@PurchaseDate", txtPurchaseDate.Value)
                };
            }

            try
            {
                int result = Commands.ExecuteNonQuery(CommandText, paras);
                if (result > 0)
                {
                    MessageBox.Show("Purchase entry saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(true);
                    LoadPurchaseGrid();
                }
                else
                {
                    MessageBox.Show("Error saving purchase entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Show detailed exception to help debugging
                MessageBox.Show("Error saving purchase entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbtxtPurchaseNo.Focus();
        }

        private void txtItem_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (isLoading) return;

            if (txtItem.SelectedValue == null || !int.TryParse(txtItem.SelectedValue.ToString(), out int itemId))
            {
                lblUnit.Text = string.Empty;
                return;
            }

            // Fetch and display the unit name for selected item
            lblUnit.Text = GetUnitName(itemId);

            // If it’s a new purchase entry (not editing an existing one),
            // optionally pre-fill the last purchase rate and quantity if available.
            if (EditingPurchaseID == 0)
            {
                string query = @"
            SELECT TOP 1 p.PurchaseRate, p.Quantity
            FROM tblPurchase p
            WHERE p.ItemID = @ItemID
            ORDER BY p.PurchaseDate DESC";

                DataTable res = Commands.GetData(query, new SqlParameter("@ItemID", itemId));

                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0];
                    txtPurchaseRate.Text = row["PurchaseRate"].ToString();
                    txtQuantity.Text = row["Quantity"].ToString();
                }
                else
                {
                    txtPurchaseRate.Clear();
                    txtQuantity.Clear();
                }
            }
        }

        private void CalculatePurchaseAmount()
        {
            if (decimal.TryParse(txtQuantity.Text, out decimal qty) &&
                decimal.TryParse(txtPurchaseRate.Text, out decimal rate))
            {
                decimal amount = qty * rate;
                txtPurchaseAmt.Text = amount.ToString("F2");
            }
            else
            {
                txtPurchaseAmt.Text = "0.00";
            }
        }

        private string GetUnitName(int itemId)
        {
            object unit = Commands.ExecuteScalar("SELECT UnitName FROM tblItem WHERE ItemID=@ItemID",
                new SqlParameter("ItemID", itemId));
            return unit != null ? unit.ToString() : string.Empty;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a record is selected
            if (EditingPurchaseID == 0)
            {
                MessageBox.Show("No Purchase record selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this Purchase record?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            // Execute delete
            SqlParameter param = new SqlParameter("@PurchaseID", EditingPurchaseID);
            string DeleteCommandText = "DELETE FROM tblPurchase WHERE PurchaseID = @PurchaseID";

            int result = Commands.ExecuteNonQuery(DeleteCommandText, param);

            if (result > 0)
            {
                MessageBox.Show("Purchase record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true); // Reset form and hide delete button
            }
            else
            {
                string errorMessage = "Error deleting Purchase record.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtItem.Focus(); // or cmbItem.Focus() depending on your control name
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Ensure the grid row has PurchaseID
            if (row.Cells["PurchaseID"].Value == null) return;

            if (!int.TryParse(row.Cells["PurchaseID"].Value.ToString(), out int pid)) return;

            EditingPurchaseID = pid;
            isLoading = true;

            // Lock PurchaseNo
            if (row.Cells["PurchaseNo"] != null && row.Cells["PurchaseNo"].Value != null)
            {
                OriginalPurchaseNo = row.Cells["PurchaseNo"].Value.ToString();
                cmbtxtPurchaseNo.Text = OriginalPurchaseNo;
                cmbtxtPurchaseNo.Enabled = false;
            }

            // Set Item (use ExecuteScalar safe)
            object itemIdObj = Commands.ExecuteScalar(
                "SELECT ItemID FROM tblPurchase WHERE PurchaseID=@PurchaseID",
                new SqlParameter("@PurchaseID", EditingPurchaseID)
            );
            if (itemIdObj != null && int.TryParse(itemIdObj.ToString(), out int itemId))
            {
                // Only set if txtItem datasource is already bound
                if (txtItem.DataSource != null)
                    txtItem.SelectedValue = itemId;
            }

            // Set Supplier
            object supplierIdObj = Commands.ExecuteScalar(
                "SELECT SupplierID FROM tblPurchase WHERE PurchaseID=@PurchaseID",
                new SqlParameter("@PurchaseID", EditingPurchaseID)
            );
            if (supplierIdObj != null && int.TryParse(supplierIdObj.ToString(), out int supplierId))
            {
                if (cmbSupplierName.DataSource != null)
                    cmbSupplierName.SelectedValue = supplierId;
            }

            // Other fields from grid
            if (row.Cells["Quantity"].Value != null) txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            if (row.Cells["PurchaseRate"].Value != null) txtPurchaseRate.Text = row.Cells["PurchaseRate"].Value.ToString();
            if (row.Cells["PurchaseAmount"] != null && row.Cells["PurchaseAmount"].Value != null) txtPurchaseAmt.Text = Convert.ToDecimal(row.Cells["PurchaseAmount"].Value).ToString("F2");
            if (row.Cells["Narration"].Value != null) txtNarration.Text = row.Cells["Narration"].Value.ToString();
            if (row.Cells["PurchaseDate"].Value != null) txtPurchaseDate.Value = Convert.ToDateTime(row.Cells["PurchaseDate"].Value);

            btnDelete.Visible = true;
            isLoading = false;
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            // If textbox is empty, show all records
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadPurchaseGrid(); // show all
            }
            else
            {
                LoadPurchaseGrid(searchText); // filter as user types
            }
        }

        private void LoadPurchaseGrid(string searchText = "")
        {
            string query = @"
                                SELECT p.PurchaseID,
                                       p.PurchaseNo,
                                       s.SupplierName,
                                       i.ItemName,
                                       p.Quantity,
                                       p.PurchaseRate,
                                       p.PurchaseAmount,
                                       p.Narration,
                                       p.PurchaseDate
                                FROM tblPurchase p
                                LEFT JOIN tblSupplier s ON p.SupplierID = s.SupplierID
                                LEFT JOIN tblItem i ON p.ItemID = i.ItemID";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query += " WHERE i.ItemName LIKE @Search OR s.SupplierName LIKE @Search OR p.PurchaseNo LIKE @Search";
            }

            query += " ORDER BY p.PurchaseDate DESC";

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

            // hide PK
            if (dataGridView1.Columns["PurchaseID"] != null)
                dataGridView1.Columns["PurchaseID"].Visible = false;

            // format amount column if present
            if (dataGridView1.Columns["PurchaseAmount"] != null)
                dataGridView1.Columns["PurchaseAmount"].DefaultCellStyle.Format = "F2";
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

            LoadPurchaseGrid(searchText);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();   // Clear search
            LoadPurchaseGrid();  // Reload all purchases
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
        private void ClearForm(bool resetItem = false)
        {
           if (resetItem && txtItem.Items.Count > 0)
                txtItem.SelectedIndex = -1;

            txtPurchaseDate.Value = DateTime.Now;
            txtQuantity.Clear();
            txtPurchaseRate.Clear();
            txtNarration.Clear();
            EditingPurchaseID = 0;
            btnDelete.Visible = false;

            // Only generate new PurchaseNo for new entries
            cmbtxtPurchaseNo.Enabled = true;
            GeneratePurchaseNo();
        }


        private void GeneratePurchaseNo()
        {
            object result = Commands.ExecuteScalar("SELECT MAX(PurchaseNo) FROM tblPurchase");
            int newPurchaseNo = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
            cmbtxtPurchaseNo.Text = newPurchaseNo.ToString();
        }

        private void cmbtxtPurchaseNo_TextChanged(object sender, EventArgs e)
        {

            if (EditingPurchaseID != 0 && cmbtxtPurchaseNo.Text != OriginalPurchaseNo)
            {
                MessageBox.Show("You cannot change the Purchase Number for an existing entry.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbtxtPurchaseNo.Text = OriginalPurchaseNo; // reset
            }

        }

        private void btnAddSupply_Click(object sender, EventArgs e)
        {
            using (frmAddSupply addSupply = new frmAddSupply())
            {
                if (addSupply.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload customers
                    cmbSupplierName.DataSource = Commands.GetData("SELECT SupplierID, SupplierName FROM tblSupplier ORDER BY SupplierName");
                    cmbSupplierName.DisplayMember = "SupplierName";
                    cmbSupplierName.ValueMember = "SupplierID";


                    // Auto-select the new customer
                    cmbSupplierName.SelectedValue = addSupply.NewSupplierID;
                }
            }
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

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblSupplierName_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtItem_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtPurchaseRate_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtNarration_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TxtItem_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void txtNarration_TextChanged(object sender, EventArgs e)
        {

        }
        private void FrmPurchase_Load(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculatePurchaseAmount();
        }
        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private string cmbItem_SelectedValue(string v)
        {
            throw new NotImplementedException();
        }
        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {
            CalculatePurchaseAmount();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
       
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPurchaseAmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
