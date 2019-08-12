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
    public partial class ItemListForm : Form
    {
        private IGenericRepository<Category> categoryRepo;
        private IGenericRepository<Brand> brandRepo;
        private IGenericRepository<ProductType> productTypeRepo;
        private IGenericRepository<Item> itemRepo;

        private Category category;
        private Brand brand;
        private ProductType productType;
        private Item item;

        public ItemListForm()
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
            BindItemDataGrid();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = null;
            itemForm = new ItemForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            itemForm.ShowDialog();
        }

        private void BindAllComoBoxes()
        {
            Utilities.Validation.BindComboBox(cmbCategory, categoryRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbBrand, brandRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbProductType, productTypeRepo.GetAll(), "Name", "Id", true);
        }

        private void BindItemDataGrid()
        {
            dgItems.DataSource = itemRepo.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
