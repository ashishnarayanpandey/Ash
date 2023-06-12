using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ash.Models.Model
{
    public class MenuItem
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(1, 2000, ErrorMessage ="Price should be between 1 to 2000")]
        public double Price { get; set; }
        public int Foodid { get; set; }
        [ForeignKey("Foodid")]
        public Food Food { get; set; }  
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public Category Category { get; set; }
    }
}
