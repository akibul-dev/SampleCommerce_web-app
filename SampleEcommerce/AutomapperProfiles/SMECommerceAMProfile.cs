using AutoMapper;
using SampleCommerce.Models.EntityModels;
using SampleEcommerce.Models.Category;
using SampleEcommerce.Models.Product;

namespace SampleEcommerce.AutomapperProfiles
{
    public class SMECommerceAMProfile : Profile
    {
        public SMECommerceAMProfile()
        {
            CreateMap<CategoryCreateVM, Category>();
            CreateMap<Category, CategoryCreateVM>();
            CreateMap<ProductCreateVM, Product>();
        }
    }
}
