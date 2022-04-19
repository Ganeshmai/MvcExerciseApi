using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_2Excerise.Models
{
    public class Unit
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter UnitName")]

        public string Name { get; set; }

      
    }
}