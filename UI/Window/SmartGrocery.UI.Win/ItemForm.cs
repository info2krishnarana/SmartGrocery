using SmartGrocery.Data.Repository;
using SmartGrocery.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGrocery.UI.Win
{
    public partial class ItemForm : Form
    {
        private IGenericRepository<Category> categoryRepo;
        private IGenericRepository<Brand> brandRepo;
        private IGenericRepository<ProductType> productTypeRepo;
        private IGenericRepository<Item> itemRepo;

        private Category category;
        private Brand brand;
        private ProductType productType;
        private Item item;

        public ItemForm()
        {
            InitializeComponent();

            categoryRepo = new GenericRepository<Category>();
            brandRepo = new GenericRepository<Brand>();
            productTypeRepo = new GenericRepository<ProductType>();
            itemRepo = new GenericRepository<Item>();

            category = new Category();
            brand = new Brand();
            productType = new ProductType();
            item = new Item();

            BindAllComoBoxes();
        }

        private void BindAllComoBoxes()
        {
            Utilities.Validation.BindComboBox(cmbCategory, categoryRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbBrand, brandRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbProductType, productTypeRepo.GetAll(), "Name", "Id", true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                MessageBox.Show("Barcode required");
                txtBarcode.Focus();
            }
            else if (string.IsNullOrEmpty(txtItemName.Text.Trim()))
            {
                MessageBox.Show("Item Name required");
                txtItemName.Focus();
            }
            else if (string.IsNullOrEmpty(txtMrp.Text.Trim()))
            {
                MessageBox.Show("MRP required");
                txtMrp.Focus();
            }
            else if (string.IsNullOrEmpty(txtPurchasePrice.Text.Trim()))
            {
                MessageBox.Show("Purchase Price required");
                txtPurchasePrice.Focus();
            }
            else if (string.IsNullOrEmpty(txtSalePrice.Text.Trim()))
            {
                MessageBox.Show("Sale Price required");
                txtSalePrice.Focus();
            }
            else
            {
                item.Barcode = txtBarcode.Text.Trim();
                item.Name = txtItemName.Text.Trim();
                item.Description = txtItemDescription.Text.Trim();
                item.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                item.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                item.ProductTypeId = Convert.ToInt32(cmbProductType.SelectedValue);
                item.Mrp = Convert.ToDecimal(txtMrp.Text.Trim());
                item.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Trim());
                item.SalePrice = Convert.ToDecimal(txtSalePrice.Text.Trim());
                item.IsActive = chkIsActive.Checked;
                item.SaleOnline = chkSaleOnline.Checked;
                item.NotForSale = chkNotForSaleNow.Checked;

                itemRepo.Add(item);
                itemRepo.Save();
            }
        }
    }
}
