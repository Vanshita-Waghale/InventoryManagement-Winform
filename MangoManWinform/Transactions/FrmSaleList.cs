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
    public partial class FrmSaleList : Form
    {
        private MangoMaan.DAL.CommonCommands Commands;
        public FrmSaleList()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            this.Load += FrmSaleList_Load;
        }
        private void FrmSaleList_Load(object sender, EventArgs e)
        {
            LoadSales(); // Load all sales initially
        }

        private void LoadSales(string saleNo = "", string customerName = "", DateTime? fromDate = null, DateTime? toDate = null)
        {
            string query = @"
                SELECT s.SaleID, s.SaleNo, i.ItemName, c.CustomerName, 
                       s.Quantity, s.SaleRate, s.SaleAmt, s.SaleDate
                FROM tblSale s
                INNER JOIN tblItem i ON s.ItemID = i.ItemID
                INNER JOIN tblCustomer c ON s.CustomerID = c.CustomerID
                WHERE 1=1";

            SqlParameter[] parameters = new SqlParameter[] { };

            var paramList = new System.Collections.Generic.List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(saleNo))
            {
                query += " AND s.SaleNo LIKE @SaleNo";
                paramList.Add(new SqlParameter("@SaleNo", "%" + saleNo + "%"));
            }

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query += " AND c.CustomerName LIKE @CustomerName";
                paramList.Add(new SqlParameter("@CustomerName", "%" + customerName + "%"));
            }

            if (fromDate.HasValue)
            {
                query += " AND s.SaleDate >= @FromDate";
                paramList.Add(new SqlParameter("@FromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                query += " AND s.SaleDate <= @ToDate";
                paramList.Add(new SqlParameter("@ToDate", toDate.Value.Date));
            }

            query += " ORDER BY s.SaleDate DESC";

            parameters = paramList.ToArray();

            DataTable dt = Commands.GetData(query, parameters);
            dataGridView1.DataSource = dt;

            // Optional formatting
            if (dataGridView1.Columns["SaleID"] != null)
                dataGridView1.Columns["SaleID"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string saleNo = txtSaleNo.Text.Trim();
            string customerName = txtCustomerName.Text.Trim();
            DateTime? fromDate = dateTimePicker1.Checked ? dateTimePicker1.Value.Date : (DateTime?)null;
            DateTime? toDate = dateTimePicker2.Checked ? dateTimePicker2.Value.Date : (DateTime?)null;

            LoadSales(saleNo, customerName, fromDate, toDate);
        }

        private void txtSaleNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (frmSale addForm = new frmSale())
            {
                addForm.ShowDialog();
            }

            LoadSales(); // Refresh grid after adding

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0) return;

                int saleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SaleID"].Value);

                using (frmSale editForm = new frmSale())
                {
                    // Load the selected sale for editing
                    // Use reflection or add a public method/property in frmSale to set EditingSaleID
                    editForm.GetType().GetProperty("EditingSaleID").SetValue(editForm, saleID);
                    editForm.ShowDialog();
                }

                LoadSales(); // Refresh after editing
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            txtSaleNo.Clear();
            txtCustomerName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            LoadSales();
        }
    }
}
