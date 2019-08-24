using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.UI.Win.ViewModels
{
    public class ItemViewModel
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Mrp { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string ProductType { get; set; }
        public string Photo { get; set; }
    }
}
