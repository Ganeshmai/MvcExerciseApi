using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_2Excerise.Models;

namespace MVC_2Excerise.Controllers
{
    public class CategoryApiController : ApiController
    {
        public IEnumerable<Category> GetAll()
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                return con.Categories.ToList();
            }
        }

        // GET: api/Category/5
        public IHttpActionResult GetForId(int id)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                Category categor = con.Categories.Find(id);

                return Ok(categor);
            }
        }

        // POST: api/Category
        [HttpPost]
        public void Insert([FromBody] Category category)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                con.Categories.Add(category);
                con.SaveChanges();
            }
        }

        // PUT: api/Category/5
        [HttpPut]
        public HttpResponseMessage Update(int id, [FromBody] Category value)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                var entity = con.Categories.FirstOrDefault(i => i.Id == id);
                if (entity != null)
                {
                    entity.Name = value.Name;

                    con.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, id + " is Not found ");
                }
            }
        }

        // DELETE: api/Category/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                var entity = con.Categories.FirstOrDefault(i => i.Id == id);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee id " + id + "Not found");
                }
                else
                {
                    con.Categories.Remove(entity);
                    con.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted of" + id + "is sucessful");
                }
            }
        }

       
    }
}
