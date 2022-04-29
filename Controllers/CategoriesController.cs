using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC_2Excerise.Models;

namespace MVC_2Excerise.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult GetAll()
        {
            IEnumerable<Category> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CategoryApi").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            return View(cat);
        }

        public ActionResult GetForId(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CategoryApi/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Category>().Result);


        }
        public ActionResult Insert(int id = 0)
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Insert(Category category)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CategoryApi", category).Result;
            return RedirectToAction("GetAll");
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CategoryApi/" + id.ToString()).Result;

            return View(response.Content.ReadAsAsync<Category>().Result);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CategoryApi/" + category.Id, category).Result;
            return RedirectToAction("GetALL");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CategoryApi/" + id.ToString()).Result;

            return View(response.Content.ReadAsAsync<Category>().Result);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("CategoryApi/" + category.Id).Result;

            return RedirectToAction("GetAll");
        }

    }
}