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

namespace POS.Forms.Users
{
    public partial class UserForm : Form
    {
        public UserForm()
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

        private UserRepository _userRepo = new();
        private int userId;

        private void RefreshRolesGridView()
        {

            // DataGridView properties
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnHeadersVisible = true;
            dgvUsers.Columns.Clear();
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsers.EnableHeadersVisualStyles = false;


            // Prevent automatic sizing from overriding manual width
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // Add RoleId column
            dgvUsers.Columns.Add("UserId", "Id");
            dgvUsers.Columns["UserId"].DataPropertyName = "UserId";
            dgvUsers.Columns["UserId"].Width = 50;

            // Add Name column
            dgvUsers.Columns.Add("Name", "Name");
            dgvUsers.Columns["Name"].DataPropertyName = "Name";
            dgvUsers.Columns["Name"].Width = 200;

            // Add Username column
            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns["Username"].DataPropertyName = "Username";
            dgvUsers.Columns["Username"].Width = 200;

            // Add Password column
            dgvUsers.Columns.Add("Password", "Password");
            dgvUsers.Columns["Password"].DataPropertyName = "Password";
            dgvUsers.Columns["Password"].Width = 200;

            // Add Role column
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns["Role"].DataPropertyName = "Role";
            dgvUsers.Columns["Role"].Width = 200;

            // Add Pin column
            dgvUsers.Columns.Add("Pin", "Pin");
            dgvUsers.Columns["Pin"].DataPropertyName = "Pin";
            dgvUsers.Columns["Pin"].Width = 200;

            // Add Edit button column
            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "Edit";
            editCol.HeaderText = "";
            editCol.Image = Properties.Resources.edit;
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editCol.Width = 25;
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsers.Columns.Add(editCol);

            // Add Delete button column
            DataGridViewImageColumn deleteCol = new DataGridViewImageColumn();
            deleteCol.Name = "Delete";
            deleteCol.HeaderText = "";
            deleteCol.Image = Properties.Resources.delete;
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteCol.Width = 25;
            deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsers.Columns.Add(deleteCol);

            dgvUsers.RowTemplate.Height = 25;

            // Bind the roles list
            dgvUsers.DataSource = _userRepo.GetAll();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            var user = new AddEditUser(userId);
            var result = user.ShowDialog();

            if (result == DialogResult.OK) { 
                RefreshRolesGridView(); 
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshRolesGridView();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserId"].Value);
            userId = id;
            // EDIT CLICK
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Edit")
            {
                var edit = new AddEditUser(id);
                edit.btnAdd.Text = "Save";
                edit.txtName.Text = dgvUsers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                edit.txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                edit.txtPassword.Text = dgvUsers.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                edit.cmbRole.Text = dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                edit.txtPin.Text = dgvUsers.Rows[e.RowIndex].Cells["Pin"].Value.ToString();
                var result = edit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshRolesGridView();
                }

            }

            // DELETE CLICK
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _userRepo.DeleteRole(id);
                    RefreshRolesGridView();
                }
            }
        }
    }
}
