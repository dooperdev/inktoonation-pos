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
using System.Xml.Linq;

namespace POS.Forms.Inventory
{
    public partial class UpdateStock : Form
    {
        private InventoryRepository _inventoryRepo = new();
        private int ProductId;
        public UpdateStock(int productId)
        {
            InitializeComponent();
            ProductId = productId;
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
                        break;
                }
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Quantity is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var inventory = new POS.Models.Inventory();
                inventory.ProductId = ProductId;
                inventory.QuantityInStock = Convert.ToInt32(txtQuantity.Text);
                _inventoryRepo.UpdateStock(inventory);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
