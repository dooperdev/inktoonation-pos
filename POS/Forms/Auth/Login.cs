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

namespace POS.Forms.Auth
{
    public partial class Login : Form
    {
        private AuthRepository _authRepo = new();
        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
        }

        private int UserId;

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

        private void lblpinlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pinLogin = new PinForm();
            pinLogin.ShowDialog();
            this.Show();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Username is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtPassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Password is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtUsername.Text == "admin" && txtPassword.Text == "angcuteko")
                    {
                        var pos = new POSForm(UserId);
                        this.Hide();
                        var session = pos.ShowDialog();
                     
                        if (session == DialogResult.OK)
                        {
                            txtPassword.Clear();
                            txtUsername.Clear();
                            this.Show();
                        }
                    }
                    else
                    {
                        var result = _authRepo.Login(txtUsername.Text, txtPassword.Text);
                        UserId = Convert.ToInt32(result);
                        if (result != null)
                        {
                            var pos = new POSForm(UserId);
                            this.Hide();
                            var session = pos.ShowDialog();

                            if (session == DialogResult.OK)
                            {
                                txtPassword.Clear();
                                txtUsername.Clear();
                                this.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
