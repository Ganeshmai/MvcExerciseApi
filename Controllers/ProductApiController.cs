using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_2Excerise.Models;

namespace MVC_2Excerise.Controllers
{
    public class ProductApiController : ApiController
    {

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            using (ProductDbEntity db = new ProductDbEntity())
            {
                return db.Products.ToList();
            }
        }

        // GET: api/Product/5
        public Product GetForId(int id)
        {

            using (ProductDbEntity db = new ProductDbEntity())
            {
                return (db.Products.FirstOrDefault(i => i.Id == id));


            }
        }

        [HttpPost]

        public void Save([FromBody] Product product)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
               
                con.Products.Add(product);
                con.SaveChanges();
            }
        }
        [HttpPut]
        public HttpResponseMessage Update(int id, [FromBody] Product value)
        {
            using (ProductDbEntity con = new ProductDbEntity())
            {
                var entity = con.Products.FirstOrDefault(i => i.Id == id);
                if (entity != null)
                {
                    entity.Name = value.Name;
                    entity.Price = value.Price;
                    entity.CategoryId = value.CategoryId;
                    entity.UnitId = value.UnitId;

                    con.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, id + " is Not found ");
                }
            }
        }

        #region ApiProduct
        // POST: api/Product
        //  [HttpPost]
        ////  [HttpPut]
        //  public HttpResponseMessage Save(Product values=null, int id = 0)//INsert and update on same
        //  {
        //      if (id == 0)
        //      {
        //          using (ProductDbEntity db = new ProductDbEntity())
        //          {
        //              db.Products.Add(values);
        //              db.SaveChanges();
        //          }

        //      }
        //      else
        //      {
        //          using (ProductDbEntity db = new ProductDbEntity())
        //          {
        //              var entity = db.Products.FirstOrDefault(i => i.Id == id);

        //              if (entity != null)
        //              {
        //                  entity.Name = values.Name;
        //                  entity.CategoryId = values.CategoryId;
        //                  entity.Price = values.Price;
        //                  entity.UnitId = values.UnitId;

        //                  db.SaveChanges();

        //              }
        //              return Request.CreateResponse(HttpStatusCode.OK, entity);

        //          }
        //      }
        //      return Request.CreateResponse(HttpStatusCode.OK);

        //  }

        // PUT: api/Product/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        #endregion

        // DELETE: api/Product/5
        [HttpDelete]
            public HttpResponseMessage Delete(int id)
            {

                using (ProductDbEntity con = new ProductDbEntity())
                {
                    var entity = con.Products.FirstOrDefault(i => i.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ProductId id " + id + "Not found");
                    }
                    else
                    {
                        con.Products.Remove(entity);
                        con.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Deleted of" + id + "is sucessful");
                    }
                }
            }

        }
    } 
