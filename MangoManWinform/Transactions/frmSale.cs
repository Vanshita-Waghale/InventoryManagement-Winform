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
    public partial class frmSale : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        int EditingSaleStockID = 0;
        bool isUpdating = false;
        private object cmbItem;

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
        protected override void OnLoad(EventArgs e)
        {
            txtItem.ValueMember = "ItemID";
            txtItem.DisplayMember = "ItemName";
            txtItem.DataSource = Commands.GetData("SELECT ItemID, ItemName FROM tblItem ORDER BY ItemName");
            txtItem.SelectedIndexChanged += txtItem_SelectedIndexChanged;
            base.OnLoad(e);
            ClearForm(true);

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
        {
            // Trigger validation for all controls
            this.ValidateChildren();

            string Errors = null;
            Control ErrorControl = null;

            // Validate SaleNo
            if (string.IsNullOrWhiteSpace(cmbtxtSaleNo.Text) || !int.TryParse(cmbtxtSaleNo.Text, out _))
            {
                Errors += (Errors != null ? "\r\n" : "") + "Please enter a valid Sale Number.";
                if (ErrorControl == null) ErrorControl = cmbtxtSaleNo;
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

            // Validate SaleRate
            string rateError = errorProvider1.GetError(txtSaleRate);
            if (!string.IsNullOrWhiteSpace(rateError))
            {
                Errors += (Errors != null ? "\r\n" : "") + rateError;
                if (ErrorControl == null) ErrorControl = txtSaleRate;
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
                //new SqlParameter("SaleID", EditingSaleID),
                new SqlParameter("SaleNo", int.Parse(cmbtxtSaleNo.Text)),
                new SqlParameter("ItemID", (int)txtItem.SelectedValue),
                new SqlParameter("Quantity", decimal.Parse(txtQuantity.Text)),
                new SqlParameter("SaleRate", decimal.Parse(txtSaleRate.Text)),
                new SqlParameter("SaleAmt", decimal.Parse(txtSaleAmt.Text)),
                new SqlParameter("Narration", txtNarration.Text),
                new SqlParameter("SaleDate", txtSaleDate.Value)
            };

            // Insert or Update
            string CommandText = EditingSaleID == 0
            ? @"INSERT INTO tblSale(SaleNo,ItemID,Quantity,SaleRate,SaleAmt,Narration,SaleDate) 
               VALUES(@SaleNo,@ItemID,@Quantity,@SaleRate,@SaleAmt,@Narration,@SaleDate)"
            : @"UPDATE tblSale SET SaleNo=@SaleNo, ItemID=@ItemID, Quantity=@Quantity, 
               SaleRate=@SaleRate,SaleAmt=@SaleAmt,Narration=@Narration, SaleDate=@SaleDate 
               WHERE SaleID=@SaleID";


            // Execute
            int result = Commands.ExecuteNonQuery(CommandText, paras);

            if (result > 0)
            {
                MessageBox.Show("Sale entry saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(true);
            }
            else
            {
                string errorMessage = "Error saving Sale entry.";
                if (Commands.CurrentException is Exception ex)
                    errorMessage += "\r\nDetails: " + ex.Message;

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbtxtSaleNo.Focus();


        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmSaleSearch frmSearch = new frmSaleSearch())
            {
                if (frmSearch.ShowDialog() == DialogResult.OK)
                {
                    int selectedId = frmSearch.SelectedSaleID;

                    if (selectedId > 0)
                    {
                        DataTable res = Commands.GetData(
                            @"SELECT * FROM tblSale WHERE SaleID = @SaleID",
                            new SqlParameter("SaleID", selectedId));

                        if (res.Rows.Count > 0)
                        {
                            DataRow row = res.Rows[0];
                            EditingSaleID = Convert.ToInt32(row["SaleID"]);
                            cmbtxtSaleNo.Text = row["SaleNo"].ToString();
                            txtItem.SelectedValue = row["ItemID"];
                            txtQuantity.Text = row["Quantity"].ToString();
                            txtSaleRate.Text = row["SaleRate"].ToString();
                            txtSaleAmt.Text = row["SaleAmt"].ToString();
                            txtNarration.Text = row["Narration"].ToString();
                            txtSaleDate.Value = Convert.ToDateTime(row["SaleDate"]);
                            btnDelete.Visible = true;
                        }
                    }
                }
            }

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

       

        private void label6_Click(object sender, EventArgs e)
        {

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
            txtSaleRate.Text = "0";
            txtSaleAmt.Text = "0";
            txtNarration.Text = "";
            EditingSaleStockID = 0;
            EditingSaleID = 0;
            btnDelete.Visible = false;
            GenerateSaleNo();
        }

        
        private void GenerateSaleNo()
        {
            object result = Commands.ExecuteScalar("SELECT MAX(SaleNo) FROM tblSale");
            int NewSaleNo = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
            cmbtxtSaleNo.Text = NewSaleNo.ToString();
        }

    }
}
