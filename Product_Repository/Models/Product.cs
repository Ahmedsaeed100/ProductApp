//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Product_Repository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Image { get; set; }
        public Nullable<int> views { get; set; }
        public Nullable<int> impressions { get; set; }
        public int Vendor_UID { get; set; }
    
        public virtual Vendor Vendor { get; set; }
    }
}
