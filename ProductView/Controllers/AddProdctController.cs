using AssignmentApp.ViewModel;
using System;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ProductView.Controllers
{
    public class AddProdctController : Controller
    {
        string Baseurl = Setting.server;
        // GET: AddProdct
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public HttpResponseMessage PostProdct(ProductDTO Pro)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.PostAsJsonAsync("api/Product_API/PostProduct", Pro).Result;
                return response;
            }
        }
    }
}