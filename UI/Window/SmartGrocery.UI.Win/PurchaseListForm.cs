using SmartGrocery.Data.Repository;
using SmartGrocery.Entity.DataModel;
using SmartGrocery.UI.Win.ViewModels;
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
    public partial class PurchaseListForm : Form
    {
        private IGenericRepository<Item> itemRepo;
        private IGenericRepository<Supplier> supplierRepo;
        private IGenericRepository<Purchase> purchaseRepo;

        Item item;
        Supplier supplier;
        Purchase purchase;
        PurchaseListViewModel purchaseListViewModel;
        List<PurchaseListViewModel> purchaseListViewModelList;
        List<Purchase> purchaseList;

        public PurchaseListForm()
        {
            try
            {
                InitializeComponent();

                itemRepo = new GenericRepository<Item>();
                supplierRepo = new GenericRepository<Supplier>();
                purchaseRepo = new GenericRepository<Purchase>();

                // item = new Item();
                //supplier = new Supplier();
                //purchaseListViewModel = new PurchaseListViewModel();
                purchaseListViewModelList = new List<PurchaseListViewModel>();

                BindAllComoBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
                {
                    MessageBox.Show("Quantity required");
                }
                else if (string.IsNullOrEmpty(txtPurchaseAmount.Text.Trim()))
                {
                    MessageBox.Show("Purchase Amount required");
                }
                else if (string.IsNullOrEmpty(txtPaidAmount.Text.Trim()))
                {
                    MessageBox.Show("Paid Amount required");
                }
                else
                {
                    //purchaseListViewModelList.Clear();
                    //add existing items to list
                    //foreach (DataGridViewRow dataGridViewRowExisting in dgPurchaseList.Rows)
                    //{
                    //    //purchaseListViewModel = new PurchaseListViewModel();

                    //    //purchaseListViewModel.ItemCode = Convert.ToInt64(dataGridViewRowExisting.Cells["ItemCode"].Value);
                    //    ////item = itemRepo.GetById(purchaseListViewModel.ItemCode);
                    //    //purchaseListViewModel.ItemName = Convert.ToString(dataGridViewRowExisting.Cells["ItemName"].Value);
                    //    //purchaseListViewModel.BarCode = Convert.ToString(dataGridViewRowExisting.Cells["BarCode"].Value);
                    //    //purchaseListViewModel.Quantity = Convert.ToInt32(dataGridViewRowExisting.Cells["Quantity"].Value);
                    //    //purchaseListViewModel.PurchaseAmount = Convert.ToInt64(dataGridViewRowExisting.Cells["PurchaseAmount"].Value);
                    //    //purchaseListViewModel.PaidAmount = Convert.ToInt64(dataGridViewRowExisting.Cells["PaidAmount"].Value);
                    //    //purchaseListViewModel.SupplierId = Convert.ToInt64(dataGridViewRowExisting.Cells["SupplierId"].Value);
                    //    //purchaseListViewModel.SupplierName = Convert.ToString(dataGridViewRowExisting.Cells["SupplierName"].Value);

                    //    dgPurchaseList.Rows.Add(dataGridViewRowExisting);
                    //}

                    //add new item to list
                    //purchaseListViewModel = new PurchaseListViewModel();

                    item = new Item();
                    supplier = new Supplier();
                    item = itemRepo.GetById(Convert.ToInt64(cmbItems.SelectedValue));
                    supplier = supplierRepo.GetById(Convert.ToInt32(cmbSupplier.SelectedValue));

                    //purchaseListViewModel.ItemCode = Convert.ToInt64(cmbItems.SelectedValue);
                    //purchaseListViewModel.ItemName = item.Name;
                    //purchaseListViewModel.BarCode = item.Barcode;// itemRepo.GetById(purchaseListViewModel.ItemCode).Barcode;
                    //purchaseListViewModel.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    //purchaseListViewModel.PurchaseAmount = Convert.ToDecimal(txtPurchaseAmount.Text.Trim());
                    //purchaseListViewModel.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());
                    //purchaseListViewModel.SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                    //purchaseListViewModel.SupplierName = supplierRepo.GetById(purchaseListViewModel.SupplierId).SupplierName;

                    dgPurchaseList.Rows.Insert(0,
                        Convert.ToInt64(cmbItems.SelectedValue),
                        item.Name,
                        item.Barcode,
                        Convert.ToInt32(txtQuantity.Text.Trim()),
                        Convert.ToDecimal(txtPurchaseAmount.Text.Trim()),
                        Convert.ToDecimal(txtPaidAmount.Text.Trim()),
                        Convert.ToInt32(cmbSupplier.SelectedValue),
                        supplier.SupplierName
                        );

                    //dgPurchaseList.Update();
                    //dgPurchaseList.Refresh();

                    ClearInputs();
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
                Utilities.Validation.BindComboBox(cmbItems, itemRepo.GetAll(), "Name", "Id", true);
                Utilities.Validation.BindComboBox(cmbSupplier, supplierRepo.GetAll(), "SupplierName", "Id", true);

               // dgPurchaseList.DataSource = purchaseListViewModelList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllowOnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cmbItems.se
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtQuantity.Text = string.Empty;
            txtPurchaseAmount.Text = string.Empty;
            txtPaidAmount.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            //dgPurchaseList.DataSource = null;

            dgPurchaseList.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                purchaseList = new List<Purchase>();

                foreach (DataGridViewRow dataGridViewRowExisting in dgPurchaseList.Rows)
                {
                    purchase = new Purchase();

                    purchase.ItemCode = Convert.ToInt64(dataGridViewRowExisting.Cells["ItemCode"].Value);
                    //item = itemRepo.GetById(purchaseListViewModel.ItemCode);
                    if (purchase.ItemCode > 0)
                    {
                        //purchase.ItemName = Convert.ToString(dataGridViewRowExisting.Cells["ItemName"].Value);
                        //purchase.BarCode = Convert.ToString(dataGridViewRowExisting.Cells["BarCode"].Value);
                        purchase.Quantity = Convert.ToInt32(dataGridViewRowExisting.Cells["Quantity"].Value);
                        purchase.PurchaseAmount = Convert.ToInt64(dataGridViewRowExisting.Cells["PurchaseAmount"].Value);
                        purchase.PaidAmount = Convert.ToInt64(dataGridViewRowExisting.Cells["PaidAmount"].Value);
                        purchase.SupplierId = Convert.ToInt64(dataGridViewRowExisting.Cells["SupplierId"].Value);
                        //purchase.SupplierName = Convert.ToString(dataGridViewRowExisting.Cells["SupplierName"].Value);
                        purchase.CreatedDate = DateTime.Now;
                        purchase.UpdatedDate = DateTime.Now;

                        purchaseList.Add(purchase);
                    }
                }

                if (purchaseList.Count < 1)
                {
                    MessageBox.Show("Please add at least one item in Purchase List");
                }
                else
                {
                    purchaseRepo.Add(purchaseList);
                    //foreach (Purchase purchaseItem in purchaseList)
                    //{
                    //    purchaseRepo.Add(purchaseItem);
                    //}
                    purchaseRepo.Save();

                    MessageBox.Show("Purchase Items saved successfully");

                    dgPurchaseList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
