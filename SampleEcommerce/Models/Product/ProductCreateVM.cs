using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SampleEcommerce.Models.Product
{
    public class ProductCreateVM
    {
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }
        [Required] public double Price { get; set; }
         
        [Required(ErrorMessage ="SubCategory is required")]
        public int SubCategoryId { get; set; }

        public List<SelectListItem>? Categories { get; set; }
    }
}
