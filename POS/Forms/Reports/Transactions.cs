using POS.Forms.Helper;
using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Reports
{
    public partial class Transactions : Form
    {
        private int _currentUserId;

        public Transactions(int userId)
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.CellClick += DgvTransactions_CellClick;
            _currentUserId = userId;
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
            viewCol.Width = 40;
            viewCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTransactions.Columns.Add(viewCol);

            // PRINT BUTTON (fixed size)
            DataGridViewButtonColumn printCol = new DataGridViewButtonColumn();
            printCol.Name = "PrintReceipt";
            printCol.HeaderText = "";
            printCol.Text = "Print";
            printCol.UseColumnTextForButtonValue = true;
            printCol.Width = 55;
            printCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            printCol.FlatStyle = FlatStyle.Flat;
            dgvTransactions.Columns.Add(printCol);

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

        private void DgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvTransactions.Columns[e.ColumnIndex].Name != "PrintReceipt") return;

            // PIN auth required for non-admin users
            var userRepo = new UserRepository();
            var currentUser = userRepo.GetUserById(_currentUserId);

            if (currentUser?.Role != "Admin")
            {
                using var pinForm = new PinForm();
                if (pinForm.ShowDialog() != DialogResult.OK || !pinForm.IsAuthorized)
                    return;
            }

            var row = dgvTransactions.Rows[e.RowIndex];
            int transactionId = Convert.ToInt32(row.Cells["TransactionID"].Value);
            string transactionNumber = row.Cells["TransactionNumber"].Value?.ToString() ?? "";
            string cashier = row.Cells["UserName"].Value?.ToString() ?? "";
            string customer = row.Cells["CustomerName"].Value?.ToString() ?? "";
            double totalAmount = Convert.ToDouble(row.Cells["TotalAmount"].Value);
            string paymentType = row.Cells["PaymentType"].Value?.ToString() ?? "";
            DateTime transactionDate = Convert.ToDateTime(row.Cells["TransactionDate"].Value);

            PrintTransactionReceipt(transactionId, transactionNumber, cashier, customer, totalAmount, paymentType, transactionDate);
        }

        private void PrintTransactionReceipt(int transactionId, string transactionNumber, string cashier,
            string customer, double totalAmount, string paymentType, DateTime transactionDate)
        {
            var items = _transactionRepo.GetOrderItems(transactionId);
            CultureInfo phCulture = new CultureInfo("en-PH");

            PrintDocument pd = new PrintDocument();
            string thermalPrinterName = "Your 58mm Printer Name";

            bool printerFound = PrinterSettings.InstalledPrinters.Cast<string>().Any(p => p == thermalPrinterName);

            if (printerFound)
            {
                pd.PrinterSettings.PrinterName = thermalPrinterName;
            }
            else
            {
                MessageBox.Show("Thermal printer not found. You can preview or save the receipt as PDF.",
                    "Printer Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                float yPos = 0;
                int leftMargin = 0;
                int rightMargin = e.PageBounds.Width;
                Font font = new Font("Arial", 8);
                Font boldFont = new Font("Arial", 9, FontStyle.Bold);

                // Header
                g.DrawString("Ink Toonations Printing Services", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                g.DrawString("Address Line", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString("Contact: 09123456789", font, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                // Transaction Info
                g.DrawString($"Transaction #: {transactionNumber}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Date: {transactionDate:MM/dd/yyyy hh:mm tt}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Cashier: {cashier}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Customer: {customer}", font, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                // Table Header
                g.DrawString("Item", boldFont, Brushes.Black, leftMargin, yPos);
                g.DrawString("Qty", boldFont, Brushes.Black, leftMargin + 120, yPos);
                g.DrawString("Price", boldFont, Brushes.Black, leftMargin + 160, yPos);
                g.DrawString("Total", boldFont, Brushes.Black, leftMargin + 210, yPos);
                yPos += 20;

                g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 5;

                // Items
                foreach (var item in items)
                {
                    g.DrawString(item.Name, font, Brushes.Black, leftMargin, yPos);
                    g.DrawString(item.Quantity.ToString(), font, Brushes.Black, leftMargin + 120, yPos);
                    g.DrawString(item.UnitPrice.ToString("C", phCulture), font, Brushes.Black, leftMargin + 160, yPos);
                    g.DrawString((item.Quantity * item.UnitPrice).ToString("C", phCulture), font, Brushes.Black, leftMargin + 210, yPos);
                    yPos += 15;
                }

                yPos += 10;
                g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // Totals
                g.DrawString($"Total: {totalAmount.ToString("C", phCulture)}", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                g.DrawString($"Payment Type: {paymentType}", font, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                g.DrawString("Thank you for your purchase!", font, Brushes.Black, leftMargin, yPos);
            };

            if (printerFound)
            {
                pd.Print();
            }
            else
            {
                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = pd;
                    preview.Width = 300;
                    preview.Height = 500;
                    preview.ShowDialog();
                }

                SaveReceiptAsPDF(pd, transactionNumber);
            }
        }

        private void SaveReceiptAsPDF(PrintDocument pd, string transactionNumber)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"Receipt_{transactionNumber}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                        pd.PrinterSettings.PrintToFile = true;
                        pd.PrinterSettings.PrintFileName = sfd.FileName;
                        pd.Print();

                        MessageBox.Show($"Receipt saved as PDF: {sfd.FileName}", "PDF Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save PDF: " + ex.Message);
            }
        }
    }
}
