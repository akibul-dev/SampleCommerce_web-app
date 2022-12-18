using System.ComponentModel.DataAnnotations;

namespace SampleEcommerce.Models
{
    public class CustomerEditVM
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(11)]
        public string PhoneNo { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string? DeliveryLocation { get; set; }
    }
}
