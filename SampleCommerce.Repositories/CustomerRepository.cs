using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories.Base;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Repositories
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        

        public CustomerRepository(SampleCommerceDbContext db) : base(db)
        {
           
        }

        public bool Add(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Customer customer)
        {
            _db.Customers.Update(customer);
            return _db.SaveChanges() > 0;
        }

        public bool Remove(Customer customer)
        {
            _db.Customers.Remove(customer);
            return _db.SaveChanges() > 0;
        }

        public Customer GetById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }


        public ICollection<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }


        public ICollection<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            return _db.Customers
                            .Where(predicate).ToList();
          
        }
    }
}
