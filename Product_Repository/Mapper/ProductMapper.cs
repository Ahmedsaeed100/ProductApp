using AssignmentApp.ViewModel;
using Product_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentApp.Mapper
{
    public class ProductMapper
    {
        public static Product ProductDTOToProduct(ProductDTO DTo)
        {
            if (DTo == null) return null;

           

            var MASTER = new Product()
            {
                ID = DTo.ID,
                Title = DTo.Title,
                Description = DTo.Description,
                Price = DTo.Price,
                Image = DTo.Image,
                impressions = DTo.impressions,
                views = DTo.views,
                Vendor = DTo.Vendor,
            };

            return MASTER;
        }
        public static ProductDTO ProductToProductDTO(Product DTo)
        {
            if (DTo == null) return null;
            var Product = new ProductDTO()
            {
                ID = DTo.ID,
                Title = DTo.Title,
                Description = DTo.Description,
                Price = DTo.Price,
                Image = DTo.Image,
                impressions = DTo.impressions,
                views = DTo.views,
                Vendor = DTo.Vendor
            };

            return Product;
        }
    }
}