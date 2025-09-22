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

namespace MangoManWinform.Transactions
{
    
    public partial class frmPurchase : Form

    {
        MangoMaan.DAL.CommonCommands Commands;
        int EditingOpeningStockID = 0;
        bool isUpdating = false;
        private object cmbItem;

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
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
            txtItem.SelectedIndexChanged += txtItem_SelectedIndexChanged;
            base.OnLoad(e);
            ClearForm(true);

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Trigger validation for all controls
            this.ValidateChildren();

            string Errors = null;
            Control ErrorControl = null;

            // Validate PurchaseNo
            if (string.IsNullOrWhiteSpace(cmbtxtPurchaseNo.Text) || !int.TryParse(cmbtxtPurchaseNo.Text, out _))
            {
                Errors += (Errors != null ? "\r\n" : "") + "Please enter a valid Purchase Number.";
                if (ErrorControl == null) ErrorControl = cmbtxtPurchaseNo;
            }

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

            // Prepare parameters
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("PurchaseID", EditingPurchaseID),
                new SqlParameter("PurchaseNo", int.Parse(cmbtxtPurchaseNo.Text)),
                new SqlParameter("ItemID", (int)txtItem.SelectedValue),
                new SqlParameter("Quantity", decimal.Parse(txtQuantity.Text)),
                new SqlParameter("PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
                new SqlParameter("Narration", txtNarration.Text),
                new SqlParameter("PurchaseDate", txtPurchaseDate.Value)
            };

            // Insert or Update
            string CommandText = EditingPurchaseID == 0
                ? @"INSERT INTO tblPurchase(PurchaseNo, ItemID, Quantity, PurchaseRate, Narration, PurchaseDate) 
            VALUES(@PurchaseNo, @ItemID, @Quantity, @PurchaseRate, @Narration, @PurchaseDate)"
                : @"UPDATE tblPurchase SET PurchaseNo=@PurchaseNo, ItemID=@ItemID, Quantity=@Quantity, 
            PurchaseRate=@PurchaseRate, Narration=@Narration, PurchaseDate=@PurchaseDate 
            WHERE PurchaseID=@PurchaseID";

            // Execute
            int result = Commands.ExecuteNonQuery(CommandText, paras);

            if (result > 0)
            {
                MessageBox.Show("Purchase entry saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true);
            }
            else
            {
                string errorMessage = "Error saving Purchase entry.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbtxtPurchaseNo.Focus();
        

        }
        private void txtItem_SelectedValueChanged(object sender, EventArgs e)
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
        private void ClearForm(bool resetItem = false)
        {
            if (resetItem && txtItem.Items.Count > 0)
                txtItem.SelectedIndex = 0;

            txtQuantity.Text = "0";
            txtPurchaseRate.Text = "0";
            txtNarration.Text = "";
            EditingOpeningStockID = 0;
            EditingPurchaseID = 0;   
            btnDelete.Visible = false;
            GeneratePurchaseNo();
        }


        private void GeneratePurchaseNo()
        {
            object result = Commands.ExecuteScalar("SELECT MAX(PurchaseNo) FROM tblPurchase");
            int NewPurchaseNo = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
            cmbtxtPurchaseNo.Text = NewPurchaseNo.ToString();
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

        private void textSelectedItemid_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtPurchaseDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textSelectedItemid_TextChanged(object sender, EventArgs e)
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

        }
        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private string cmbItem_SelectedValue(string v)
        {
            throw new NotImplementedException();
        }

        private void txtItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmPurchaseSearch frmSearch = new frmPurchaseSearch())
            {
                if (frmSearch.ShowDialog() == DialogResult.OK)
                {
                    int selectedId = frmSearch.SelectedPurchaseID;

                    if (selectedId > 0)
                    {
                        DataTable res = Commands.GetData(
                            @"SELECT * FROM tblPurchase WHERE PurchaseID = @PurchaseID",
                            new SqlParameter("PurchaseID", selectedId));

                        if (res.Rows.Count > 0)
                        {
                            DataRow row = res.Rows[0];
                            EditingPurchaseID = Convert.ToInt32(row["PurchaseID"]);
                            cmbtxtPurchaseNo.Text = row["PurchaseNo"].ToString();
                            txtItem.SelectedValue = row["ItemID"];
                            txtQuantity.Text = row["Quantity"].ToString();
                            txtPurchaseRate.Text = row["PurchaseRate"].ToString();
                            txtNarration.Text = row["Narration"].ToString();
                            txtPurchaseDate.Value = Convert.ToDateTime(row["PurchaseDate"]);
                            btnDelete.Visible = true;
                        }
                    }
                }
            }
        }
    }
}
