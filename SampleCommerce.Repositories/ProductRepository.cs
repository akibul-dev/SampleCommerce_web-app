using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleEFCore.Databases;
using SampleCommerce.Services.Abstractions;

namespace SampleCommerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        
        public ProductRepository(SampleCommerceDbContext db)  : base(db)
        {
            
        }
    }
}
