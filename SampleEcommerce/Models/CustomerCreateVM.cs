using System.ComponentModel.DataAnnotations;

namespace SampleEcommerce.Models
{
    public class CustomerCreateVM
    {
        [Required(ErrorMessage ="Please provide Name")]
        public string Name { get; set; }

        public string Code { get; set; }


        [Required]
        public string Phone { get; set; }

        public string? Address { get; set; }
    }
}
