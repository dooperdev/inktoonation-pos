namespace POS.Forms.Auth
{
    partial class PinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinForm));
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnContinue = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtPin = new Guna.UI2.WinForms.Guna2TextBox();
            lblClose = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(btnContinue);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel2);
            guna2GroupBox1.Controls.Add(txtPin);
            guna2GroupBox1.Controls.Add(lblClose);
            guna2GroupBox1.CustomBorderColor = Color.FromArgb(26, 26, 29);
            guna2GroupBox1.CustomizableEdges = customizableEdges5;
            guna2GroupBox1.Dock = DockStyle.Fill;
            guna2GroupBox1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.White;
            guna2GroupBox1.Location = new Point(0, 0);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GroupBox1.Size = new Size(438, 199);
            guna2GroupBox1.TabIndex = 1;
            guna2GroupBox1.Text = "Authentication";
            // 
            // btnContinue
            // 
            btnContinue.BorderRadius = 5;
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.CustomizableEdges = customizableEdges1;
            btnContinue.DisabledState.BorderColor = Color.DarkGray;
            btnContinue.DisabledState.CustomBorderColor = Color.DarkGray;
            btnContinue.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnContinue.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnContinue.FillColor = Color.FromArgb(26, 26, 29);
            btnContinue.Font = new Font("Courier New", 9F);
            btnContinue.ForeColor = Color.White;
            btnContinue.HoverState.FillColor = Color.FromArgb(46, 46, 52);
            btnContinue.HoverState.ForeColor = Color.White;
            btnContinue.Location = new Point(29, 134);
            btnContinue.Name = "btnContinue";
            btnContinue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnContinue.Size = new Size(381, 48);
            btnContinue.TabIndex = 5;
            btnContinue.Text = "Continue";
            btnContinue.Click += btnContinue_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Courier New", 9F);
            guna2HtmlLabel2.ForeColor = Color.DarkGray;
            guna2HtmlLabel2.Location = new Point(29, 52);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(24, 17);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "PIN";
            // 
            // txtPin
            // 
            txtPin.BorderRadius = 5;
            txtPin.CustomizableEdges = customizableEdges3;
            txtPin.DefaultText = "";
            txtPin.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPin.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPin.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPin.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPin.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPin.Font = new Font("Courier New", 9F);
            txtPin.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPin.Location = new Point(29, 75);
            txtPin.Margin = new Padding(4, 3, 4, 3);
            txtPin.Name = "txtPin";
            txtPin.PlaceholderText = "Please enter your pin";
            txtPin.SelectedText = "";
            txtPin.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPin.Size = new Size(382, 44);
            txtPin.TabIndex = 1;
            // 
            // lblClose
            // 
            lblClose.BackColor = Color.Transparent;
            lblClose.Font = new Font("Courier New", 9F);
            lblClose.ForeColor = Color.FromArgb(210, 83, 83);
            lblClose.Location = new Point(344, 12);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(80, 17);
            lblClose.TabIndex = 0;
            lblClose.Text = "[Esc] Close";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // PinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 199);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PinForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PinForm";
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btnContinue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtPin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}