//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartGrocery.Entity.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pincode { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual City City { get; set; }
    }
}
