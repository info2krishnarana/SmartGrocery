using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.UI.Win.ViewModels
{
    public class PurchaseReportViewModel
    {
        public long SrNo { get; set; }
        public long ItemCod { get; set; }
        public string ItemName { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string PurchaseDate { get; set; }
    }
}