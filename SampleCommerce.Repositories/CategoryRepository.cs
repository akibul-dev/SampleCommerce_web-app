using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories.Base;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        SampleCommerceDbContext _db;
        public CategoryRepository(SampleCommerceDbContext db) : base(db)
        {
            _db = db; 
        }

        public ICollection<Category> GetByCriteria()
        {
            //implement get by criteria.
            return null;
        }
    }
}
