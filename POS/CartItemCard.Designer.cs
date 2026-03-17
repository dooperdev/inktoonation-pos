namespace POS
{
    partial class CartItemCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picProduct = new PictureBox();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            lblPrice = new Label();
            lblName = new Label();
            btnDecrease = new Guna.UI2.WinForms.Guna2Button();
            lblQuantity = new Label();
            btnRemove = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // picProduct
            // 
            picProduct.Location = new Point(12, 12);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(81, 89);
            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.AutoRoundedCorners = true;
            btnAdd.BackColor = Color.Transparent;
            btnAdd.BorderRadius = 14;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(26, 26, 29);
            btnAdd.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.HoverState.FillColor = Color.FromArgb(66, 66, 72);
            btnAdd.HoverState.ForeColor = Color.White;
            btnAdd.Location = new Point(166, 69);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(31, 32);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "+";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(99, 42);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(42, 16);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "P8.12";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(99, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(134, 17);
            lblName.TabIndex = 5;
            lblName.Text = "Raspberry Tart";
            // 
            // btnDecrease
            // 
            btnDecrease.AutoRoundedCorners = true;
            btnDecrease.BackColor = Color.Transparent;
            btnDecrease.BorderRadius = 14;
            btnDecrease.Cursor = Cursors.Hand;
            btnDecrease.CustomizableEdges = customizableEdges3;
            btnDecrease.DisabledState.BorderColor = Color.DarkGray;
            btnDecrease.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDecrease.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDecrease.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDecrease.FillColor = Color.FromArgb(26, 26, 29);
            btnDecrease.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecrease.ForeColor = Color.White;
            btnDecrease.HoverState.FillColor = Color.FromArgb(66, 66, 72);
            btnDecrease.HoverState.ForeColor = Color.White;
            btnDecrease.Location = new Point(105, 69);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDecrease.Size = new Size(31, 32);
            btnDecrease.TabIndex = 8;
            btnDecrease.Text = "-";
            btnDecrease.Click += btnDecrease_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.Black;
            lblQuantity.Location = new Point(142, 78);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(18, 18);
            lblQuantity.TabIndex = 9;
            lblQuantity.Text = "0";
            // 
            // btnRemove
            // 
            btnRemove.AutoRoundedCorners = true;
            btnRemove.BackColor = Color.Transparent;
            btnRemove.BorderRadius = 14;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.CustomizableEdges = customizableEdges5;
            btnRemove.DisabledState.BorderColor = Color.DarkGray;
            btnRemove.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRemove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRemove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRemove.FillColor = Color.FromArgb(98, 4, 4);
            btnRemove.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.White;
            btnRemove.HoverState.FillColor = Color.FromArgb(130, 3, 3);
            btnRemove.HoverState.ForeColor = Color.White;
            btnRemove.Location = new Point(203, 69);
            btnRemove.Name = "btnRemove";
            btnRemove.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRemove.Size = new Size(31, 32);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "❌";
            btnRemove.Click += btnRemove_Click_1;
            // 
            // CartItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRemove);
            Controls.Add(lblQuantity);
            Controls.Add(btnDecrease);
            Controls.Add(btnAdd);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(picProduct);
            Name = "CartItemCard";
            Size = new Size(251, 113);
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProduct;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Label lblPrice;
        private Label lblName;
        private Guna.UI2.WinForms.Guna2Button btnDecrease;
        private Label lblQuantity;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}
