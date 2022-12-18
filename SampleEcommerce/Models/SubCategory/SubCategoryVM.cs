using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SampleEcommerce.Models.SubCategory
{
    public class SubCategoryVM
    {
        public string Name { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem>? CategoryList { get; set; }

    }
}
