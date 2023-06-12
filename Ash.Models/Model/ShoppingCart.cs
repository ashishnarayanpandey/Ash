using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ash.Models.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int MenuItemid { get; set; }
        [ForeignKey("MenuItemid")]
        [ValidateNever]
        public MenuItem MenuItem { get; set; }
        [Range(1, 500, ErrorMessage = "please select a count between 1 to 100")]
        public int Count { get; set; }
        public string ApplicationUserid { get; set; }
        [ForeignKey("ApplicationUserid")]
        [ValidateNever]

        public ApplicationUsers ApplicationUsers { get; set;}
    }
}
