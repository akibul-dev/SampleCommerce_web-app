﻿using SampleCommerce.Models;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services.Abstractions
{
    public interface ICustomerService : IService<Customer>
    {
        ICollection<Customer> GetAll();
        Customer GetById(int id);

       
    }
}
