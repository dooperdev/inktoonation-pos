using POS.Repository;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace POS.Forms.Reports
{
    public class ViewSaleForm : Form
    {
        public ViewSaleForm(int transactionId, string transactionNumber, string cashier,
            string customer, double totalAmount, string paymentType, DateTime transactionDate)
        {
            CultureInfo phCulture = new CultureInfo("en-PH");

            Text = $"Sale Items — {transactionNumber}";
            Size = new Size(620, 480);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(26, 26, 29);
            Font = new Font("Courier New", 9F);

            // Header panel
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.FromArgb(26, 26, 29),
                Padding = new Padding(12, 8, 12, 8)
            };

            var lblTitle = new Label
            {
                Text = $"Transaction #: {transactionNumber}",
                ForeColor = Color.White,
                Font = new Font("Courier New", 11F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(12, 10)
            };

            var lblInfo = new Label
            {
                Text = $"Date: {transactionDate:MM/dd/yyyy hh:mm tt}   |   Cashier: {cashier}   |   Customer: {customer}",
                ForeColor = Color.FromArgb(180, 180, 180),
                Font = new Font("Courier New", 8.5F),
                AutoSize = true,
                Location = new Point(12, 35)
            };

            var lblPayment = new Label
            {
                Text = $"Payment: {paymentType}   |   Total: {totalAmount.ToString("C", phCulture)}",
                ForeColor = Color.FromArgb(180, 220, 180),
                Font = new Font("Courier New", 9F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(12, 58)
            };

            headerPanel.Controls.AddRange(new Control[] { lblTitle, lblInfo, lblPayment });

            // DataGridView
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(35, 35, 40),
                GridColor = Color.FromArgb(60, 60, 70),
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Courier New", 9F)
            };

            // Header style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 32;

            // Row style
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 46);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 58);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dgv.RowTemplate.Height = 28;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Item", HeaderText = "Item", FillWeight = 200, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Qty", FillWeight = 50 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Unit Price", FillWeight = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", FillWeight = 100 });

            // Footer panel (grand total)
            var footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.FromArgb(26, 26, 29)
            };

            var lblTotal = new Label
            {
                Text = $"Grand Total:  {totalAmount.ToString("C", phCulture)}",
                ForeColor = Color.White,
                Font = new Font("Courier New", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(12, 10)
            };

            var btnClose = new Button
            {
                Text = "Close",
                Size = new Size(80, 28),
                Font = new Font("Courier New", 9F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 70),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(100, 88, 255);
            btnClose.Location = new Point(506, 6);
            btnClose.Click += (s, e) => this.Close();

            footerPanel.Controls.AddRange(new Control[] { lblTotal, btnClose });

            Controls.Add(dgv);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);

            // Load items
            var repo = new TransactionRepository();
            var items = repo.GetOrderItems(transactionId);

            foreach (var item in items)
            {
                double subtotal = item.Quantity * item.UnitPrice;
                dgv.Rows.Add(
                    item.Name,
                    item.Quantity,
                    item.UnitPrice.ToString("C", phCulture),
                    subtotal.ToString("C", phCulture)
                );
            }

            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }
    }
}
