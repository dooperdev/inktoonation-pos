using Microsoft.VisualBasic.ApplicationServices;
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

namespace POS.Forms.Products
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
        }

        private void EnableKeyboardShortcuts()
        {
            this.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        break;
                }
            };
        }

        private ProductRepository _productRepo = new();
        private POS.Models.Products productModel = new();
        private bool isEdit = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new AddEditProducts(productModel, isEdit);
            var result = product.ShowDialog();
            if (result == DialogResult.OK)
            {
                RefreshProductsGridView();
            }
        }

        private void RefreshProductsGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            dgvProducts.ColumnHeadersVisible = true;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // ROW HEIGHT
            dgvProducts.RowTemplate.Height = 60; // taller for image

            // =========================
            // IMAGE COLUMN
            // =========================
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "ImagePath";
            imgCol.HeaderText = "Image";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 60; // approximate width for image
            dgvProducts.Columns.Add(imgCol);

            // =========================
            // ProductId
            // =========================
            dgvProducts.Columns.Add("ProductId", "Id");
            dgvProducts.Columns["ProductId"].DataPropertyName = "ProductId";
            dgvProducts.Columns["ProductId"].Width = 50;

            // =========================
            // Name
            // =========================
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns["Name"].DataPropertyName = "Name";
            dgvProducts.Columns["Name"].Width = 250;

            // =========================
            // Barcode
            // =========================
            dgvProducts.Columns.Add("Barcode", "Barcode");
            dgvProducts.Columns["Barcode"].DataPropertyName = "Barcode";
            dgvProducts.Columns["Barcode"].Width = 150;

            // =========================
            // Description
            // =========================
            dgvProducts.Columns.Add("Description", "Description");
            dgvProducts.Columns["Description"].DataPropertyName = "Description";
            dgvProducts.Columns["Description"].Width = 300;

            // =========================
            // Price
            // =========================
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns["Price"].DataPropertyName = "Price";
            dgvProducts.Columns["Price"].Width = 100;

            // =========================
            // Edit Button
            // =========================
            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "Edit";
            editCol.HeaderText = "";
            editCol.Image = Properties.Resources.edit;
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editCol.Width = 25; // small width
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(editCol);

            // =========================
            // Delete Button
            // =========================
            DataGridViewImageColumn deleteCol = new DataGridViewImageColumn();
            deleteCol.Name = "Delete";
            deleteCol.HeaderText = "";
            deleteCol.Image = Properties.Resources.delete;
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteCol.Width = 25; // small width
            deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(deleteCol);

            // =========================
            // Bind Data
            // =========================
            var products = _productRepo.GetAll();
            dgvProducts.DataSource = products;

            // Load images from ImagePath
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                string imagePath = row.Cells["ImagePath"]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    row.Cells["ImagePath"].Value = Image.FromFile(imagePath);
                }
            }

            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "ImagePath")
            {
                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as POS.Models.Products;

                if (product != null &&
                    !string.IsNullOrEmpty(product.ImagePath) &&
                    File.Exists(product.ImagePath))
                {
                    using (var imgTemp = Image.FromFile(product.ImagePath))
                    {
                        e.Value = new Bitmap(imgTemp);
                    }
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            RefreshProductsGridView();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductId"].Value);
            // EDIT CLICK
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
            {
                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as POS.Models.Products;
                isEdit = true;
                var edit = new AddEditProducts(product, isEdit);
                edit.btnAdd.Text = "Save";
                var result = edit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshProductsGridView();
                }

            }

            // DELETE CLICK
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _productRepo.Delete(id);
                    RefreshProductsGridView();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            // Get all products from repository
            var allProducts = _productRepo.GetAll();

            // Filter by Name, Barcode, or Description
            var filtered = allProducts.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Barcode.ToLower().Contains(keyword) ||
                p.ProductId.ToString().Contains(keyword)
            ).ToList();

            // Bind filtered list to DataGridView
            dgvProducts.DataSource = filtered;

            // Reload images for filtered rows
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                string imagePath = row.Cells["ImagePath"]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    row.Cells["ImagePath"].Value = Image.FromFile(imagePath);
                }
            }
        }
    }
}
