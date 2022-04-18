using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC_2Excerise.Models;

namespace MVC_2Excerise.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult GetAll()
        {
            IEnumerable<Product> products;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return View(products);
        }
        public ActionResult GetForId(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Product>().Result);


        }
        public ActionResult Save(int id = 0)
        {
            if (id == 0)
                return View(new Product());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Product>().Result);
            }
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", product).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/" + product.Id,product).Result;
            }
            return RedirectToAction("GetAll");
        }

        //     [HttpPost]
        //// [HttpPut]
        // public ActionResult Save(int id = 0,Product product=null)
        // {
        //     if (id == 0)
        //     {
        //         HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", product).Result;
        //         return RedirectToAction("GetAll");
        //     }
        //     else if(id >=0 && product==null)
        //     {
        //         HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category/" + id.ToString()).Result;

        //         return View(response.Content.ReadAsAsync<Category>().Result);
        //     }

        //     else if (id >= 0 && product != null)
        //     {
        //         HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Category/" + product.Id, product).Result;
        //         return RedirectToAction("GetALL");
        //     }


        //     return View("GetAll");
        // }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id.ToString()).Result;

            return View(response.Content.ReadAsAsync<Product>().Result);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Product/" + product.Id).Result;

            return RedirectToAction("GetAll");
        }
    }
}