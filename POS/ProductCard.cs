using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace POS
{
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();

            this.MouseEnter += (s, e) =>
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
            };

            this.MouseLeave += (s, e) =>
            {
                this.BackColor = Color.White;
            };

            btnAdd.Click += btnAdd_Click;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 20;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        public event EventHandler AddClicked;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
        }

        public string ProductName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string Price
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }

        public Image ProductImage
        {
            get { return picProduct.Image; }
            set { picProduct.Image = value; }
        }
    }
}
