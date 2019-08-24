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
        private IGenericRepository<District> districtRepo;
        private IGenericRepository<City> cityRepo;
        private IGenericRepository<Area> areaRepo;
        private IGenericRepository<Society> societyRepo;
        private IGenericRepository<Category> categoryRepo;
        private IGenericRepository<Brand> brandRepo;
        private IGenericRepository<ProductType> productTypeRepo;
        private IGenericRepository<MeasurementUnit> measurementUnitRepo;
        private IGenericRepository<Department> departmentRepo;
        private IGenericRepository<Designation> designationRepo;

        private Country country;
        private State state;
        private District district;
        private City city;
        private Area area;
        private Society society;
        private Category category;
        private Brand brand;
        private ProductType productType;
        private MeasurementUnit measurementUnit;
        private Department department;
        private Designation designation;
        private IEnumerable<string> areas;

        public MastersForm()
        {
            InitializeComponent();

            countryRepo = new GenericRepository<Country>();
            stateRepo = new GenericRepository<State>();
            districtRepo = new GenericRepository<District>();
            areaRepo = new GenericRepository<Area>();
            societyRepo = new GenericRepository<Society>();
            cityRepo = new GenericRepository<City>();
            categoryRepo = new GenericRepository<Category>();
            brandRepo = new GenericRepository<Brand>();
            productTypeRepo = new GenericRepository<ProductType>();
            measurementUnitRepo = new GenericRepository<MeasurementUnit>();
            departmentRepo = new GenericRepository<Department>();
            designationRepo = new GenericRepository<Designation>();

            country = new Country();
            state = new State();
            district = new District();
            city = new City();
            area = new Area();
            society = new Society();
            category = new Category();
            brand = new Brand();
            productType = new ProductType();
            measurementUnit = new MeasurementUnit();
            department = new Department();
            designation = new Designation();

            BindAllDataGrids();
            BindAllComboBoxes();
        }

        private void btnSaveCountry_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindAllDataGrids()
        {
            try
            {
                dgCountry.DataSource = countryRepo.GetAll();
                dgState.DataSource = stateRepo.GetAll();
                dgDistrict.DataSource = districtRepo.GetAll();
                dgCity.DataSource = cityRepo.GetAll();
                dgArea.DataSource = areaRepo.GetAll();
                dgSociety.DataSource = societyRepo.GetAll();
                dgCategory.DataSource = categoryRepo.GetAll();
                dgBrand.DataSource = brandRepo.GetAll();
                dgProductType.DataSource = productTypeRepo.GetAll();
                dgMeasurementUnit.DataSource = measurementUnitRepo.GetAll();
                dgDepartment.DataSource = departmentRepo.GetAll();
                dgDesignation.DataSource = designationRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindAllComboBoxes()
        {
            try
            {
                Utilities.Validation.BindComboBox(cmbCountry, countryRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbState, stateRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbDistrict, districtRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCity, cityRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbArea, areaRepo.GetAll(), "Name", "Id", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCitySave_Click(object sender, EventArgs e)
        {
            try
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
                        city.DistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);
                        city.Name = ct;
                        cityRepo.Add(city);
                        cityRepo.Save();
                    }
                    txtCity.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveBrand_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveType_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveMeasurementUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMeasurementUnitName.Text.Trim()))
                {
                    MessageBox.Show("Measurement Unit Name required");
                    txtMeasurementUnitName.Focus();
                }
                else
                {
                    string[] measurementUnits = txtMeasurementUnitName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string measure in measurementUnits)
                    {
                        measurementUnit.Name = measure;
                        measurementUnitRepo.Add(measurementUnit);
                        measurementUnitRepo.Save();
                    }
                    txtMeasurementUnitName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDepartmentName.Text.Trim()))
                {
                    MessageBox.Show("Department Name required");
                    txtDepartmentName.Focus();
                }
                else
                {
                    string[] departments = txtDepartmentName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string dept in departments)
                    {
                        department.Name = dept;
                        departmentRepo.Add(department);
                        departmentRepo.Save();
                    }
                    txtDepartmentName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDesignationName.Text.Trim()))
                {
                    MessageBox.Show("Designation Name required");
                    txtDesignationName.Focus();
                }
                else
                {
                    string[] designations = txtDesignationName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string desg in designations)
                    {
                        designation.Name = desg;
                        designationRepo.Add(designation);
                        designationRepo.Save();
                    }
                    txtDesignationName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDistrictName.Text.Trim()))
                {
                    MessageBox.Show("District Name required");
                    txtCity.Focus();
                }
                else
                {
                    string[] districts = txtDistrictName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string dist in districts)
                    {
                        district.StateId = Convert.ToInt32(cmbState.SelectedValue);
                        district.Name = dist;
                        districtRepo.Add(district);
                        districtRepo.Save();
                    }
                    txtDistrictName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAreaPinCode.Text.Trim()))
                {
                    MessageBox.Show("Area PinCode required");
                    txtCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtAreaName.Text.Trim()))
                {
                    MessageBox.Show("Area Name required");
                    txtCity.Focus();
                }
                else
                {
                    string[] areas = txtAreaName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string ar in areas)
                    {
                        area.CityId = Convert.ToInt32(cmbCity.SelectedValue);
                        area.Name = ar;
                        areaRepo.Add(area);
                        areaRepo.Save();
                    }
                    txtAreaPinCode.Clear();
                    txtAreaName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSociety_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSocietyName.Text.Trim()))
                {
                    MessageBox.Show("Society Name required");
                    txtCity.Focus();
                }
                else
                {
                    string[] societies = txtSocietyName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string st in societies)
                    {
                        society.AreaId = Convert.ToInt32(cmbArea.SelectedValue);
                        society.Name = st;
                        societyRepo.Add(society);
                        societyRepo.Save();
                    }
                    txtSocietyName.Clear();

                    BindAllDataGrids();
                    BindAllComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
