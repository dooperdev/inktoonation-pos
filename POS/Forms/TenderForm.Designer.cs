namespace POS.Forms
{
    partial class TenderForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            txtReceiveAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblChange = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            lblTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblClose = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2GroupBox1.SuspendLayout();
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
            guna2GroupBox1.Controls.Add(txtReceiveAmount);
            guna2GroupBox1.Controls.Add(lblChange);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel4);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel3);
            guna2GroupBox1.Controls.Add(guna2Button1);
            guna2GroupBox1.Controls.Add(lblTotalAmount);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel2);
            guna2GroupBox1.Controls.Add(lblClose);
            guna2GroupBox1.CustomBorderColor = Color.FromArgb(26, 26, 29);
            guna2GroupBox1.CustomizableEdges = customizableEdges5;
            guna2GroupBox1.Dock = DockStyle.Fill;
            guna2GroupBox1.Font = new Font("Segoe UI", 9F);
            guna2GroupBox1.ForeColor = Color.White;
            guna2GroupBox1.Location = new Point(0, 0);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GroupBox1.Size = new Size(418, 266);
            guna2GroupBox1.TabIndex = 4;
            guna2GroupBox1.Text = "Tenders";
            // 
            // txtReceiveAmount
            // 
            txtReceiveAmount.BorderRadius = 5;
            txtReceiveAmount.CustomizableEdges = customizableEdges1;
            txtReceiveAmount.DefaultText = "";
            txtReceiveAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtReceiveAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtReceiveAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtReceiveAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtReceiveAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtReceiveAmount.Font = new Font("Courier New", 9F);
            txtReceiveAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtReceiveAmount.Location = new Point(217, 95);
            txtReceiveAmount.Margin = new Padding(4, 3, 4, 3);
            txtReceiveAmount.Name = "txtReceiveAmount";
            txtReceiveAmount.PlaceholderText = "0";
            txtReceiveAmount.SelectedText = "";
            txtReceiveAmount.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtReceiveAmount.Size = new Size(174, 44);
            txtReceiveAmount.TabIndex = 17;
            txtReceiveAmount.TextAlign = HorizontalAlignment.Center;
            txtReceiveAmount.TextChanged += txtReceiveAmount_TextChanged;
            // 
            // lblChange
            // 
            lblChange.BackColor = Color.Transparent;
            lblChange.Font = new Font("Courier New", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChange.ForeColor = Color.FromArgb(139, 174, 102);
            lblChange.Location = new Point(217, 145);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(83, 32);
            lblChange.TabIndex = 16;
            lblChange.Text = "00.00";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = Color.Black;
            guna2HtmlLabel4.Location = new Point(26, 152);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(69, 23);
            guna2HtmlLabel4.TabIndex = 14;
            guna2HtmlLabel4.Text = "Change";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(26, 103);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(157, 23);
            guna2HtmlLabel3.TabIndex = 13;
            guna2HtmlLabel3.Text = "Receive Amount";
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 5;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(139, 174, 102);
            guna2Button1.Font = new Font("Courier New", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.HoverState.FillColor = Color.FromArgb(122, 156, 87);
            guna2Button1.HoverState.ForeColor = Color.White;
            guna2Button1.Location = new Point(26, 206);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(365, 48);
            guna2Button1.TabIndex = 12;
            guna2Button1.Text = "Pay";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.BackColor = Color.Transparent;
            lblTotalAmount.Font = new Font("Courier New", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.FromArgb(139, 174, 102);
            lblTotalAmount.Location = new Point(217, 57);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(83, 32);
            lblTotalAmount.TabIndex = 10;
            lblTotalAmount.Text = "00.00";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Location = new Point(26, 60);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(135, 23);
            guna2HtmlLabel2.TabIndex = 8;
            guna2HtmlLabel2.Text = "Total Amount";
            // 
            // lblClose
            // 
            lblClose.BackColor = Color.Transparent;
            lblClose.Font = new Font("Courier New", 9F);
            lblClose.ForeColor = Color.FromArgb(210, 83, 83);
            lblClose.Location = new Point(321, 12);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(80, 17);
            lblClose.TabIndex = 9;
            lblClose.Text = "[Esc] Close";
            // 
            // TenderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 266);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TenderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TenderForm";
            Load += TenderForm_Load;
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChange;
        public Guna.UI2.WinForms.Guna2TextBox txtReceiveAmount;
    }
}