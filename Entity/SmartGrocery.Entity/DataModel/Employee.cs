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
    
    public partial class Employee
    {
        public long Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public Nullable<System.DateTime> AnniversaryDate { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string PostalCode { get; set; }
        public string ContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual State State { get; set; }
    }
}
