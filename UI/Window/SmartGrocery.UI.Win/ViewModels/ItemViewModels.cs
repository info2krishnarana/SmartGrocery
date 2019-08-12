using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.UI.Win.ViewModels
{
    public class ItemViewModels
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Mrp { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> ProductTypeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string Photo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> SaleOnline { get; set; }
        public Nullable<bool> NotForSale { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
