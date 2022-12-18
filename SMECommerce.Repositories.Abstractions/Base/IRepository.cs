using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMECommerce.Repositories.Abstractions.Base
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        ICollection<T> GetAll();
        ICollection<T> Get(Expression<Func<T, bool>> predicate = null);

    }
}
