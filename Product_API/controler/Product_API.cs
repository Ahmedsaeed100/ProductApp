using AssignmentApp.Repository;
using AssignmentApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Product_API.controler
{
    // [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Product")]
    public class Product_API : ApiController
    {
        ProductRepository ProductRepository = new ProductRepository();

        // GET api/<controller>
        [HttpGet]
        [Route("GetProduct")]
        public List<ProductDTO> GetProduct()
        {
            var result = ProductRepository.DataLoad();
            return result.ToList();
        }

        [HttpPost]
        [Route("PostProduct")]
        public HttpResponseMessage PostProduct(ProductDTO Product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // 	ID (a randomly generated unique identifier)
                    string id = Guid.NewGuid().ToString();
                    string path = null;

                    if (Product.Image != "0")
                    {
                        id = id + "." + Product.Image.Split('.')[1];
                        byte[] ret = Convert.FromBase64String(Product.Image.Split('.')[0]);

                        path = HttpContext.Current.Server.MapPath("~/Product_Images/").ToString() + id;
                        File.WriteAllBytes(path, ret);
                        Product.Image = id;
                    }
                    else
                    {
                        Product.Image = null;
                    }


                    var result = ProductRepository.SaveProduct(Product);
                    if (result != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}