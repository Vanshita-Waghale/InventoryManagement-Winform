using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Data.SqlClient;
using System.Linq.Expressions;


namespace MangoManWinform.Items
{
    
    public partial class frmItemMaster : Form
    {
        MangoMaan.DAL.CommonCommands cmd;
        public frmItemMaster()
        {
            InitializeComponent();
            cmd = new MangoMaan.DAL.CommonCommands();
            LoadItems();
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

            // === DUPLICATE CHECK ===
            string checkQuery = @"
                SELECT COUNT(*) 
                FROM tblItem 
                WHERE ItemName = @ItemName AND HSN = @HSN";

            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("ItemName", txtItemName.Text.Trim()),
                new SqlParameter("HSN", txtHSN.Text.Trim())
            };

            int existingCount = Convert.ToInt32(cmd.ExecuteScalar(checkQuery, checkParams));
            if (existingCount > 0)
            {
                MessageBox.Show("This item already exists. Please check the HSN and Item Name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return;
            }

            // === INSERT NEW RECORD ===
            string insertQuery = @"
                INSERT INTO tblItem (HSN, ItemName, UnitName, Description, PurchaseRate, SaleRate, rcdt)
                VALUES (@HSN, @ItemName, @UnitName, @Descr, @PurchaseRate, @SaleRate, GETDATE())";

            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("HSN", txtHSN.Text.Trim()),
                new SqlParameter("ItemName", txtItemName.Text.Trim()),
                new SqlParameter("UnitName", txtUnitName.Text.Trim()),
                new SqlParameter("Descr", txtDescr.Text.Trim()),
                new SqlParameter("PurchaseRate", purchaseRate),
                new SqlParameter("SaleRate", saleRate)
            };

            int result = cmd.ExecuteNonQuery(insertQuery, insertParams);

            if (result > 0)
            {
                MessageBox.Show("Record added successfully.", "Item Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadItems();
            }
        }

        // ==================== Clear Form ====================
        private void ClearForm()
        {
            txtHSN.Clear();
            txtItemName.Clear();
            txtUnitName.Clear();
            txtDescr.Clear();
            txtPurchaseRate.Clear();
            txtSaleRate.Clear();
            txtHSN.Focus();
        }

        // ==================== Load Items ====================
        public void LoadItems()
        {
            dataGridView1.DataSource = cmd.GetData("SELECT * FROM tblItem ORDER BY ItemName");

            if (dataGridView1.Columns["ItemID"] != null)
                dataGridView1.Columns["ItemID"].Visible = false;
        }
        private void txtHSN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHSN.Text))
                errorProvider1.SetError(txtHSN, "Please enter HSN.");
            else
                errorProvider1.SetError(txtHSN, null);

        }
        private void txtUnitName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
                errorProvider1.SetError(txtItemName, "Please enter Item Name.");
            else
                errorProvider1.SetError(txtItemName, null);
        }
        //to replace any name first select thet word the click ctrl f and then select the selection and replce the name you want it would replace name.
        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
        errorProvider1.SetError(txtUnitName, "Please enter Unit Name.");
            else
        errorProvider1.SetError(txtUnitName, null);
        }


        private void txtPurchaseRate_Validating(object sender, CancelEventArgs e)
        {
            decimal v;
            if (!decimal.TryParse(txtPurchaseRate.Text, out v) || v < 0)
            {
                errorProvider1.SetError(txtPurchaseRate, "Please enter a valid numeric value in purchase rate.");
            }
            else
            {
                errorProvider1.SetError(txtPurchaseRate, null);
            }
        }

        private void txtSaleRate_Validating(object sender, CancelEventArgs e)
        {
            decimal v;
            if (!decimal.TryParse(txtSaleRate.Text, out v) || v < 0)
            {
                errorProvider1.SetError(txtSaleRate, "Please enter a valid numeric value in sale rate.");
            }
            else
            {
                errorProvider1.SetError(txtSaleRate, null);
            }
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string query = string.IsNullOrWhiteSpace(searchText)
                ? "SELECT * FROM tblItem ORDER BY ItemName"
                : @"SELECT * FROM tblItem
                    WHERE ItemName LIKE @Search
                       OR HSN LIKE @Search
                       OR UnitName LIKE @Search
                    ORDER BY ItemName";

            SqlParameter[] searchParams = string.IsNullOrWhiteSpace(searchText)
                ? null
                : new SqlParameter[] { new SqlParameter("Search", "%" + searchText + "%") };

            dataGridView1.DataSource = cmd.GetData(query, searchParams);

            if (dataGridView1.Columns["ItemID"] != null)
                dataGridView1.Columns["ItemID"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadItems();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int selectedItemId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ItemID"].Value);

                using (ItemEdit editForm = new ItemEdit(selectedItemId))
                {
                    editForm.StartPosition = FormStartPosition.CenterParent;

                    // Show popup and reload items only if user saved/deleted
                    if (editForm.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadItems();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void frmItemMaster_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void txtDescr_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHSN_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

