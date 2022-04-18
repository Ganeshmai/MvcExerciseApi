using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC_2Excerise.Models;

namespace MVC_2Excerise.Controllers
{
    public class UnitsController : Controller
    {
        // GET: Units
        public ActionResult GetAll()
        {
            IEnumerable<Unit> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<Unit>>().Result;
            return View(cat);
        }

        public ActionResult GetForId(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Unit>().Result);


        }
        public ActionResult Insert(int id = 0)
        {
            return View(new Unit());
        }

        [HttpPost]
        public ActionResult Insert(Unit Unit)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Unit", Unit).Result;
            return RedirectToAction("GetAll");
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit/" + id.ToString()).Result;

            return View(response.Content.ReadAsAsync<Unit>().Result);
        }
        [HttpPost]
        public ActionResult Update(Unit Unit)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Unit/" + Unit.Id, Unit).Result;
            return RedirectToAction("GetALL");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit/" + id.ToString()).Result;

            return View(response.Content.ReadAsAsync<Unit>().Result);
        }
        [HttpPost]
        public ActionResult Delete(Unit Unit)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Unit/" + Unit.Id).Result;

            return RedirectToAction("GetAll");
        }
    }
}