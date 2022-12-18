using Microsoft.EntityFrameworkCore;
using SampleEFCore.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Repositories.Base
{

    // T = Category
    //T = Customer
    public class Repository<T> where T : class
    {
        protected SampleCommerceDbContext _db;

        private DbSet<T> Table {
            get { 
                return _db.Set<T>(); 
            } 
        }

        public Repository(SampleCommerceDbContext db)
        {
            _db = db; 
        }

        public bool Add(T entity)
        {
            Table.Add(entity);

            return _db.SaveChanges()>0;
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return _db.SaveChanges() > 0; 

        }

        public ICollection<T> GetAll()
        {
           return Table.ToList();

        }

        public ICollection<T> Get(Expression<Func<T,bool>> predicate = null)
        {
            if(predicate == null)
            {
                return Table.ToList();
            }
            return Table.Where(predicate).ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }
    }
}
