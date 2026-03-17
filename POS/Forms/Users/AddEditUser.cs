using Microsoft.VisualBasic.ApplicationServices;
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

namespace POS.Forms.Users
{
    public partial class AddEditUser : Form
    {
        public AddEditUser(int _userId)
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            userId = _userId;
        }

        private UserRepository _userRepo = new();
        private int userId;

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
                if(btnAdd.Text == "Add")
                {
                    if(txtName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Name is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(txtUsername.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Username is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPassword.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Password is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (cmbRole.SelectedIndex == 0)
                    {
                        MessageBox.Show("Role is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPin.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Pin is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                       var user = new POS.Models.Users();
                       user.Name = txtName.Text;
                       user.Password = txtPassword.Text;
                       user.Username = txtUsername.Text;
                       user.Role = cmbRole.Text;
                       user.Pin = txtPin.Text;
                        _userRepo.Create(user);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (txtName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Name is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtUsername.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Username is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPassword.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Password is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (cmbRole.SelectedIndex == 0)
                    {
                        MessageBox.Show("Role is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPin.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Pin is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var user = new POS.Models.Users();
                        user.Name = txtName.Text;
                        user.Password = txtPassword.Text;
                        user.Username = txtUsername.Text;
                        user.Role = cmbRole.Text;
                        user.Pin = txtPin.Text;
                        _userRepo.Edit(userId,user);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
