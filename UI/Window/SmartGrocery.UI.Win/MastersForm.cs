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
using SmartGrocery.UI.Win.ViewModels;

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
        private IGenericRepository<SubCategory> subCategoryRepo;
        private IGenericRepository<Brand> brandRepo;
        private IGenericRepository<MeasurementUnit> measurementUnitRepo;
        private IGenericRepository<Department> departmentRepo;
        private IGenericRepository<Designation> designationRepo;

        private List<Country> countryList;
        private List<State> stateList;
        private List<District> districtList;
        private List<City> cityList;
        private List<Area> areaList;

        private Country country;
        private State state;
        private District district;
        private City city;
        private Area area;
        private Society society;
        private Category category;
        private SubCategory subCategory;
        private Brand brand;
        private MeasurementUnit measurementUnit;
        private Department department;
        private Designation designation;

        private int MasterDataId = 0;
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
            subCategoryRepo = new GenericRepository<SubCategory>();
            brandRepo = new GenericRepository<Brand>();
            measurementUnitRepo = new GenericRepository<MeasurementUnit>();
            departmentRepo = new GenericRepository<Department>();
            designationRepo = new GenericRepository<Designation>();

            //countryList = new List<Country>();
            //stateList = new List<State>();
            //districtList = new List<District>();
            //cityList = new List<City>();
            //areaList = new List<Area>();

            //country = new Country();
            state = new State();
            district = new District();
            city = new City();
            area = new Area();
            society = new Society();
            category = new Category();
            subCategory = new SubCategory();
            brand = new Brand();
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
                    if (MasterDataId > 0)
                    {
                        country = countryRepo.GetById(MasterDataId);

                        if (country.Name == txtCountry.Text.Trim())
                        {
                            MessageBox.Show("Country with same name already exist");
                        }
                        else
                        {
                            country.Name = txtCountry.Text.Trim();
                            countryRepo.Update(country);
                        }

                        MasterDataId = 0;
                    }
                    else
                    {

                        countryList = new List<Country>();
                        string[] countries = txtCountry.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        List<Country> countryInDb = countryRepo.GetAll().ToList();

                        if (countryInDb.Select(x => x.Name).Intersect(countries).Any())
                        {
                            MessageBox.Show("Country with same name already exist");
                            return;
                        }

                        foreach (string cntrs in countries)
                        {
                            country = new Country();
                            country.Name = cntrs;
                            country.IsSelected = false;
                            
                            countryList.Add(country);
                        }

                        countryRepo.Add(countryList);
                    }

                    countryRepo.Save();
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
                    if (state == null)
                    {
                        state = new State();
                    }

                    string[] states = txtState.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string sts in states)
                    {
                        state.CountryId = Convert.ToInt32(cmbCountryOnState.SelectedValue);
                        state.Name = sts;
                        state.IsSelected = false;
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
                List<MasterViewModel> countryViewModelList = countryRepo.GetAll().Select(c =>
                 new MasterViewModel
                 {
                     MasterDataId = c.Id,
                     MasterDataText = c.Name
                 }).ToList();

                dgCountry.DataSource = countryViewModelList;
                dgCountry.Columns["MasterDataId"].Visible = false;

                dgState.DataSource = stateRepo.GetAll();
                dgDistrict.DataSource = districtRepo.GetAll();
                dgCity.DataSource = cityRepo.GetAll();
                dgArea.DataSource = areaRepo.GetAll();
                dgSociety.DataSource = societyRepo.GetAll();
                dgCategory.DataSource = categoryRepo.GetAll();
                dgBrand.DataSource = brandRepo.GetAll();
                dgSubCategory.DataSource = subCategoryRepo.GetAll();
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
                //countries combobox
                countryList = countryRepo.GetAll().ToList();

                Utilities.Validation.BindComboBox(cmbCountryOnState, countryList, "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCountryOnDistrict, countryList, "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCountryOnCity, countryList, "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCountryOnArea, countryList, "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCountryOnSociety, countryList, "Name", "Id", true);

                country = countryList.SingleOrDefault(c => c.IsSelected == true);

                if (country != null)
                {
                    cmbCountryOnState.SelectedValue = country.Id;
                    cmbCountryOnDistrict.SelectedValue = country.Id;
                    cmbCountryOnCity.SelectedValue = country.Id;
                    cmbCountryOnArea.SelectedValue = country.Id;
                    cmbCountryOnSociety.SelectedValue = country.Id;

                    //state combobox
                    stateList = stateRepo.GetAll().Where(s => s.CountryId == country.Id).ToList();

                    Utilities.Validation.BindComboBox(cmbStateOnDistrict, stateList, "Name", "Id", true);
                    Utilities.Validation.BindComboBox(cmbStateOnCity, stateList, "Name", "Id", true);
                    Utilities.Validation.BindComboBox(cmbStateOnArea, stateList, "Name", "Id", true);
                    Utilities.Validation.BindComboBox(cmbStateOnSociety, stateList, "Name", "Id", true);

                    state = stateList.SingleOrDefault(s => s.IsSelected == true);

                    if (state != null)
                    {
                        cmbStateOnDistrict.SelectedValue = state.Id;
                        cmbStateOnCity.SelectedValue = state.Id;
                        cmbStateOnArea.SelectedValue = state.Id;
                        cmbStateOnSociety.SelectedValue = state.Id;

                        //district combobox
                        districtList = districtRepo.GetAll().Where(s => s.StateId == state.Id).ToList();

                        Utilities.Validation.BindComboBox(cmbDistrictOnCity, districtList, "Name", "Id", true);
                        Utilities.Validation.BindComboBox(cmbDistrictOnArea, districtList, "Name", "Id", true);
                        Utilities.Validation.BindComboBox(cmbDistrictOnSociety, districtList, "Name", "Id", true);

                        district = districtList.SingleOrDefault(s => s.IsSelected == true);

                        if (district != null)
                        {
                            cmbDistrictOnCity.SelectedValue = district.Id;
                            cmbDistrictOnArea.SelectedValue = district.Id;
                            cmbDistrictOnSociety.SelectedValue = district.Id;

                            //city combobox
                            cityList = cityRepo.GetAll().Where(d => d.DistrictId == district.Id).ToList();

                            Utilities.Validation.BindComboBox(cmbCityOnArea, cityList, "Name", "Id", true);
                            Utilities.Validation.BindComboBox(cmbCityOnSociety, cityList, "Name", "Id", true);

                            city = cityList.SingleOrDefault(c => c.IsSelected == true);

                            if (city != null)
                            {
                                cmbCityOnArea.SelectedValue = city.Id;
                                cmbCityOnSociety.SelectedValue = city.Id;

                                //area combobox
                                areaList = areaRepo.GetAll().Where(c => c.CityId == city.Id).ToList();

                                Utilities.Validation.BindComboBox(cmbAreaOnSociety, areaList, "Name", "Id", true);

                                area = areaList.SingleOrDefault(a => a.IsSelected == true);

                                if (area != null)
                                {
                                    cmbAreaOnSociety.SelectedValue = area.Id;
                                }
                            }
                        }
                    }
                }
                Utilities.Validation.BindComboBox(cmbCategory, categoryRepo.GetAll(), "Name", "Id", true);
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
                    if (city == null)
                    {
                        city = new City();
                    }

                    string[] cities = txtCity.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string ct in cities)
                    {
                        city.DistrictId = Convert.ToInt32(cmbDistrictOnCity.SelectedValue);
                        city.Name = ct;
                        city.IsSelected = false;
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
                    if (category == null)
                    {
                        category = new Category();
                    }

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
                if (string.IsNullOrEmpty(txtSubCategory.Text.Trim()))
                {
                    MessageBox.Show("Product Type Name required");
                    txtSubCategory.Focus();
                }
                else
                {
                    if (subCategory == null)
                    {
                        subCategory = new SubCategory();
                    }

                    string[] productTypes = txtSubCategory.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string prdType in productTypes)
                    {
                        subCategory.Name = prdType;
                        subCategory.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                        subCategoryRepo.Add(subCategory);
                        subCategoryRepo.Save();
                    }
                    txtSubCategory.Clear();

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
                    txtDistrictName.Focus();
                }
                else
                {
                    if (district == null)
                    {
                        district = new District();
                    }

                    string[] districts = txtDistrictName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string dist in districts)
                    {
                        district.StateId = Convert.ToInt32(cmbStateOnDistrict.SelectedValue);
                        district.Name = dist;
                        district.IsSelected = false;
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
                    if (area == null)
                    {
                        area = new Area();
                    }

                    string[] areas = txtAreaName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string ar in areas)
                    {
                        area.CityId = Convert.ToInt32(cmbCityOnArea.SelectedValue);
                        area.Name = ar;
                        area.PinCode = txtAreaPinCode.Text.Trim();
                        area.IsSelected = false;
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
                    if (society == null)
                    {
                        society = new Society();
                    }

                    string[] societies = txtSocietyName.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string st in societies)
                    {
                        society.AreaId = Convert.ToInt32(cmbAreaOnSociety.SelectedValue);
                        society.Name = st;
                        society.IsSelected = false;
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

        private void cmbCountryOnDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //stateList = stateRepo.GetAll().Where(c => c.CountryId == Convert.ToInt32(cmbCountryOnDistrict.SelectedValue)).ToList();
                //Utilities.Validation.BindComboBox(cmbStateOnDistrict, stateList, "Name", "Id", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCountry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgState_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDistrict_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgSociety_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgSubCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgMeasurementUnit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDesignation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                country = countryRepo.GetById(Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells["MasterDataId"].Value));
                if (country != null)
                {
                    txtCountry.Text = country.Name;
                    MasterDataId = country.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
