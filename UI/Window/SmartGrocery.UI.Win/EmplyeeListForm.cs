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
    public partial class EmplyeeListForm : Form
    {
        private IGenericRepository<Employee> employeeRepo;

        public EmplyeeListForm()
        {
            InitializeComponent();

            employeeRepo = new GenericRepository<Employee>();
            BindEmployeeDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = null;
            employeeForm = new EmployeeForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            employeeForm.ShowDialog();
            BindEmployeeDataGrid();
        }

        private void BindEmployeeDataGrid()
        {
            dgEmployee.DataSource = employeeRepo.GetAll();
        }
    }
}
