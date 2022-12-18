using SampleCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services.Abstractions.Base
{
    public  interface IService<T> where T:class
    {

        Result Add(T entity);

        Result Update(T entity);

        Result Remove(T entity);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        ICollection<T> Get(Expression<Func<T, bool>> predicate = null);
    }
}
