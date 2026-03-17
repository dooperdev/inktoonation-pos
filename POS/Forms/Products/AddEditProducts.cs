using POS.Repository;

namespace POS.Forms.Products
{
    public partial class AddEditProducts : Form
    {
        private POS.Models.Products products;
        private bool IsEdit;
        public AddEditProducts(POS.Models.Products _products, bool isEdit)
        {
            InitializeComponent();
            this.KeyPreview = true;
            EnableKeyboardShortcuts();
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);
            products = _products;
            IsEdit = isEdit;
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


        private ProductRepository _productRepo = new();
        private string imagePath = "";
        private string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                pbImage.Image = Image.FromFile(imagePath);
            }
        }

        private string SaveImageLocally(string originalPath)
        {
            if (string.IsNullOrEmpty(originalPath)) return "";
            string filename = Path.GetFileName(originalPath);
            string destPath = Path.Combine(imagesFolder, filename);
            File.Copy(originalPath, destPath, true);
            return destPath;
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
                    else if (txtDescription.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Description is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPrice.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Price is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!double.TryParse(txtPrice.Text, out double price))
                    {
                        MessageBox.Show("Invalid price", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtBarcode.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Barcode is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string savedImage = SaveImageLocally(imagePath);
                        var product = new POS.Models.Products();
                        product.Name = txtName.Text;
                        product.Description = txtDescription.Text;
                        product.Barcode = txtBarcode.Text;
                        product.Price = Convert.ToDecimal(txtPrice.Text);
                        product.ImagePath = savedImage;
                        _productRepo.Create(product);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (txtName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Name is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtDescription.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Description is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPrice.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Price is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!double.TryParse(txtPrice.Text, out double price))
                    {
                        MessageBox.Show("Invalid price", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtBarcode.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Barcode is required", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string savedImage = SaveImageLocally(imagePath);
                        var product = new POS.Models.Products();
                        product.Name = txtName.Text;
                        product.Description = txtDescription.Text;
                        product.Barcode = txtBarcode.Text;
                        product.Price = Convert.ToDecimal(txtPrice.Text);
                        if (savedImage != "")
                        {
                            product.ImagePath = savedImage;
                        }
                        else
                        {
                            product.ImagePath = products.ImagePath;
                        }

                        _productRepo.Edit(products.ProductId, product);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            txtName.Text = products.Name;
            txtBarcode.Text = products.Barcode;
            txtDescription.Text = products.Description;
            txtPrice.Text = products.Price.ToString();

            if (!string.IsNullOrEmpty(products.ImagePath) && File.Exists(products.ImagePath))
            {
                using (var imgTemp = Image.FromFile(products.ImagePath))
                {
                    pbImage.Image = new Bitmap(imgTemp);
                }
            }
        }

        private void AddEditProducts_Load(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                LoadProductData();
            }
        }
    }
}
