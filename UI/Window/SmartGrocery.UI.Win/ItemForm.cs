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
        private IGenericRepository<SubCategory> subCategoryRepo;
        private IGenericRepository<Item> itemRepo;
        private IGenericRepository<MeasurementUnit> measurementUnitRepo;

        private Category category;
        private Brand brand;
        private SubCategory subCategory;
        private Item item;
        private MeasurementUnit measurement;

        public ItemForm()
        {
            InitializeComponent();

            categoryRepo = new GenericRepository<Category>();
            brandRepo = new GenericRepository<Brand>();
            subCategoryRepo = new GenericRepository<SubCategory>();
            itemRepo = new GenericRepository<Item>();
            measurementUnitRepo = new GenericRepository<MeasurementUnit>();

            category = new Category();
            brand = new Brand();
            subCategory = new SubCategory();
            item = new Item();
            measurement = new MeasurementUnit();

            BindAllComoBoxes();
        }

        private void BindAllComoBoxes()
        {
            try
            {
                Utilities.Validation.BindComboBox(cmbCategory, categoryRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbBrand, brandRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbSubCategory, subCategoryRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbMeasurementUnit, measurementUnitRepo.GetAll(), "Name", "Id", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                //else if (string.IsNullOrEmpty(txtSalePrice.Text.Trim()))
                //{
                //    MessageBox.Show("Sale Price required");
                //    txtSalePrice.Focus();
                //}
                else
                {
                    item.Barcode = txtBarcode.Text.Trim();
                    item.Name = txtItemName.Text.Trim();
                    item.Description = txtItemDescription.Text.Trim();
                    item.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                    item.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                    item.SubCategoryId = Convert.ToInt32(cmbSubCategory.SelectedValue);
                    item.Mrp = Convert.ToDecimal(txtMrp.Text.Trim());
                    item.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Trim());
                    item.SalePrice = Convert.ToDecimal(txtSalePrice.Text.Trim());
                    item.MeasurementUnitId = Convert.ToInt32(cmbMeasurementUnit.SelectedValue);
                    item.IsActive = chkIsActive.Checked;
                    item.SaleOnline = chkSaleOnline.Checked;
                    item.NotForSale = chkNotForSaleNow.Checked;

                    itemRepo.Add(item);
                    itemRepo.Save();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllowOnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
