using POS.Repository;
using System;
using System.Windows.Forms;

namespace POS.Forms.Auth
{
    public partial class PinForm : Form
    {
        private AuthRepository _authRepo = new();

        public PinForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            txtPin.MaxLength = 6;
            txtPin.UseSystemPasswordChar = true;
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
                    case Keys.Enter:
                        btnContinue_Click(this, EventArgs.Empty);
                        break;
                }
            };
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPin.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("PIN is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var userId = _authRepo.LoginByPin(txtPin.Text.Trim());

                if (userId != null)
                {
                    var pos = new POSForm(userId.Value);
                    this.Hide();
                    var session = pos.ShowDialog();

                    if (session == DialogResult.OK)
                    {
                        txtPin.Clear();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid PIN. Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPin.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
