using POS.Forms.Customers;
using POS.Forms.Helper;
using POS.Forms.Inventory;
using POS.Forms.Products;
using POS.Forms.Users;
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
using System.Drawing.Imaging;
using POS.Forms.Reports;
using System.Globalization;

namespace POS.Forms
{
    public partial class POSForm : Form
    {
        public POSForm(int userId)
        {
            InitializeComponent();
            UserId = userId;
        }
        CultureInfo phCulture = new CultureInfo("en-PH");
        private ProductRepository _productRepo = new();
        private List<CartItem> cart = new List<CartItem>();

        private int customerId = 0;
        private string customerName = "Guest";
        private int UserId = 0;
        private void LoadProductCards(string filter = "")
        {
            flowProducts.Controls.Clear(); // Clear previous cards

            List<POS.Models.Products> products = _productRepo.GetAll();

            // Apply search filter
            if (!string.IsNullOrEmpty(filter))
            {
                products = products
                    .Where(p => p.Name.ToLower().Contains(filter) ||
                                p.Description.ToLower().Contains(filter) ||
                                p.Barcode.ToLower().Contains(filter))
                    .ToList();
            }

            foreach (var product in products)
            {
                ProductCard card = new ProductCard();
                card.ProductName = product.Name;
                card.Price = product.Price.ToString("F2");

                string imgPath = product.ImagePath;
                if (File.Exists(imgPath))
                    card.ProductImage = Image.FromFile(imgPath);
                else
                    card.ProductImage = null;

                card.Tag = product.ProductId;

                // ✅ Check stock
                int stock = _productRepo.GetStock(product.ProductId);
                if (stock == 0)
                {
                    card.Enabled = false; // Disable the card if no stock
                }
                else
                {
                    card.AddClicked += Card_AddClicked;
                }

                flowProducts.Controls.Add(card);
            }
        }

        private void Card_AddClicked(object sender, EventArgs e)
        {
            if (sender is ProductCard card)
            {
                int productId = (int)card.Tag;
                string productName = card.ProductName;
                double price = Convert.ToDouble(card.Price);
                Image productImage = card.ProductImage;

                AddToCart(productName, price, productImage, productId);
            }
        }

        private void AddToCart(string name, double price, Image image, int productId)
        {
            int availableStock = _productRepo.GetStock(productId);

            var existingItem = cart.FirstOrDefault(x => x.Name == name);

            if (existingItem != null)
            {
                if (existingItem.Quantity + 1 > availableStock)
                {
                    MessageBox.Show("Cannot add more units. Stock limit reached!");
                    return;
                }
                existingItem.Quantity++;

                foreach (CartItemCard card in flowCart.Controls)
                {
                    if (card.Item.Name == name)
                    {
                        card.Quantity = existingItem.Quantity;
                        break;
                    }
                }
            }
            else
            {
                if (availableStock <= 0)
                {
                    MessageBox.Show("This product is out of stock!");
                    return;
                }

                var newItem = new CartItem
                {
                    Name = name,
                    Price = price,
                    Quantity = 1
                };

                cart.Add(newItem);

                var cartCard = new CartItemCard
                {
                    Item = newItem,
                    ProductName = name,
                    Price = price.ToString("F2"),
                    ProductImage = image,
                    Quantity = 1
                };

                // Callbacks
                cartCard.OnIncrease = (item) =>
                {
                    if (item.Quantity + 1 > _productRepo.GetStock(productId))
                    {
                        MessageBox.Show("Cannot add more units. Stock limit reached!");
                        return;
                    }
                    item.Quantity++;
                    cartCard.Quantity = item.Quantity;
                    RefreshCartUI();
                };

                cartCard.OnDecrease = (item) =>
                {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                        cartCard.Quantity = item.Quantity;
                    }
                    else
                    {
                        cart.Remove(item);
                        flowCart.Controls.Remove(cartCard);
                    }
                    RefreshCartUI();
                };

                cartCard.OnRemove = (item) =>
                {
                    cart.Remove(item);
                    flowCart.Controls.Remove(cartCard);
                    RefreshCartUI();
                };

                flowCart.Controls.Add(cartCard);
                flowCart.Controls.SetChildIndex(cartCard, 0);
            }

            RefreshCartUI();
        }

        private void RefreshCartUI()
        {
            double subtotal = 0;

            foreach (var item in cart)
            {
                subtotal += item.Price * item.Quantity;
            }

            double total = subtotal;
            lblTotal.Text = subtotal.ToString("C", phCulture);
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            LoadProductCards();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            LoadProductCards(searchText);
        }

        private void btnTenders_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double totalAmount = cart.Sum(x => x.Price * x.Quantity);
                var tenders = new TenderForm(UserId, customerId, cart, totalAmount);
                var result = tenders.ShowDialog();

                if (result == DialogResult.OK)
                {

                    cart.Clear();
                    flowCart.Controls.Clear();
                    LoadProductCards();
                    RefreshCartUI();
                    customerId = 0;
                    customerName = "Guest";
                }
            }
        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            // Clear the cart list
            cart.Clear();

            // Remove all CartItemCards from the FlowLayoutPanel
            flowCart.Controls.Clear();

            // Refresh subtotal/total
            RefreshCartUI();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var customer = new CustomerForm();
            var result = customer.ShowDialog();

            if (result == DialogResult.OK)
            {
                customerId = customer.CustomerId;
                customerName = customer.CustomerName;
                lblCustomerName.Text = customerName;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var products = new ProductForm();
            var result = products.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadProductCards();
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var inventory = new InventoryForm();
            var result = inventory.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                LoadProductCards();
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (UserId == 0)
            {
                var user = new UserForm();
                var result = user.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    LoadProductCards();
                }
            }
            else
            {
                using (var pinForm = new PinForm())
                {
                    if (pinForm.ShowDialog() == DialogResult.OK && pinForm.IsAuthorized)
                    {
                        var user = new UserForm();
                        var result = user.ShowDialog();

                        if (result == DialogResult.Cancel)
                        {
                            LoadProductCards();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Access denied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            var transactions = new POS.Forms.Reports.Transactions();
            this.Hide();
            var result = transactions.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                this.Show();
            }
        }
    }
}
