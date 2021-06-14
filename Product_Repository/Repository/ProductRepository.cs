using AssignmentApp.Mapper;
using AssignmentApp.ViewModel;
using Product_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentApp.Repository
{
    public class ProductRepository
    {
        AssignmentEntities DB = new AssignmentEntities();

        // Show Products
        public List<ProductDTO> DataLoad()
        {
            var result = DB.Products.Select(m => new ProductDTO()
            {
                ID = m.ID,
                Title = m.Title,
                Description = m.Description,
                Price = m.Price,
                Image = m.Image,
                Vendor = m.Vendor,
                impressions = m.impressions,
                views = m.views,

            }).ToList();
            return result;
        }


        // Save Product
        public int SaveProduct(ProductDTO result)
        {
            Product ProductsResult = ProductMapper.ProductDTOToProduct(result);
            try
            {
                DB.Products.Add(ProductsResult);
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        // Update Product
        public int UpdateProduct(ProductDTO result)
        {
            Product resultDomain = ProductMapper.ProductDTOToProduct(result);
            try
            {
                DB.Entry(resultDomain).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        // Delete Product By Id
        public int DeleteProduct(int? id)
        {
            try
            {
                Product result = DB.Products.Find(id);
                DB.Products.Remove(result);
                DB.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        // Sreach For product by Title
        public List<ProductDTO> SearchforProduct(string ProductTitle)
        {
            var result = DB.Products.Where(c => c.Title == ProductTitle).Select(x => new ProductDTO()
            {
                Title = x.Title,
            }).ToList();

            return result;
        }

    }
}