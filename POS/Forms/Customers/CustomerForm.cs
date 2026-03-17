using POS.Forms.Users;
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
    public partial class CustomerForm : Form
    {
        private CustomerRepository _customerRepo = new();
        public int CustomerId;
        public string CustomerName;
        public CustomerForm()
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
                        break;
                }
            };
        }

        private void RefreshRolesGridView()
        {

            // DataGridView properties
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.ColumnHeadersVisible = true;
            dgvCustomers.Columns.Clear();
            dgvCustomers.RowTemplate.Height = 40;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomers.EnableHeadersVisualStyles = false;


            // Prevent automatic sizing from overriding manual width
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // Add CustomerId column
            dgvCustomers.Columns.Add("CustomerId", "Id");
            dgvCustomers.Columns["CustomerId"].DataPropertyName = "CustomerId";
            dgvCustomers.Columns["CustomerId"].Width = 50;

            // Add Name column
            dgvCustomers.Columns.Add("Name", "Name");
            dgvCustomers.Columns["Name"].DataPropertyName = "Name";
            dgvCustomers.Columns["Name"].Width = 200;

            // Add Email column
            dgvCustomers.Columns.Add("Email", "Email");
            dgvCustomers.Columns["Email"].DataPropertyName = "Email";
            dgvCustomers.Columns["Email"].Width = 200;

            // Add Phone column
            dgvCustomers.Columns.Add("Phone", "Phone No.");
            dgvCustomers.Columns["Phone"].DataPropertyName = "Phone";
            dgvCustomers.Columns["Phone"].Width = 200;

            // Add Address column
            dgvCustomers.Columns.Add("Address", "Address");
            dgvCustomers.Columns["Address"].DataPropertyName = "Address";
            dgvCustomers.Columns["Address"].Width = 200;

            // Add Edit button column
            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "Edit";
            editCol.HeaderText = "";
            editCol.Image = Properties.Resources.edit;
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editCol.Width = 25;
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns.Add(editCol);

            // Add Delete button column
            DataGridViewImageColumn deleteCol = new DataGridViewImageColumn();
            deleteCol.Name = "Delete";
            deleteCol.HeaderText = "";
            deleteCol.Image = Properties.Resources.delete;
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteCol.Width = 25;
            deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns.Add(deleteCol);

            // Add Delete button column
            DataGridViewImageColumn addTosale = new DataGridViewImageColumn();
            addTosale.Name = "AddSale";
            addTosale.HeaderText = "";
            addTosale.Image = Properties.Resources.sale;
            addTosale.ImageLayout = DataGridViewImageCellLayout.Zoom;
            addTosale.Width = 25;
            addTosale.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns.Add(addTosale);

            dgvCustomers.RowTemplate.Height = 25;

            // Bind the roles list
            dgvCustomers.DataSource = _customerRepo.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new AddEditCustomer(CustomerId);
            var result = customer.ShowDialog();
            if (result == DialogResult.OK)
            {
                RefreshRolesGridView();
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            RefreshRolesGridView();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["CustomerId"].Value);
            string name = dgvCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            CustomerId = id;
            // EDIT CLICK
            if (dgvCustomers.Columns[e.ColumnIndex].Name == "Edit")
            {
                var edit = new AddEditCustomer(id);
                edit.btnAdd.Text = "Save";
                edit.txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                edit.txtEmail.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                edit.txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                edit.txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                var result = edit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshRolesGridView();
                }

            }

            // DELETE CLICK
            if (dgvCustomers.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _customerRepo.Delete(id);
                    RefreshRolesGridView();
                }
            }

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "AddSale")
            {
                this.CustomerId = id;
                this.CustomerName = name;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            var filteredUsers = _customerRepo.GetAll()
                .Where(u => u.Name.ToLower().Contains(query) ||
                            u.Email.ToLower().Contains(query))
                .ToList();

            dgvCustomers.DataSource = filteredUsers;
        }
    }
}
