using POS.Forms;
using POS.Forms.Customers;
using POS.Forms.Inventory;
using POS.Forms.Products;
using POS.Models;
using POS.Repository;
using System.Data;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProductRepository _productRepo = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductCards();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private List<CartItem> cart = new List<CartItem>();
        private double discount = 0.0;
        private double serviceChargePercent = 0.2; // 20%
        private double tax = 0.5;


        private int customerId = 0;
        private string customerName = "Guest";

        private int UserId = 0;


        private void LoadProductCards(string filter = "")
        {
            flowLayoutPanel1.Controls.Clear(); // Clear previous cards

            List<Products> products = _productRepo.GetAll();

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

                flowLayoutPanel1.Controls.Add(card);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();
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

                foreach (CartItemCard card in flowLayoutPanel2.Controls)
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
                        flowLayoutPanel2.Controls.Remove(cartCard);
                    }
                    RefreshCartUI();
                };

                cartCard.OnRemove = (item) =>
                {
                    cart.Remove(item);
                    flowLayoutPanel2.Controls.Remove(cartCard);
                    RefreshCartUI();
                };

                flowLayoutPanel2.Controls.Add(cartCard);
                flowLayoutPanel2.Controls.SetChildIndex(cartCard, 0);
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
            lblTotal.Text = $"Subtotal: {subtotal:C}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            LoadProductCards(searchText); // Pass the search filter
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Clear the cart list
            cart.Clear();

            // Remove all CartItemCards from the FlowLayoutPanel
            flowLayoutPanel2.Controls.Clear();

            // Refresh subtotal/total
            RefreshCartUI();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var customer = new CustomerForm();
            var result = customer.ShowDialog();

            if (result == DialogResult.OK)
            {
                customerId = customer.CustomerId;
                customerName = customer.CustomerName;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var inventory = new InventoryForm();
            var result = inventory.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                LoadProductCards();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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
                    flowLayoutPanel2.Controls.Clear();
                    LoadProductCards();
                    RefreshCartUI();
                }
            }
        }
    }
}
