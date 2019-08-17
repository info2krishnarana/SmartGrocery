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
    public partial class SupplierForm : Form
    {
        private IGenericRepository<Country> countryRepo;
        private IGenericRepository<State> stateRepo;
        private IGenericRepository<City> cityeRepo;
        private IGenericRepository<Supplier> supplierRepo;

        private Supplier supplier;

        public SupplierForm()
        {
            InitializeComponent();

            countryRepo = new GenericRepository<Country>();
            stateRepo = new GenericRepository<State>();
            cityeRepo = new GenericRepository<City>();
            supplierRepo = new GenericRepository<Supplier>();

            supplier = new Supplier();

            BindAllComoBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                MessageBox.Show("Supplier Code required");
                txtSupplierCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtSupplierName.Text.Trim()))
            {
                MessageBox.Show("Supplier Name required");
                txtSupplierName.Focus();
            }
            else
            {
                supplier.SupplierCode = txtSupplierCode.Text.Trim();
                supplier.SupplierName = txtSupplierName.Text.Trim();
                supplier.Notes = txtNotes.Text.Trim();
                supplier.VatNo = txtVatNo.Text.Trim();
                supplier.CstNo = txtCstNo.Text.Trim();
                supplier.TinNo = txtTinNo.Text.Trim();
                supplier.PanNo = txtPanNo.Text.Trim();
                supplier.PanNo = txtPanNo.Text.Trim();
                supplier.GstNo = txtGstNo.Text.Trim();
                supplier.AddressLine1 = txtAddressLine1.Text.Trim();
                supplier.AddressLine2 = txtAddressLine2.Text.Trim();
                supplier.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                supplier.StateId = Convert.ToInt32(cmbState.SelectedValue);
                supplier.CityId = Convert.ToInt32(cmbCity.SelectedValue);
                supplier.PostalCode = txtPostalCode.Text.Trim();
                supplier.FirstName = txtFirstName.Text.Trim();
                supplier.MiddleName = txtMiddleName.Text.ToLowerInvariant();
                supplier.LastName = txtLastName.Text.Trim();
                supplier.ContactNumber = txtContactNo.Text.Trim();
                supplier.MobileNumber = txtMobileNo.Text.Trim();
                supplier.WhatsppNumber = txtWhatsAppNo.Text.Trim();
                supplier.FaxNumber = txtFaxNo.Text.Trim();
                supplier.EmailAddress = txtEmail.Text.Trim();
                supplier.WebsiteUrl = txtWebsiteUrl.Text.Trim();
                supplier.IsActive = chkIsActive.Checked;
                supplier.IsPreferred = chkIsPreferredSupplier.Checked;

                supplierRepo.Add(supplier);
                supplierRepo.Save();

                this.Close();
            }
        }

        private void BindAllComoBoxes()
        {
            Utilities.Validation.BindComboBox(cmbCountry, countryRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbState, stateRepo.GetAll(), "Name", "Id", true);
            Utilities.Validation.BindComboBox(cmbCity, cityeRepo.GetAll(), "Name", "Id", true);
        }
    }
}
