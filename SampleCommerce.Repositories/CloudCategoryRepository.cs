using SampleCommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Repositories
{
    public class CloudCategoryRepository : ICategoryRepository
    {
        public bool Add(Category entity)
        {
            // AWS Related implemenation
            throw new NotImplementedException();
        }

        public ICollection<Category> Get(Expression<Func<Category, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetByCriteria()
        {
            throw new NotImplementedException();
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
