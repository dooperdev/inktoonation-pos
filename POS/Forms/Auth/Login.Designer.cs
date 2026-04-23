namespace POS.Forms.Auth
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnContinue = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
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
            guna2GroupBox1.Controls.Add(btnContinue);
            guna2GroupBox1.Controls.Add(lblpinlogin);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel3);
            guna2GroupBox1.Controls.Add(guna2HtmlLabel2);
            guna2GroupBox1.Controls.Add(txtPassword);
            guna2GroupBox1.Controls.Add(txtUsername);
            guna2GroupBox1.Controls.Add(lblClose);
            guna2GroupBox1.CustomBorderColor = Color.FromArgb(26, 26, 29);
            guna2GroupBox1.CustomizableEdges = customizableEdges7;
            guna2GroupBox1.Dock = DockStyle.Fill;
            guna2GroupBox1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.White;
            guna2GroupBox1.Location = new Point(0, 0);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2GroupBox1.Size = new Size(436, 320);
            guna2GroupBox1.TabIndex = 0;
            guna2GroupBox1.Text = "Login";
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
            btnContinue.Location = new Point(29, 223);
            btnContinue.Name = "btnContinue";
            btnContinue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnContinue.Size = new Size(381, 48);
            btnContinue.TabIndex = 5;
            btnContinue.Text = "Continue";
            btnContinue.Click += btnContinue_Click;
            //
            // lblpinlogin
            //
            lblpinlogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblpinlogin.BackColor = Color.Transparent;
            lblpinlogin.Cursor = Cursors.Hand;
            lblpinlogin.Font = new Font("Courier New", 9F, FontStyle.Underline);
            lblpinlogin.ForeColor = Color.FromArgb(94, 148, 255);
            lblpinlogin.Location = new Point(143, 282);
            lblpinlogin.Name = "lblpinlogin";
            lblpinlogin.Size = new Size(150, 17);
            lblpinlogin.TabIndex = 7;
            lblpinlogin.Text = "Login with PIN";
            lblpinlogin.Click += lblpinlogin_Click;
            //
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Courier New", 9F);
            guna2HtmlLabel3.ForeColor = Color.DarkGray;
            guna2HtmlLabel3.Location = new Point(29, 131);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(59, 17);
            guna2HtmlLabel3.TabIndex = 4;
            guna2HtmlLabel3.Text = "Password";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Courier New", 9F);
            guna2HtmlLabel2.ForeColor = Color.DarkGray;
            guna2HtmlLabel2.Location = new Point(29, 52);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(59, 17);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 5;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "angcuteko";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Courier New", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(29, 153);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Please enter your password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(382, 44);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.BorderRadius = 5;
            txtUsername.CustomizableEdges = customizableEdges5;
            txtUsername.DefaultText = "admin";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Courier New", 9F);
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(29, 75);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Please enter your username";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUsername.Size = new Size(382, 44);
            txtUsername.TabIndex = 1;
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
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 320);
            Controls.Add(guna2GroupBox1);
            Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClose;
        private Guna.UI2.WinForms.Guna2Button btnContinue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblpinlogin;
    }
}