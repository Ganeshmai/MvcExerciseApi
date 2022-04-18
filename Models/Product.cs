using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC_2Excerise.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        [IgnoreDataMember]
        [ForeignKey("CategoryId")]
        public  Category Categorys { get; set; }


        public int UnitId { get; set; }

        [IgnoreDataMember]
        [ForeignKey("UnitId")]
        public  Unit Units { get; set; }
    }
}