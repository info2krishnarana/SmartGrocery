using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.UI.Win.ViewModels
{
    public class PurchaseListViewModel
    {
        public long ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> PurchaseAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<long> SupplierId { get; set; }
        public string SupplierName { get; set; }
    }

    public class PurchaseViewModel
    {
    }
}
