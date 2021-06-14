using Product_Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentApp.ViewModel
{
    public class ProductDTO
    {
        public string ID { get; set; }
        [DisplayName("Product Title")]
        [Required(ErrorMessage = "Product Title is Required!")]
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