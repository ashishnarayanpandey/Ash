using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ash.Models.Model
{
    public class Food
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please Enter Food Name")]
        public string Name { get; set; }
    }
}
