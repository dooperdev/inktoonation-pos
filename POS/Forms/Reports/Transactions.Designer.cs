namespace POS.Forms.Reports
{
    partial class Transactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transactions));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnPrint = new Guna.UI2.WinForms.Guna2Button();
            btnExport = new Guna.UI2.WinForms.Guna2Button();
            btnClearFilter = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dgvTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblClose = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(btnPrint);
            guna2GroupBox1.Controls.Add(btnExport);
            guna2GroupBox1.Controls.Add(btnClearFilter);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel1);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel2);
            guna2GroupBox1.Controls.Add(dtTo);
            guna2GroupBox1.Controls.Add(dtFrom);
            guna2GroupBox1.Controls.Add(dgvTransactions);
            guna2GroupBox1.Controls.Add(txtSearch);
            guna2GroupBox1.Controls.Add(lblClose);
            guna2GroupBox1.CustomBorderColor = Color.FromArgb(26, 26, 29);
            guna2GroupBox1.CustomizableEdges = customizableEdges8;
            guna2GroupBox1.Dock = DockStyle.Fill;
            guna2GroupBox1.Font = new Font("Segoe UI", 9F);
            guna2GroupBox1.ForeColor = Color.White;
            guna2GroupBox1.Location = new Point(0, 0);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges9;
            guna2GroupBox1.Size = new Size(951, 554);
            guna2GroupBox1.TabIndex = 3;
            guna2GroupBox1.Text = "Transactions";
            // 
            // btnClearFilter
            // 
            btnClearFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearFilter.BackColor = Color.White;
            btnClearFilter.CheckedState.ImageSize = new Size(64, 64);
            btnClearFilter.HoverState.ImageSize = new Size(25, 25);
            btnClearFilter.Image = Properties.Resources.clear;
            btnClearFilter.ImageOffset = new Point(0, 0);
            btnClearFilter.ImageRotate = 0F;
            btnClearFilter.ImageSize = new Size(25, 25);
            btnClearFilter.Location = new Point(897, 56);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.PressedState.ImageSize = new Size(25, 25);
            btnClearFilter.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnClearFilter.Size = new Size(40, 37);
            btnClearFilter.TabIndex = 16;
            guna2HtmlToolTip1.SetToolTip(btnClearFilter, "Clear Filter");
            btnClearFilter.Click += btnClearFilter_Click;
            //
            // btnPrint
            //
            btnPrint.BorderRadius = 5;
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.CustomizableEdges = customizableEdges10;
            btnPrint.DisabledState.BorderColor = Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrint.FillColor = Color.FromArgb(26, 26, 29);
            btnPrint.Font = new Font("Courier New", 9F);
            btnPrint.ForeColor = Color.White;
            btnPrint.HoverState.FillColor = Color.FromArgb(46, 46, 52);
            btnPrint.HoverState.ForeColor = Color.White;
            btnPrint.Location = new Point(12, 101);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges11;
            btnPrint.Size = new Size(110, 35);
            btnPrint.TabIndex = 17;
            btnPrint.Text = "Print Report";
            guna2HtmlToolTip1.SetToolTip(btnPrint, "Print all visible transactions");
            btnPrint.Click += btnPrint_Click;
            //
            // btnExport
            //
            btnExport.BorderRadius = 5;
            btnExport.Cursor = Cursors.Hand;
            btnExport.CustomizableEdges = customizableEdges12;
            btnExport.DisabledState.BorderColor = Color.DarkGray;
            btnExport.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExport.FillColor = Color.FromArgb(34, 139, 34);
            btnExport.Font = new Font("Courier New", 9F);
            btnExport.ForeColor = Color.White;
            btnExport.HoverState.FillColor = Color.FromArgb(0, 100, 0);
            btnExport.HoverState.ForeColor = Color.White;
            btnExport.Location = new Point(130, 101);
            btnExport.Name = "btnExport";
            btnExport.ShadowDecoration.CustomizableEdges = customizableEdges13;
            btnExport.Size = new Size(130, 35);
            btnExport.TabIndex = 18;
            btnExport.Text = "Export to Excel";
            guna2HtmlToolTip1.SetToolTip(btnExport, "Export visible transactions to Excel");
            btnExport.Click += btnExport_Click;
            //
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(642, 66);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(19, 18);
            guna2HtmlLabel1.TabIndex = 15;
            guna2HtmlLabel1.Text = "To";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Location = new Point(368, 66);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(35, 18);
            guna2HtmlLabel2.TabIndex = 14;
            guna2HtmlLabel2.Text = "From";
            // 
            // dtTo
            // 
            dtTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtTo.Checked = true;
            dtTo.CustomizableEdges = customizableEdges2;
            dtTo.FillColor = Color.FromArgb(26, 26, 29);
            dtTo.Font = new Font("Segoe UI", 9F);
            dtTo.Format = DateTimePickerFormat.Long;
            dtTo.HoverState.BorderColor = Color.FromArgb(46, 46, 52);
            dtTo.Location = new Point(667, 56);
            dtTo.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtTo.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtTo.Name = "dtTo";
            dtTo.ShadowDecoration.CustomizableEdges = customizableEdges3;
            dtTo.Size = new Size(224, 39);
            dtTo.TabIndex = 13;
            dtTo.Value = new DateTime(2026, 3, 18, 1, 13, 30, 668);
            dtTo.ValueChanged += dtTo_ValueChanged;
            // 
            // dtFrom
            // 
            dtFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtFrom.Checked = true;
            dtFrom.CustomizableEdges = customizableEdges4;
            dtFrom.FillColor = Color.FromArgb(26, 26, 29);
            dtFrom.Font = new Font("Segoe UI", 9F);
            dtFrom.Format = DateTimePickerFormat.Long;
            dtFrom.HoverState.BorderColor = Color.FromArgb(46, 46, 52);
            dtFrom.Location = new Point(409, 56);
            dtFrom.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtFrom.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtFrom.Name = "dtFrom";
            dtFrom.ShadowDecoration.CustomizableEdges = customizableEdges5;
            dtFrom.Size = new Size(227, 39);
            dtFrom.TabIndex = 12;
            dtFrom.Value = new DateTime(2026, 3, 18, 1, 13, 30, 668);
            dtFrom.ValueChanged += dtFrom_ValueChanged;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeColumns = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(249, 248, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(26, 26, 29);
            dataGridViewCellStyle2.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(26, 26, 29);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(249, 248, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactions.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.Location = new Point(12, 145);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(249, 248, 246);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvTransactions.Size = new Size(925, 393);
            dgvTransactions.TabIndex = 11;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvTransactions.ThemeStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvTransactions.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactions.ThemeStyle.HeaderStyle.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTransactions.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTransactions.ThemeStyle.HeaderStyle.Height = 30;
            dgvTransactions.ThemeStyle.ReadOnly = true;
            dgvTransactions.ThemeStyle.RowsStyle.BackColor = Color.Red;
            dgvTransactions.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ThemeStyle.RowsStyle.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTransactions.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvTransactions.ThemeStyle.RowsStyle.Height = 25;
            dgvTransactions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderRadius = 5;
            txtSearch.CustomizableEdges = customizableEdges6;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Courier New", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconLeftSize = new Size(30, 30);
            txtSearch.IconRight = (Image)resources.GetObject("txtSearch.IconRight");
            txtSearch.IconRightSize = new Size(30, 30);
            txtSearch.Location = new Point(13, 56);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Please enter transaction no.";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtSearch.Size = new Size(348, 39);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.BackColor = Color.Transparent;
            lblClose.Font = new Font("Courier New", 9F);
            lblClose.ForeColor = Color.FromArgb(210, 83, 83);
            lblClose.Location = new Point(859, 12);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(80, 17);
            lblClose.TabIndex = 9;
            lblClose.Text = "[Esc] Close";
            // 
            // guna2HtmlToolTip1
            // 
            guna2HtmlToolTip1.AllowLinksHandling = true;
            guna2HtmlToolTip1.MaximumSize = new Size(0, 0);
            // 
            // Transactions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 554);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Transactions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transactions";
            WindowState = FormWindowState.Maximized;
            Load += Transactions_Load;
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactions;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClose;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtFrom;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnClearFilter;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnExport;
    }
}