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

        int? PrimaryKeyValue;
        MangoMaan.DAL.CommonCommands cmd;
        private int result;

        public object ErrorControl { get; private set; }
        public object Conn { get; private set; }

        public frmItemMaster()
        {
            InitializeComponent();
            cmd = new MangoMaan.DAL.CommonCommands();
            LoadItems();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // to login in sql server we have username and password 
        // windows authentication - connection string for sql server (use trusted connection from google)


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate(false);
            this.ValidateChildren(ValidationConstraints.None);
            string Errors = null;
            string ErrorText = null;
            Control ErrorControl = null;

            ErrorText = errorProvider1.GetError(txtHSN);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtHSN; }

            }
            ErrorText = errorProvider1.GetError(txtItemName);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtItemName; }

            }
            ErrorText = errorProvider1.GetError(txtUnitName);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtUnitName; }

            }
            ErrorText = errorProvider1.GetError(txtPurchaseRate);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtPurchaseRate; }

            }
            ErrorText = errorProvider1.GetError(txtSaleRate);
            if (!string.IsNullOrWhiteSpace(ErrorText))
            {
                Errors += (!String.IsNullOrWhiteSpace(Errors) ? "\r\n" : "") + ErrorText;
                if (ErrorControl == null) { ErrorControl = txtSaleRate; }

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


            //System.Data.SqlClient.SqlCommand cmdNewItemID = new System.Data.SqlClient.SqlCommand("SELECT TOP 1 ItemID FROM tblItem ORDER BY ItemID DESC", Conn);
            //System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(cmdNewItemID);
            //System.Data.DataTable dtItemID = new System.Data.DataTable();
            //DA.Fill(dtItemID);

            //int NewItemID = 0;
            //if (dtItemID.Rows.Count > 0)
            //{
            //    NewItemID = (int)dtItemID.Rows[0][0];
            //}
            //NewItemID = NewItemID + 1;


            SqlParameter[] myParas = new SqlParameter[] { //Selecting Any part of code by using Alt+ Click
            new SqlParameter("ItemID", PrimaryKeyValue ?? 0),
            new SqlParameter("HSN", txtHSN.Text),
            new SqlParameter("ItemName", txtItemName.Text),
            new SqlParameter("UnitName", txtUnitName.Text),
            new SqlParameter("Descr", txtDescr.Text),
            new SqlParameter("PurchaseRate", decimal.Parse(txtPurchaseRate.Text)),
            new SqlParameter("SaleRate", decimal.Parse(txtSaleRate.Text)),
        };

            string CommandText = null;
            if (PrimaryKeyValue == null)
            {
                CommandText = @"
    INSERT INTO tblItem (ItemID, HSN, ItemName, UnitName, Description, PurchaseRate, SaleRate, rcdt)
    VALUES (@ItemID, @HSN, @ItemName, @UnitName, @Descr, @PurchaseRate, @SaleRate, GETDATE())";


            }
            else
            {
                
                CommandText = $@"UPDATE tblItem SET 
            HSN=@HSN,
            ItemName=@ItemName,
            UnitName=@UnitName,
            Description= @Descr,
            PurchaseRate= @PurchaseRate,
            SaleRate=@SaleRate,
            redt= GETDATE()
            Where ItemID = @ItemID";

            }
            result = cmd.ExecuteNonQuery(CommandText, myParas);
            
            if (result > 0)
            {
                MessageBox.Show("Record added", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadItems();
            }

            //            //  Always close the connection


        }
        private void ClearForm()
        {
            PrimaryKeyValue = null;
            txtHSN.Text = "";
            txtItemName.Text = "";
            txtUnitName.Text = "";
            txtDescr.Text = "";
            txtPurchaseRate.Text = "";
            txtSaleRate.Text = "";
            btnDelete.Visible = false;


            txtHSN.Focus(); // Optional: set focus to first field
        }

        private void txtHSN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHSN.Text))
            {
                errorProvider1.SetError(txtHSN, "Please enter HSN.");
            }
            else
            {
                errorProvider1.SetError(txtHSN, null);
            }

        }
        private void txtUnitName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                errorProvider1.SetError(txtUnitName, "Please enter HSN.");
            }
            else
            {
                errorProvider1.SetError(txtUnitName, null);
            }
        }
        //to replace any name first select thet word the click ctrl f and then select the selection and replce the name you want it would replace name.
        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                errorProvider1.SetError(txtItemName, "Please enter HSN.");
            }
            else
            {
                errorProvider1.SetError(txtItemName, null);
            }

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

        void LoadItems()
        {
            dataGridView1.DataSource = cmd.GetData("SELECT * FROM tblItem ORDER BY ItemName");     
            dataGridView1.Columns["ItemID"].Visible = false; // Hide ItemID column
               
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ItemId = (int)dataGridView1.Rows[e.RowIndex].Cells["ItemID"].Value;
           
                DataTable dt = (DataTable)cmd.GetData($"SELECT * FROM tblItem WHERE ItemID = {ItemId.ToString()}");

                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No record found.May be some other user deleted the selected record. Please refresh", "Item",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataRow dr = dt.Rows[0];
                PrimaryKeyValue = (int)dr["ItemID"];
                txtHSN.Text = dt.Rows[0]["HSN"].ToString();
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                txtUnitName.Text = dt.Rows[0]["UnitName"].ToString();
                txtDescr.Text = dt.Rows[0]["Description"].ToString();
                txtPurchaseRate.Text = dt.Rows[0]["PurchaseRate"].ToString();
                txtSaleRate.Text = dt.Rows[0]["SaleRate"].ToString();
                btnDelete.Visible = true;

        }
            

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var Result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2); //this or the below line will work same.
            //if (Result != DialogResult.Yes)
            //{
            //    return;
            //}
            if(MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            int result =cmd.ExecuteNonQuery($@"Delete from tblItem Where ItemID = @ItemID",
                new SqlParameter("ItemID", PrimaryKeyValue));
            
            if (result > 0)
            {
                MessageBox.Show("Record deleted", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadItems();
            }

            //            //  Always close the connection


        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

