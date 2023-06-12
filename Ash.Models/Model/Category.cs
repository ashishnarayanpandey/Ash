using System.ComponentModel.DataAnnotations;

namespace Ash.Models.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage="Please Enter Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter DisplayOrder Number")]
        public int? DisplayOrder { get; set; }
    }
}
