using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC_2Excerise.Models
{
    public class Product
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum char is 5 and maximum char is 10")]
        [Required(ErrorMessage = "Please enter ProductName ")]
       // [RegularExpression("[a-z]", ErrorMessage = "Invalid character")]
        public string Name { get; set; }
        [Range(1000, 10000, ErrorMessage = "Range should be between 1k & 10k")]
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