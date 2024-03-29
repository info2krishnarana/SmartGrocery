﻿using SmartGrocery.Data.Repository;
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
        private IGenericRepository<SubCategory> subCategoryRepo;
        private IGenericRepository<Item> itemRepo;

        private Category category;
        private Brand brand;
        private SubCategory subCategory;
        private Item item;

        public ItemListForm()
        {
            InitializeComponent();

            categoryRepo = new GenericRepository<Category>();
            brandRepo = new GenericRepository<Brand>();
            subCategoryRepo = new GenericRepository<SubCategory>();
            itemRepo = new GenericRepository<Item>();

            category = new Category();
            brand = new Brand();
            subCategory = new SubCategory();
            item = new Item();

            BindAllComoBoxes();
            BindItemDataGrid();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ItemForm itemForm = null;
                itemForm = new ItemForm();
                //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
                itemForm.ShowDialog();
                BindItemDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindAllComoBoxes()
        {
            try
            {
                Utilities.Validation.BindComboBox(cmbCategory, categoryRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbBrand, brandRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbProductType, subCategoryRepo.GetAll(), "Name", "Id", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindItemDataGrid()
        {
            try
            {
                dgItems.DataSource = itemRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
