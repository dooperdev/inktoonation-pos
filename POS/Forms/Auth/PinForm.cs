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
    public partial class PinForm : Form
    {
        public PinForm()
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
    }
}
