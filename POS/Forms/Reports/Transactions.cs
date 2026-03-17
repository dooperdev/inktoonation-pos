using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Reports
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void EnableKeyboardShortcuts()
        {
            this.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        this.DialogResult = DialogResult.Cancel;
                        break;
                }
            };
        }

        private TransactionRepository _transactionRepo = new();

        private void RefreshTransactionGridView()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.Columns.Clear();

            dgvTransactions.RowTemplate.Height = 40;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTransactions.EnableHeadersVisualStyles = false;

            // ✅ Fill mode (IMPORTANT)
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ID (small)
            dgvTransactions.Columns.Add("TransactionID", "Id");
            dgvTransactions.Columns["TransactionID"].DataPropertyName = "TransactionID";
            dgvTransactions.Columns["TransactionID"].FillWeight = 30;

            // Transaction Number
            dgvTransactions.Columns.Add("TransactionNumber", "Transaction #");
            dgvTransactions.Columns["TransactionNumber"].DataPropertyName = "TransactionNumber";
            dgvTransactions.Columns["TransactionNumber"].FillWeight = 120;

            // Cashier
            dgvTransactions.Columns.Add("UserName", "Cashier");
            dgvTransactions.Columns["UserName"].DataPropertyName = "UserName";
            dgvTransactions.Columns["UserName"].FillWeight = 100;

            // Customer
            dgvTransactions.Columns.Add("CustomerName", "Customer");
            dgvTransactions.Columns["CustomerName"].DataPropertyName = "CustomerName";
            dgvTransactions.Columns["CustomerName"].FillWeight = 100;

            // Items (small)
            dgvTransactions.Columns.Add("TotalItems", "Items");
            dgvTransactions.Columns["TotalItems"].DataPropertyName = "TotalItems";
            dgvTransactions.Columns["TotalItems"].FillWeight = 50;

            // Total
            dgvTransactions.Columns.Add("TotalAmount", "Total");
            dgvTransactions.Columns["TotalAmount"].DataPropertyName = "TotalAmount";
            dgvTransactions.Columns["TotalAmount"].FillWeight = 80;

            // Payment
            dgvTransactions.Columns.Add("PaymentType", "Payment");
            dgvTransactions.Columns["PaymentType"].DataPropertyName = "PaymentType";
            dgvTransactions.Columns["PaymentType"].FillWeight = 70;

            // Date
            dgvTransactions.Columns.Add("TransactionDate", "Date");
            dgvTransactions.Columns["TransactionDate"].DataPropertyName = "TransactionDate";
            dgvTransactions.Columns["TransactionDate"].FillWeight = 120;

            // VIEW BUTTON (fixed size)
            DataGridViewImageColumn viewCol = new DataGridViewImageColumn();
            viewCol.Name = "View";
            viewCol.HeaderText = "";
            viewCol.Image = Properties.Resources.view;
            viewCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            viewCol.Width = 40; // fixed
            viewCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvTransactions.Columns.Add(viewCol);

            dgvTransactions.RowTemplate.Height = 25;

            dgvTransactions.DataSource = _transactionRepo.GetAll();
        }

        private void LoadFilteredTransactions()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;

            // Include whole day for "To"
            toDate = toDate.AddDays(1).AddSeconds(-1);

            string search = txtSearch.Text.Trim();

            dgvTransactions.DataSource = _transactionRepo.GetFiltered(fromDate, toDate, search);
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            RefreshTransactionGridView();

            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;

            LoadFilteredTransactions();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadFilteredTransactions();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadFilteredTransactions();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadFilteredTransactions();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;

            LoadFilteredTransactions();
        }
    }
}
