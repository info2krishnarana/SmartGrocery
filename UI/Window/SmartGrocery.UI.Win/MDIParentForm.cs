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
    public partial class MDIParentForm : Form
    {
        public MDIParentForm()
        {
            InitializeComponent();
        }

        //private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MastersForm addressForm = null;
        //    addressForm = new MastersForm();
        //    //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
        //    addressForm.ShowDialog();
        //    //if (!Utilities.Validation.IsAlreadyOpen(typeof(AddressForm)))
        //    //{
        //        //addressForm = new AddressForm
        //        //{
        //        //    //MdiParent = this,
        //        //    //Left = 10,
        //        //    //Top = 10
        //        //};
        //        //addressForm.Size = addressForm.ParentForm.ClientRectangle.Size;
        //        //addressForm = new AddressForm();
        //        //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
        //        //addressForm.ShowDialog();
        //    //}
        //}

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateStoreForm createStoreForm = null;
            createStoreForm = new CreateStoreForm();
            //createStoreForm.Size = Size.Subtract(createStoreForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            createStoreForm.ShowDialog();
            //if (!Utilities.Validation.IsAlreadyOpen(typeof(AddressForm)))
            //{
            //    createStoreForm = new CreateStoreForm();
            //    //createStoreForm = new CreateStoreForm
            //    //{
            //    //    MdiParent = this,
            //    //    //Left = 10,
            //    //    //Top = 10
            //    //};
            //    //addressForm.Size = addressForm.ParentForm.ClientRectangle.Size;
            //    createStoreForm.Size = Size.Subtract(createStoreForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            //    createStoreForm.ShowDialog();
            //}
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ItemForm itemForm = null;
            //itemForm = new ItemForm();
            ////addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            //itemForm.ShowDialog();

            ItemListForm itemListForm = null;
            itemListForm = new ItemListForm();            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            itemListForm.ShowDialog();
        }       

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListForm customerListForm = null;
            customerListForm = new CustomerListForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            customerListForm.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmplyeeListForm emplyeeListForm = null;
            emplyeeListForm = new EmplyeeListForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            emplyeeListForm.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierListForm supplierListForm = null;
            supplierListForm = new SupplierListForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            supplierListForm.ShowDialog();
        }

        private void masterSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MastersForm addressForm = null;
            //addressForm = new MastersForm();
            ////addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            //addressForm.ShowDialog();
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MastersForm addressForm = null;
            addressForm = new MastersForm();
            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            addressForm.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseListForm purchaseListForm = null;
            purchaseListForm = new PurchaseListForm();            //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            purchaseListForm.ShowDialog();
        }

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseReportForm purchaseReportForm = new PurchaseReportForm();           //addressForm.Size = Size.Subtract(addressForm.ParentForm.ClientRectangle.Size, new Size(10, 30));
            purchaseReportForm.ShowDialog();
        }
    }
}
