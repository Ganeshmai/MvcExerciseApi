using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_2Excerise.Models
{
    public class Category
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        [Required(ErrorMessage="Please Category student name.")]
        public string Name { get; set; }

      
    }
}