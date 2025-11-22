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
    public partial class frmAddCust : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public int NewCustomerID { get; private set; } = 0;
        public frmAddCust()
        {
            InitializeComponent();
            
            Commands = new MangoMaan.DAL.CommonCommands();

            
        }
       
        private void btnSelect_Click_1(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string custName = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(custName))
            {
                MessageBox.Show("Please enter Customer Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            string query = "INSERT INTO tblCustomer(CustomerName) VALUES(@CustomerName); SELECT SCOPE_IDENTITY();";

            try
            {
                object newId = Commands.ExecuteScalar(query, new SqlParameter("@CustomerName", custName));
                if (newId != null)
                {
                    NewCustomerID = Convert.ToInt32(newId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblNameCustomer_Click(object sender, EventArgs e)
        {

        }

        private void frmAddCust_Load(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider1.SetError(txtCustomerName, "Customer Name is required.");
                e.Cancel = true; // prevent leaving the control
            }
            else
            {
                errorProvider1.SetError(txtCustomerName, null);
            }

        }
    }
}

