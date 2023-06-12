using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ash.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [ValidateNever]
        public OrderHeader orderHeader { get; set; }
        [Required]
        public int MenuItemid  {get; set; }
        [ForeignKey("MenuItemid")]
        public virtual MenuItem MenuItem { get; set; }
        public int Count { get; set; }
        [Required]
        public double Price { get; set; }
        public string Name { get; set; }

    }
}
