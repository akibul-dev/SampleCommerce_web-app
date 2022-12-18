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
    public class SubCategoryRepository : Repository<SubCategory> , ISubCategoryRepository
    {
        SampleCommerceDbContext _db;
        public SubCategoryRepository(SampleCommerceDbContext db) : base(db)
        {
            _db = db;
        }
       
    }
}
