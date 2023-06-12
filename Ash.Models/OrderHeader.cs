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
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Display(Name ="Order Total")]
        public double OrderTotal { get; set; }
        [Required]
        [Display(Name ="Pickup Time")]
        public DateTime PickUpTime { get; set; }
        [Required]
        [Display(Name = "Pickup Date")]
        [NotMapped]
        public DateTime PickUpDate { get; set; }
        public string Status { get; set; }
        public string? Comment { get; set; }
        public string? TransactionId { get; set; }
        [Display(Name ="Pickup Name")]
        [Required]
        public string PickUpName { get; set; }
        [Display(Name ="Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
