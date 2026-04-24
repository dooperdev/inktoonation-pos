using ClosedXML.Excel;
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

            // PRINT BUTTON (image icon)
            DataGridViewImageColumn printCol = new DataGridViewImageColumn();
            printCol.Name = "PrintReceipt";
            printCol.HeaderText = "";
            printCol.Image = Properties.Resources.printer;
            printCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            printCol.Width = 40;
            printCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
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

            string colName = dgvTransactions.Columns[e.ColumnIndex].Name;

            var row = dgvTransactions.Rows[e.RowIndex];
            int transactionId = Convert.ToInt32(row.Cells["TransactionID"].Value);
            string transactionNumber = row.Cells["TransactionNumber"].Value?.ToString() ?? "";
            string cashier = row.Cells["UserName"].Value?.ToString() ?? "";
            string customer = row.Cells["CustomerName"].Value?.ToString() ?? "";
            double totalAmount = Convert.ToDouble(row.Cells["TotalAmount"].Value);
            string paymentType = row.Cells["PaymentType"].Value?.ToString() ?? "";
            DateTime transactionDate = Convert.ToDateTime(row.Cells["TransactionDate"].Value);

            if (colName == "View")
            {
                using var viewForm = new ViewSaleForm(transactionId, transactionNumber, cashier, customer, totalAmount, paymentType, transactionDate);
                viewForm.ShowDialog();
                return;
            }

            if (colName == "PrintReceipt")
            {
                // PIN auth required for non-admin users
                var userRepo = new UserRepository();
                var currentUser = userRepo.GetUserById(_currentUserId);

                if (currentUser?.Role != "Admin")
                {
                    using var pinForm = new PinForm();
                    if (pinForm.ShowDialog() != DialogResult.OK || !pinForm.IsAuthorized)
                        return;
                }

                PrintTransactionReceipt(transactionId, transactionNumber, cashier, customer, totalAmount, paymentType, transactionDate);
            }
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

        private List<POS.Models.Transactions> GetFilteredData()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date.AddDays(1).AddSeconds(-1);
            string search = txtSearch.Text.Trim();
            return _transactionRepo.GetFiltered(fromDate, toDate, search);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var data = GetFilteredData();
            if (data.Count == 0)
            {
                MessageBox.Show("No transactions to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintTransactionReport(data);
        }

        private void PrintTransactionReport(List<POS.Models.Transactions> data)
        {
            CultureInfo phCulture = new CultureInfo("en-PH");

            // Column definitions: header text and width in pixels
            string[] colHeaders = { "ID", "Transaction #", "Cashier", "Customer", "Items", "Total", "Payment", "Date" };
            int[] colWidths = { 45, 160, 135, 135, 50, 95, 90, 155 };

            int rowIndex = 0; // captured by lambda for pagination

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                int left = e.MarginBounds.Left;
                int top = e.MarginBounds.Top;
                int right = e.MarginBounds.Right;
                int bottom = e.MarginBounds.Bottom;

                Font titleFont = new Font("Arial", 13, FontStyle.Bold);
                Font subFont = new Font("Arial", 9);
                Font boldFont = new Font("Courier New", 8, FontStyle.Bold);
                Font cellFont = new Font("Courier New", 8);
                float yPos = top;
                int rowHeight = 18;

                // Page header — only on the first page
                if (rowIndex == 0)
                {
                    g.DrawString("Ink Toonations Printing Services", titleFont, Brushes.Black, left, yPos);
                    yPos += 22;
                    g.DrawString("Transaction Report", subFont, Brushes.Black, left, yPos);
                    yPos += 16;
                    g.DrawString($"Date Range: {dtFrom.Value:MM/dd/yyyy} — {dtTo.Value:MM/dd/yyyy}", subFont, Brushes.Black, left, yPos);
                    yPos += 16;
                    g.DrawString($"Printed: {DateTime.Now:MM/dd/yyyy hh:mm tt}   Total Transactions: {data.Count}", subFont, Brushes.Black, left, yPos);
                    yPos += 20;
                }

                // Column header row
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, 88, 255)), left, yPos, right - left, rowHeight + 2);
                int xPos = left;
                for (int i = 0; i < colHeaders.Length; i++)
                {
                    g.DrawString(colHeaders[i], boldFont, Brushes.White, xPos + 3, yPos + 3);
                    xPos += colWidths[i];
                }
                yPos += rowHeight + 4;

                // Data rows
                bool alternate = false;
                while (rowIndex < data.Count)
                {
                    if (yPos + rowHeight > bottom - 25) // leave room for footer
                    {
                        e.HasMorePages = true;
                        break;
                    }

                    var t = data[rowIndex];

                    if (alternate)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 252)), left, yPos, right - left, rowHeight);

                    xPos = left;
                    g.DrawString(t.TransactionID.ToString(), cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[0];
                    g.DrawString(t.TransactionNumber, cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[1];
                    g.DrawString(t.UserName, cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[2];
                    g.DrawString(t.CustomerName, cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[3];
                    g.DrawString(t.TotalItems.ToString(), cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[4];
                    g.DrawString(t.TotalAmount.ToString("C", phCulture), cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[5];
                    g.DrawString(t.PaymentType, cellFont, Brushes.Black, xPos + 3, yPos + 2); xPos += colWidths[6];
                    g.DrawString(t.TransactionDate.ToString("MM/dd/yyyy hh:mm tt"), cellFont, Brushes.Black, xPos + 3, yPos + 2);

                    yPos += rowHeight;
                    alternate = !alternate;
                    rowIndex++;
                }

                // Grand total — only on the last page
                if (rowIndex >= data.Count)
                {
                    yPos += 5;
                    g.DrawLine(Pens.Black, left, yPos, right, yPos);
                    yPos += 5;
                    double grandTotal = data.Sum(t => t.TotalAmount);
                    g.DrawString($"Grand Total: {grandTotal.ToString("C", phCulture)}", boldFont, Brushes.Black, left, yPos);
                }
            };

            using var preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var data = GetFilteredData();
            if (data.Count == 0)
            {
                MessageBox.Show("No transactions to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportToExcel(data);
        }

        private void ExportToExcel(List<POS.Models.Transactions> data)
        {
            try
            {
                using var sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = $"Transactions_{dtFrom.Value:MMddyyyy}_{dtTo.Value:MMddyyyy}.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                CultureInfo phCulture = new CultureInfo("en-PH");

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Transactions");

                // Report title block
                ws.Cell(1, 1).Value = "Ink Toonations Printing Services — Transaction Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 13;
                ws.Range(1, 1, 1, 8).Merge();

                ws.Cell(2, 1).Value = $"Date Range: {dtFrom.Value:MM/dd/yyyy} — {dtTo.Value:MM/dd/yyyy}";
                ws.Range(2, 1, 2, 8).Merge();

                ws.Cell(3, 1).Value = $"Exported: {DateTime.Now:MM/dd/yyyy hh:mm tt}   Total Transactions: {data.Count}";
                ws.Range(3, 1, 3, 8).Merge();

                // Column headers (row 5)
                int headerRow = 5;
                ws.Cell(headerRow, 1).Value = "ID";
                ws.Cell(headerRow, 2).Value = "Transaction #";
                ws.Cell(headerRow, 3).Value = "Cashier";
                ws.Cell(headerRow, 4).Value = "Customer";
                ws.Cell(headerRow, 5).Value = "Items";
                ws.Cell(headerRow, 6).Value = "Total";
                ws.Cell(headerRow, 7).Value = "Payment";
                ws.Cell(headerRow, 8).Value = "Date";

                var hdrRange = ws.Range(headerRow, 1, headerRow, 8);
                hdrRange.Style.Font.Bold = true;
                hdrRange.Style.Fill.BackgroundColor = XLColor.FromArgb(100, 88, 255);
                hdrRange.Style.Font.FontColor = XLColor.White;
                hdrRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Data rows
                double grandTotal = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    var t = data[i];
                    int row = headerRow + 1 + i;

                    ws.Cell(row, 1).Value = t.TransactionID;
                    ws.Cell(row, 2).Value = t.TransactionNumber;
                    ws.Cell(row, 3).Value = t.UserName;
                    ws.Cell(row, 4).Value = t.CustomerName;
                    ws.Cell(row, 5).Value = t.TotalItems;
                    ws.Cell(row, 6).Value = t.TotalAmount;
                    ws.Cell(row, 6).Style.NumberFormat.Format = "₱#,##0.00";
                    ws.Cell(row, 7).Value = t.PaymentType;
                    ws.Cell(row, 8).Value = t.TransactionDate.ToString("MM/dd/yyyy hh:mm tt");

                    // Alternate row shading
                    if (i % 2 == 1)
                        ws.Range(row, 1, row, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(245, 245, 252);

                    grandTotal += t.TotalAmount;
                }

                // Grand total row
                int totalRow = headerRow + 1 + data.Count + 1;
                ws.Cell(totalRow, 5).Value = "Grand Total:";
                ws.Cell(totalRow, 5).Style.Font.Bold = true;
                ws.Cell(totalRow, 6).Value = grandTotal;
                ws.Cell(totalRow, 6).Style.Font.Bold = true;
                ws.Cell(totalRow, 6).Style.NumberFormat.Format = "₱#,##0.00";

                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                MessageBox.Show($"Exported successfully:\n{sfd.FileName}", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
