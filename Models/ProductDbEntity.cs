using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_2Excerise.Models
{
    public class ProductDbEntity : DbContext
    {
        public ProductDbEntity():base("DefaultCon")
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

    }
}