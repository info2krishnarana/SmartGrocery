using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartGrocery.Entity.DataModel;
using SmartGrocery.Business;
using SmartGrocery.Data.Repository;

namespace SmartGrocery.UI.Win
{
    public partial class MastersForm : Form
    {
        private IGenericRepository<Country> countryRepo;
        private IGenericRepository<State> stateRepo;
        private IGenericRepository<City> cityRepo;
        private IGenericRepository<Category> categoryRepo;
        private IGenericRepository<Brand> brandRepo;
        private IGenericRepository<ProductType> productTypeRepo;

        private Country country;
        private State state;
        private City city;
        private Category category;
        private Brand brand;
        private ProductType productType;

        public MastersForm()
        {
            InitializeComponent();

            countryRepo = new GenericRepository<Country>();
            stateRepo = new GenericRepository<State>();
            cityRepo = new GenericRepository<City>();
            categoryRepo = new GenericRepository<Category>();
            brandRepo = new GenericRepository<Brand>();
            productTypeRepo = new GenericRepository<ProductType>();

            country = new Country();
            state = new State();
            city = new City();
            category = new Category();
            brand = new Brand();
            productType = new ProductType();

            BindAllDataGrids();
            BindAllComboBoxes();
        }

        private void btnSaveCountry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountry.Text.Trim()))
            {
                MessageBox.Show("Country Name required");
                txtCountry.Focus();
            }
            else
            {
                string[] countries = txtCountry.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string cntrs in countries)
                {
                    country.Name = cntrs;
                    countryRepo.Add(country);
                    countryRepo.Save();
                }
                txtCountry.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtState.Text.Trim()))
            {
                MessageBox.Show("State Name required");
                txtState.Focus();
            }
            else
            {
                string[] states = txtState.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string sts in states)
                {
                    state.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                    state.Name = sts;
                    stateRepo.Add(state);
                    stateRepo.Save();
                }
                txtState.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }

        private void BindAllDataGrids()
        {
            dgCountry.DataSource = countryRepo.GetAll();
            dgState.DataSource = stateRepo.GetAll();
            dgCity.DataSource = cityRepo.GetAll();
            dgCategory.DataSource = categoryRepo.GetAll();
            dgBrand.DataSource = brandRepo.GetAll();
            dgProductType.DataSource = productTypeRepo.GetAll();
        }

        private void BindAllComboBoxes()
        {
            Utilities.Validation.BindComboBox(cmbCountry, countryRepo.GetAll(), "Name", "Id", true);

            //cmbCountry.DataSource = countryRepo.GetAll();
            //cmbCountry.DisplayMember = "Name";
            //cmbCountry.ValueMember = "Name";

            Utilities.Validation.BindComboBox(cmbState, stateRepo.GetAll(), "Name", "Id", true);

            //cmbState.DataSource = stateRepo.GetAll();
            //cmbState.DisplayMember = "Name";
            //cmbState.ValueMember = "Name";
        }

        private void btnCitySave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                MessageBox.Show("City Name required");
                txtCity.Focus();
            }
            else
            {
                string[] cities = txtCity.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string ct in cities)
                {
                    city.StateId = Convert.ToInt32(cmbState.SelectedValue);
                    city.Name = ct;
                    cityRepo.Add(city);
                    cityRepo.Save();
                }
                txtCity.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategory.Text.Trim()))
            {
                MessageBox.Show("Category Name required");
                txtCategory.Focus();
            }
            else
            {
                string[] categories = txtCategory.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string categ in categories)
                {
                    category.Name = categ;
                    categoryRepo.Add(category);
                    categoryRepo.Save();
                }
                txtCategory.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }

        private void btnSaveBrand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text.Trim()))
            {
                MessageBox.Show("Brand Name required");
                txtBrand.Focus();
            }
            else
            {
                string[] brands = txtBrand.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string brnd in brands)
                {
                    brand.Name = brnd;
                    brandRepo.Add(brand);
                    brandRepo.Save();
                }
                txtBrand.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }

        private void btnSaveType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductType.Text.Trim()))
            {
                MessageBox.Show("Product Type Name required");
                txtProductType.Focus();
            }
            else
            {
                string[] productTypes = txtProductType.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string prdType in productTypes)
                {
                    productType.Name = prdType;
                    productTypeRepo.Add(productType);
                    productTypeRepo.Save();
                }
                txtProductType.Clear();

                BindAllDataGrids();
                BindAllComboBoxes();
            }
        }
    }
}
