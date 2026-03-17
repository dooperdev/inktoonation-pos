using POS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Helper
{
    public partial class PinForm : Form
    {
        public bool IsAuthorized { get; private set; } = false;
        public int AuthorizedUserId { get; private set; }
        public PinForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            txtPin.MaxLength = 6;
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ValidatePin(txtPin.Text))
            {
                IsAuthorized = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid PIN");
                txtPin.Clear();
            }
        }


        private bool ValidatePin(string pin)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT UserID FROM Users WHERE Pin = @Pin AND Role = 'Admin'";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Pin", pin);

            var result = cmd.ExecuteScalar();

            if (result != null)
            {
                AuthorizedUserId = Convert.ToInt32(result);
                return true;
            }

            return false;
        }
    }
}
