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
    public partial class CustomerForm : Form
    {
        private IGenericRepository<Country> countryRepo;
        private IGenericRepository<State> stateRepo;
        private IGenericRepository<City> cityeRepo;
        private IGenericRepository<Customer> customerRepo;

        private Customer customer;

        public CustomerForm()
        {
            InitializeComponent();

            countryRepo = new GenericRepository<Country>();
            stateRepo = new GenericRepository<State>();
            cityeRepo = new GenericRepository<City>();
            customerRepo = new GenericRepository<Customer>();

            customer = new Customer();

            BindAllComoBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                MessageBox.Show("Customer Code required");
                txtCustomerCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                MessageBox.Show("First Name required");
                txtFirstName.Focus();
            }
            else
            {
                customer.CustomerCode = txtCustomerCode.Text.Trim();
                customer.FirstName = txtFirstName.Text.Trim();
                customer.MiddleName = txtMiddleName.Text.Trim();
                customer.LastName = txtLastName.Text.Trim();
                customer.BirthDate = dtBirthDate.Value;
                customer.AnniversaryDate = dtAnniversaryDate.Value;
                customer.VatNo = txtVatNo.Text.Trim();
                customer.CstNo = txtCstNo.Text.Trim();
                customer.TinNo = txtTinNo.Text.Trim();
                customer.PanNo = txtPanNo.Text.Trim();
                customer.GstNo = txtGstNo.Text.Trim();
                customer.IsActive = chkIsActive.Checked;
                customer.IsPreferred = chkIsPreferred.Checked;
                customer.ShippingAddress = txtAddressShipping.Text.Trim();
                customer.ShippingCountryId = Convert.ToInt32(cmbCountryShipping.SelectedValue);
                customer.ShippingStateId = Convert.ToInt32(cmbStateShipping.SelectedValue);
                customer.ShippingCityId = Convert.ToInt32(cmbCityShipping.SelectedValue);
                customer.ShippingPostalCode = txtPostalCodeShipping.Text.Trim();
                customer.ShippingContactNumber = txtContactNumberShipping.Text.Trim();
                customer.ShippingMobileNumber = txtMobileNumberShipping.Text.Trim();
                customer.ShippingWhatsappNumber = txtWhatsappNumberShipping.Text.Trim();
                customer.ShippingEmailAddress = txtEmailAddressShipping.Text.Trim();
                customer.BillingAddress = txtAddressShipping.Text.Trim();
                customer.BillingCountryId = Convert.ToInt32(cmbCountryShipping.SelectedValue);
                customer.BillingStateId = Convert.ToInt32(cmbStateShipping.SelectedValue);
                customer.BillingCityId = Convert.ToInt32(cmbCityShipping.SelectedValue);
                customer.BillingPostalCode = txtPostalCodeShipping.Text.Trim();
                customer.BillingContactNumber = txtContactNumberShipping.Text.Trim();
                customer.BillingMobileNumber = txtMobileNumberShipping.Text.Trim();
                customer.BillingWhatsappNumber = txtWhatsappNumberShipping.Text.Trim();
                customer.BillingEmailAddress = txtEmailAddressShipping.Text.Trim();

                customerRepo.Add(customer);
                customerRepo.Save();

                this.Close();
            }
        }

        private void BindAllComoBoxes()
        {
            Utilities.Validation.BindComboBox(cmbCountryShipping, countryRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbStateShipping, stateRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbCityShipping, cityeRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbCountryBilling, countryRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbStateBilling, stateRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbCityBilling, cityeRepo.GetAll(), "Name", "Id", true);
        }
    }
}
