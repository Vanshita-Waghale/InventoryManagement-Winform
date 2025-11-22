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
    public partial class FrmPurchaseList : Form
    {
        private MangoMaan.DAL.CommonCommands Commands;
        public FrmPurchaseList()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            this.Load += FrmPurchaseList_Load;
        }
        private void FrmPurchaseList_Load(object sender, EventArgs e)
        {
            LoadPurchases(); // Load all purchases initially
        }
        private void LoadPurchases(string purchaseNo = "", string supplierName = "", DateTime? fromDate = null, DateTime? toDate = null)
        {
            string query = @"
                               SELECT p.PurchaseID, p.PurchaseNo, i.ItemName, s.SupplierName,
                       p.Quantity, p.PurchaseRate, p.PurchaseAmount, p.PurchaseDate
                FROM tblPurchase p
                INNER JOIN tblItem i ON p.ItemID = i.ItemID
                INNER JOIN tblSupplier s ON p.SupplierID = s.SupplierID
                WHERE 1=1";

            var paramList = new System.Collections.Generic.List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(purchaseNo))
            {
                query += " AND p.PurchaseNo LIKE @PurchaseNo";
                paramList.Add(new SqlParameter("@PurchaseNo", "%" + purchaseNo + "%"));
            }

            if (!string.IsNullOrWhiteSpace(supplierName))
            {
                query += " AND s.SupplierName LIKE @SupplierName";
                paramList.Add(new SqlParameter("@SupplierName", "%" + supplierName + "%"));
            }

            if (fromDate.HasValue)
            {
                query += " AND p.PurchaseDate >= @FromDate";
                paramList.Add(new SqlParameter("@FromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                query += " AND p.PurchaseDate <= @ToDate";
                paramList.Add(new SqlParameter("@ToDate", toDate.Value.Date));
            }

            query += " ORDER BY p.PurchaseDate DESC";

            SqlParameter[] parameters = paramList.ToArray();

            DataTable dt = Commands.GetData(query, parameters);
            dataGridView1.DataSource = dt;

            
            if (dataGridView1.Columns["PurchaseID"] != null)
                dataGridView1.Columns["PurchaseID"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string purchaseNo = txtPurchaseNo.Text.Trim();
            string supplierName = txtSupplierName.Text.Trim();
            DateTime? fromDate = dateTimePicker1.Checked ? dateTimePicker1.Value.Date : (DateTime?)null;
            DateTime? toDate = dateTimePicker2.Checked ? dateTimePicker2.Value.Date : (DateTime?)null;

            LoadPurchases(purchaseNo, supplierName, fromDate, toDate);

        }

        private void txtPurchaseNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (frmPurchase addForm = new frmPurchase())
            {
                addForm.ShowDialog();
            }

            LoadPurchases(); // Refresh grid after adding

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int purchaseID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PurchaseID"].Value);

            using (frmPurchase editForm = new frmPurchase())
            {
                // Load the selected purchase for editing
                editForm.GetType().GetProperty("EditingPurchaseID")?.SetValue(editForm, purchaseID);
                editForm.ShowDialog();
            }

            LoadPurchases(); // Refresh after editing

        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPurchaseNo.Clear();
            txtSupplierName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            LoadPurchases();

        }
    }
}
