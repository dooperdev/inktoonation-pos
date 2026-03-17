using POS.Forms.Customers;
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

namespace POS.Forms.Inventory
{
    public partial class InventoryForm : Form
    {
        private InventoryRepository _inventoryRepo = new();
        public InventoryForm()
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
                        this.DialogResult = DialogResult.Cancel;
                        break;
                }
            };
        }

        private void RefreshGridView()
        {

            // DataGridView properties
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.ColumnHeadersVisible = true;
            dgvInventory.Columns.Clear();
            dgvInventory.RowTemplate.Height = 40;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvInventory.EnableHeadersVisualStyles = false;


            // Prevent automatic sizing from overriding manual width
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // Add CustomerId column
            dgvInventory.Columns.Add("ProductId", "Id");
            dgvInventory.Columns["ProductId"].DataPropertyName = "ProductId";
            dgvInventory.Columns["ProductId"].Width = 50;

            // Add Name column
            dgvInventory.Columns.Add("ProductName", "Product Name");
            dgvInventory.Columns["ProductName"].DataPropertyName = "ProductName";
            dgvInventory.Columns["ProductName"].Width = 500;

            // Add Email column
            dgvInventory.Columns.Add("QuantityInStock", "Quantity In Stock");
            dgvInventory.Columns["QuantityInStock"].DataPropertyName = "QuantityInStock";
            dgvInventory.Columns["QuantityInStock"].Width = 350;


            // Add Edit button column
            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "Edit";
            editCol.HeaderText = "";
            editCol.Image = Properties.Resources.edit;
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editCol.Width = 25;
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventory.Columns.Add(editCol);

            dgvInventory.RowTemplate.Height = 25;

            // Bind the roles list
            dgvInventory.DataSource = _inventoryRepo.GetAll();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["ProductId"].Value);

            // EDIT CLICK
            if (dgvInventory.Columns[e.ColumnIndex].Name == "Edit")
            {
                var edit = new UpdateStock(id);
                edit.btnAdd.Text = "Save";
                var result = edit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshGridView();
                }

            }
        }
    }
}
