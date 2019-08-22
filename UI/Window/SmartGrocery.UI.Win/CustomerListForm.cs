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
    public partial class CustomerListForm : Form
    {
        private IGenericRepository<Customer> customerRepo;

        public CustomerListForm()
        {
            InitializeComponent();

            customerRepo = new GenericRepository<Customer>();
            BindCustomerDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = null;
            customerForm = new CustomerForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            customerForm.ShowDialog();
            BindCustomerDataGrid();
        }

        private void BindCustomerDataGrid()
        {
            dgCustomer.DataSource = customerRepo.GetAll();
        }
    }
}
