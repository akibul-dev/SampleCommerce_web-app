using SampleCommerce.Models;
using SampleCommerce.Services.Abstractions.Base;
using SMECommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services.Base
{
    public abstract class Service<T> : IService<T> where T : class
    {
        IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Result Add(T entity)
        {
            var result = new Result(); 
            bool isSuccess = _repository.Add(entity);
            if (isSuccess)
            {
                result.IsSucceed = true;
                return result; 
            }

            result.ErrorMessages.Add("Could not add Entity!");

            return result;
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return _repository.Get(predicate);
        }


        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFirstOrDefault(predicate);
        }

        public virtual Result Remove(T entity)
        {
            var result = new Result();
            bool isSuccess = _repository.Remove(entity);
            if (isSuccess)
            {
                result.IsSucceed = true;
                return result;
            }

            result.ErrorMessages.Add("Could not remove Entity!");

            return result;
        }

        public virtual Result Update(T entity)
        {
            var result = new Result();
            bool isSuccess = _repository.Update(entity);
            if (isSuccess)
            {
                result.IsSucceed = true;
                return result;
            }

            result.ErrorMessages.Add("Could not update Entity!");

            return result;
        }
    }
}
