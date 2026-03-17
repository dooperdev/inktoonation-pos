using POS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class CartItemCard : UserControl
    {
        public CartItem Item { get; set; }

        // Callbacks
        public Action<CartItem> OnRemove { get; set; }
        public Action<CartItem> OnIncrease { get; set; }
        public Action<CartItem> OnDecrease { get; set; }

        public string ProductName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public Image ProductImage
        {
            get => picProduct.Image;
            set => picProduct.Image = value;
        }

        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        private int _quantity = 1;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                lblQuantity.Text = _quantity.ToString();
            }
        }

        public CartItemCard()
        {
            InitializeComponent();
        }

        // ➕ Increase button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                OnIncrease?.Invoke(Item);
            }
        }

        // ➖ Decrease button
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                OnDecrease?.Invoke(Item);
            }
        }

        // 🗑 Remove button
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                OnRemove?.Invoke(Item);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            OnIncrease?.Invoke(Item);
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            OnDecrease?.Invoke(Item);
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            OnRemove?.Invoke(Item);
        }
    }
}