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
    public partial class frmAddSupply: Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public int NewSupplierID { get; private set; } = 0;
        public frmAddSupply()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
           
        }

        private void frmPurchaseSearch_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoGenerateColumns = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string suppName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(suppName))
            {
                MessageBox.Show("Please enter Supplier Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            string query = "INSERT INTO tblSupplier(SupplierName) VALUES(@SupplierName); SELECT SCOPE_IDENTITY();";

            try
            {
                object newId = Commands.ExecuteScalar(query, new SqlParameter("@SupplierName", suppName));
                if (newId != null)
                {
                    NewSupplierID = Convert.ToInt32(newId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNameSupplier_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Supplier Name is required.");
                e.Cancel = true; // prevent leaving the control
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }

        }

        private void frmAddSupply_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            // Optional: focus textbox when form loads
            textBox1.Focus();
        }
    }
}
