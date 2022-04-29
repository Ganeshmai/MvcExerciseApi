using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MVC_2Excerise.Models;
namespace MVC_2Excerise
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44331/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
         
        }

        //public IEnumerable <Category> GetAllCategoryId()
        //{
        //    HttpResponseMessage response = WebApiClient.GetAsync("Category/GetAll").Result;
        //    if (response != null)
        //        return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                  
        //    return null;
        //}
    }
}