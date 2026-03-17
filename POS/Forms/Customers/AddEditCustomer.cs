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

namespace POS.Forms.Customers
{
    public partial class AddEditCustomer : Form
    {
        private CustomerRepository _customerRepo = new();
        private int customerId;
        public AddEditCustomer(int _customerId)
        {
            InitializeComponent();
            EnableKeyboardShortcuts();
            this.KeyPreview = true;
            customerId = _customerId;
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
            try
            {
                if (btnAdd.Text == "Add")
                {
                    if (txtName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Name is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtEmail.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Email is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPhone.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Phone no. is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtAddress.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Address is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var customers = new POS.Models.Customers();
                        customers.Name = txtName.Text;
                        customers.Email = txtEmail.Text;
                        customers.Phone = txtPhone.Text;
                        customers.Address = txtAddress.Text;
                        _customerRepo.Create(customers);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (txtName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Name is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtEmail.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Email is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPhone.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Phone no. is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtAddress.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Address is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var customers = new POS.Models.Customers();
                        customers.Name = txtName.Text;
                        customers.Email = txtEmail.Text;
                        customers.Phone = txtPhone.Text;
                        customers.Address = txtAddress.Text;
                        _customerRepo.Edit(customerId, customers);
                        this.DialogResult = DialogResult.OK;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
