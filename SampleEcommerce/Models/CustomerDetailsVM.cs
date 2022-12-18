namespace SampleEcommerce.Models
{
    public class CustomerDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

       public ICollection<ProductVM> Products { get; set; }

    }
}
