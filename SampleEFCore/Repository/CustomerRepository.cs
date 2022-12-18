using SampleEFCore.Databases;
using SampleEFCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEFCore.Repository
{
    public class CustomerRepository
    {
        SampleCommerceDbContext _db;

        public CustomerRepository()
        {
            _db = new SampleCommerceDbContext();
        }

        public bool Create(Customer customer)
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
    }
}
