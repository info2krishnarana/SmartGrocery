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
    public partial class PurchaseReportForm : Form
    {
        private IGenericRepository<Item> itemRepo;
        private IGenericRepository<Supplier> supplierRepo;
        private IGenericRepository<Purchase> purchaseRepo;

        SmartGroceryDataContext smartGroceryDataContext;
        Purchase purchase;

        public PurchaseReportForm()
        {
            InitializeComponent();

            purchaseRepo = new GenericRepository<Purchase>();
            smartGroceryDataContext = new SmartGroceryDataContext();
            purchase = new Purchase();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<ReportPurchase_Result> reportPurchase_Results = smartGroceryDataContext.ReportPurchase(dtFromDate.Value, dtToDate.Value).ToList();
                dgPurchaseList.DataSource = reportPurchase_Results;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
