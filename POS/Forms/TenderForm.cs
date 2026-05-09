using POS.Models;
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
using System.Drawing.Printing;
using System.Globalization;

// Create a culture for Philippines

namespace POS.Forms
{
    public partial class TenderForm : Form
    {

        CultureInfo phCulture = new CultureInfo("en-PH");
        private List<CartItem> Items;
        private int UserId;
        private int CustomerId;
        private SalesRepository _salesRepo = new();
        private double TotalAmount;
        public double AmountReceived { get; private set; }
        public double Change { get; private set; }
        private string TransactionNumber;
        private string CashierName;
        private string CustomerName;
        public TenderForm(int _userId, int _customerId, List<CartItem> _items, double _totalAmount)
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            this.Items = _items;
            this.UserId = _userId;
            this.CustomerId = _customerId;
            this.TotalAmount = _totalAmount;
        }

        private void EnableKeyboardShortcuts()
        {
            this.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        break;
                }
            };
        }

        private string GetCashierName(int userId)
        {
            var repo = new UserRepository(); // create a repo for Users table
            var user = repo.GetUserById(userId);
            return user?.Name ?? "Unknown";
        }

        private string GetCustomerName(int customerId)
        {
            var repo = new CustomerRepository(); // repo for Customers table
            var customer = repo.GetById(customerId);
            return customer?.Name ?? "Guest";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Save transaction and get info
            var result = _salesRepo.SaveTransaction(UserId, CustomerId, Items, "Cash");

            // Assign info for receipt printing
            TransactionNumber = result.TransactionNumber;
            TotalAmount = result.TotalAmount;
            AmountReceived = double.Parse(txtReceiveAmount.Text);
            Change = AmountReceived - TotalAmount;

            // Assign cashier and customer names
            CashierName = GetCashierName(UserId); // you can fetch from Users table
            CustomerName = CustomerId == 0 ? "Guest" : GetCustomerName(CustomerId); // handle Guest

            MessageBox.Show("Transaction Complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Call print method
            PrintReceipt();

            this.DialogResult = DialogResult.OK;
        }

        private void txtReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtReceiveAmount.Text, out double received))
            {
                if (received >= TotalAmount)
                {
                    Change = received - TotalAmount;
                    lblChange.Text = Change.ToString("C", phCulture);
                }
                else
                {
                    lblChange.Text = "Insufficient amount";
                }
            }
            else
            {
                lblChange.Text = "0.00";
            }
        }

        private void TenderForm_Load(object sender, EventArgs e)
        {
            lblTotalAmount.Text = TotalAmount.ToString("C", phCulture);
        }

        private void PrintReceipt()
        {
            PrintDocument pd = new PrintDocument();

            // Attempt to set your thermal printer
            string thermalPrinterName = "Your 58mm Printer Name";

            if (PrinterSettings.InstalledPrinters.Cast<string>().Any(p => p == thermalPrinterName))
            {
                pd.PrinterSettings.PrinterName = thermalPrinterName;
            }
            else
            {
                // Printer not found
                MessageBox.Show("Thermal printer not found. You can preview or save the receipt as PDF.",
                                "Printer Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Draw receipt
            pd.PrintPage += (sender, e) =>
            {
                Graphics g = e.Graphics;

                float yPos = 0;
                int leftMargin = 0;
                int rightMargin = e.PageBounds.Width;
                Font font = new Font("Arial", 8);
                Font boldFont = new Font("Arial", 9, FontStyle.Bold);

                // Company header with logo
                yPos = POS.Helpers.PrintHelper.DrawReceiptHeader(g, yPos, leftMargin, rightMargin);

                // Transaction Info
                g.DrawString($"Transaction #: {TransactionNumber}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Date: {DateTime.Now}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Cashier: {CashierName}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Customer: {CustomerName}", font, Brushes.Black, leftMargin, yPos);
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
                foreach (var item in Items)
                {
                    g.DrawString(item.Name, font, Brushes.Black, leftMargin, yPos);
                    g.DrawString(item.Quantity.ToString(), font, Brushes.Black, leftMargin + 120, yPos);
                    g.DrawString(item.Price.ToString("C", phCulture), font, Brushes.Black, leftMargin + 160, yPos);
                    g.DrawString(item.Total.ToString("C", phCulture), font, Brushes.Black, leftMargin + 210, yPos);
                    yPos += 15;
                }

                yPos += 10;
                g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // Totals
                g.DrawString($"Total: {TotalAmount.ToString("C", phCulture)}", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Received: {AmountReceived.ToString("C", phCulture)}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Change: {Change.ToString("C", phCulture)}", font, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                g.DrawString("Payment Type: Cash", font, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                g.DrawString("Thank you for your purchase!", font, Brushes.Black, leftMargin, yPos);
            };

            // ✅ If printer exists, print directly
            if (PrinterSettings.InstalledPrinters.Cast<string>().Any(p => p == thermalPrinterName))
            {
                pd.Print(); // send directly to printer
            }
            else
            {
                // Show preview if printer not found
                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = pd;
                    preview.Width = 300;  // narrow preview for thermal printer
                    preview.Height = 500;
                    preview.ShowDialog();
                }

                // Optional: Save as PDF
                SaveReceiptAsPDF(pd);
            }
        }

        private void SaveReceiptAsPDF(PrintDocument pd)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"Receipt_{TransactionNumber}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                        pd.PrinterSettings.PrintToFile = true;
                        pd.PrinterSettings.PrintFileName = sfd.FileName;
                        pd.Print();

                        MessageBox.Show($"Receipt saved as PDF: {sfd.FileName}", "PDF Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
