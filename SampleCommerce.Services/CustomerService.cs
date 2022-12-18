using SampleCommerce.Models;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SampleCommerce.Services.Abstractions;
using SampleCommerce.Services.Base;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class CustomerService: Service<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository; 

        }

        public ICollection<Customer> GetAll()
        {
            
            return _customerRepository.GetAll(); 
        }

        public Customer GetById(int id)
        {
            return  _customerRepository.GetFirstOrDefault(c=>c.Id == id); 

        }

        public override Result Add(Customer customer)
        {
            var result = new Result();

            //code unique 
            //var customerResult = _customerRepository.Get(cust => cust.Code == customer.Code );
            
            //if(customerResult.Any())
            //{
            //    result.IsSucceed = false;
            //    result.ErrorMessages.Add("Customer Already Exists with the same code");
            //}

            //phone no unique
            //var phoneResult = _customerRepository.Get(c => c.PhoneNo == customer.PhoneNo);

            //if(phoneResult.Any())
            //{
            //    result.IsSucceed = false;
            //    result.ErrorMessages.Add("Customer Already Exists with the same phone no. ");
            //}


            //if (result.ErrorMessages.Any())
            //{
            //    return result;
            //}


           var isSuccess = _customerRepository.Add(customer);

            if (isSuccess)
            {
                result.IsSucceed = true;
            }

            result.ErrorMessages.Add("Could not create customer!");

            return result; 
        }   

       
    }
}
