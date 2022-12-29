using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExap2.Models;

namespace WebApiExap2.Controllers
{
    public class WebApiController : ApiController
    {
        PartialViewDbEntities db = new PartialViewDbEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult ApiMethod()
        {
            List<Product> list = db.Products.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]

        public IHttpActionResult InsProdMethod(Product prod)
        {
            db.Products.Add(prod);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpGet]


        public IHttpActionResult DetailsProdMethod(int id) //1
        {
            var prod = db.Products.Where(model => model.ProductId == id).FirstOrDefault(); //1 == 1
            return Ok(prod);
        }


    }
}
