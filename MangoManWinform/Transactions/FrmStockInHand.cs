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
    public partial class FrmStockInHand : Form
    {
        private MangoMaan.DAL.CommonCommands Commands;

        public FrmStockInHand()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            this.Load += FrmStockInHand_Load;
        }

        private void FrmStockInHand_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker2.Value = DateTime.Now;
            LoadStockData();
        }

        private void LoadStockData(string searchText = "", DateTime? fromDate = null, DateTime? toDate = null)
        {
            string query = @"
                SELECT 
                    i.ItemID,
                    i.ItemName,
                    i.UnitName,
                    ISNULL(os.Quantity, 0) AS OpeningStockQty,
                    ISNULL(SUM(p.Quantity), 0) AS PurchasedQty,
                    ISNULL(SUM(s.Quantity), 0) AS SaleQty,
                    (ISNULL(os.Quantity, 0) + ISNULL(SUM(p.Quantity), 0) - ISNULL(SUM(s.Quantity), 0)) AS CurrentStock,
                    AVG(p.PurchaseRate) AS AvgPurchaseRate,
                    AVG(s.SaleRate) AS AvgSaleRate,
                    MAX(p.PurchaseDate) AS LastPurchaseDate,
                    MAX(s.SaleDate) AS LastSaleDate
                FROM tblItem i
                LEFT JOIN tblOpeningStock os ON i.ItemID = os.ItemID
                LEFT JOIN tblPurchase p ON i.ItemID = p.ItemID
                LEFT JOIN tblSale s ON i.ItemID = s.ItemID
                WHERE 1=1";

            var paramList = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query += " AND (i.ItemName LIKE @Search OR i.UnitName LIKE @Search)";
                paramList.Add(new SqlParameter("@Search", "%" + searchText + "%"));
            }

            if (fromDate.HasValue)
            {
                query += " AND (p.PurchaseDate >= @FromDate OR s.SaleDate >= @FromDate)";
                paramList.Add(new SqlParameter("@FromDate", fromDate.Value));
            }

            if (toDate.HasValue)
            {
                query += " AND (p.PurchaseDate <= @ToDate OR s.SaleDate <= @ToDate)";
                paramList.Add(new SqlParameter("@ToDate", toDate.Value));
            }

            query += " GROUP BY i.ItemID, i.ItemName, i.UnitName, os.Quantity ORDER BY i.ItemName;";

            DataTable dt = Commands.GetData(query, paramList.ToArray());

            // Calculate Stock Value
            if (!dt.Columns.Contains("StockValue"))
                dt.Columns.Add("StockValue", typeof(decimal));

            foreach (DataRow row in dt.Rows)
            {
                decimal currentStock = row["CurrentStock"] == DBNull.Value ? 0 : Convert.ToDecimal(row["CurrentStock"]);
                decimal avgRate = row["AvgPurchaseRate"] == DBNull.Value ? 0 : Convert.ToDecimal(row["AvgPurchaseRate"]);
                row["StockValue"] = currentStock * avgRate;
            }

            dataGridView1.DataSource = dt;
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dataGridView1.Columns["ItemID"] != null)
                dataGridView1.Columns["ItemID"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;

            // Format currency columns
            if (dataGridView1.Columns["AvgPurchaseRate"] != null)
                dataGridView1.Columns["AvgPurchaseRate"].DefaultCellStyle.Format = "N2";

            if (dataGridView1.Columns["StockValue"] != null)
                dataGridView1.Columns["StockValue"].DefaultCellStyle.Format = "N2";

            // Conditional formatting for low stock (optional)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["CurrentStock"].Value != null &&
                    Convert.ToDecimal(row.Cells["CurrentStock"].Value) <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            DateTime? fromDate = dateTimePicker1.Value;
            DateTime? toDate = dateTimePicker2.Value;

            LoadStockData(searchText, fromDate, toDate);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker2.Value = DateTime.Now;
            LoadStockData();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
