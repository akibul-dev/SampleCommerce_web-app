using System.ComponentModel.DataAnnotations;

namespace SampleEcommerce.Models.Category
{
    public class CategoryCreateVM
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Code { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
