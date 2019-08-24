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
    public partial class EmployeeForm : Form
    {
        private IGenericRepository<Country> countryRepo;
        private IGenericRepository<State> stateRepo;
        private IGenericRepository<City> cityeRepo;
        private IGenericRepository<Department> departmentRepo;
        private IGenericRepository<Designation> designationRepo;
        private IGenericRepository<Employee> employeeRepo;

        private Employee employee;

        public EmployeeForm()
        {
            InitializeComponent();

            countryRepo = new GenericRepository<Country>();
            stateRepo = new GenericRepository<State>();
            cityeRepo = new GenericRepository<City>();
            departmentRepo = new GenericRepository<Department>();
            designationRepo = new GenericRepository<Designation>();
            employeeRepo = new GenericRepository<Employee>();

            employee = new Employee();

            BindAllComoBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
                {
                    MessageBox.Show("Employee Code required");
                }
                else if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    MessageBox.Show("First Name required");
                }
                else
                {
                    employee.EmployeeCode = txtEmployeeCode.Text.Trim();
                    employee.FirstName = txtFirstName.Text.Trim();
                    employee.MiddleName = txtMiddleName.Text.Trim();
                    employee.LastName = txtLastName.Text.Trim();
                    employee.ContactNumber = txtContactNo.Text.Trim();
                    employee.MobileNumber = txtMobileNo.Text.Trim();
                    employee.WhatsappNumber = txtWhatsAppNo.Text.Trim();
                    employee.EmailAddress = txtEmail.Text.Trim();
                    employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    employee.DesignationId = Convert.ToInt32(cmbDesignation.SelectedValue);
                    employee.Address = txtAddress.Text.Trim();
                    employee.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                    employee.StateId = Convert.ToInt32(cmbState.SelectedValue);
                    employee.CityId = Convert.ToInt32(cmbCity.SelectedValue);
                    employee.PostalCode = txtPostalCode.Text.Trim();

                    employeeRepo.Add(employee);
                    employeeRepo.Save();

                    this.Close();
                }
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
                Utilities.Validation.BindComboBox(cmbCountry, countryRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbState, stateRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbCity, cityeRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbDepartment, departmentRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbDesignation, designationRepo.GetAll(), "Name", "Id", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
