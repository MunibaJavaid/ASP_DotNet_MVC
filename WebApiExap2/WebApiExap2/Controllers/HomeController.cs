using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using WebApiExap2.Models;

namespace WebApiExap2.Controllers
{
    public class HomeController : Controller
    {
        HttpClient hc = new HttpClient();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Display()
        {
            List<Product> list = new List<Product>();


            hc.BaseAddress = new Uri("http://localhost:50778/api/WebApi");
            var consume = hc.GetAsync("WebApi");
            consume.Wait();

            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                list = display.Result;
            }

            return View(list);


        }
        [HttpGet]
        public ActionResult ProdCreate()
        {
            return View();
        }

       [HttpPost]
        public ActionResult ProdCreate(Product Prod)
        {
            hc.BaseAddress = new Uri("http://localhost:50778/api/WebApi");
            var consume = hc.PostAsJsonAsync<Product>("WebApi", Prod);

            consume.Wait();

            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult DetailsProduct(int id) //1
        {
            Product p = null;
            hc.BaseAddress = new Uri("http://localhost:50778/api/WebApi");
            var cons = hc.GetAsync("WebApi?id" + id.ToString());
            cons.Wait();
            var test = cons.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
               
                p = display.Result;
            }
                return View(p);
        }
    }
}
