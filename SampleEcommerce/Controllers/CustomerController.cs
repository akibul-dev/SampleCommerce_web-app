using Microsoft.AspNetCore.Mvc;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleCommerce.Services.Abstractions;
using SampleEcommerce.Models;

namespace SampleEcommerce.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
       
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            

            if (!customers.Any())
            {
                ViewBag.Message = "No Data Found";
                return View(); 
            }

            var customerListVms = new List<CustomerListItemVM>(); 
            foreach (var customer in customers)
            {
                var customerListVm = new CustomerListItemVM()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Code = customer.Code,
                    Address = customer.Address,
                    DeliveryLocation = customer.DeliveryLocation,
                    PhoneNo = customer.PhoneNo,
                    CreatedBy = customer.CreatedBy,
                    CreatedDate = customer.CreatedDate,
                    LastUpdatedBy = customer.LastUpdatedBy,
                    LastUpdatedDate = (DateTime)customer.LastUpdatedDate

                };

                customerListVms.Add(customerListVm);
            }

            return View(customerListVms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var customer = new Customer()
                {
                    Name = model.Name,
                    Code = model.Code,
                    Address = model.Address,
                    PhoneNo = model.Phone,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                };


              var result = _customerService.Add(customer);

                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }

                if(result.ErrorMessages.Any())
                {
                    foreach (var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError("", error);
                    }
                   
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetById(id);
            if(customer == null)
            {
                ViewBag.Message = "No Customer Found!";
                return View("_NotFound");
            }


            var customerEditVm = new CustomerEditVM()
            {
                Id = customer.Id,
                Name = customer.Name,
                Code = customer.Code,
                Address = customer.Address,
                DeliveryLocation = customer.DeliveryLocation,
                PhoneNo = customer.PhoneNo
            };

            return View(customerEditVm);

        }

        [HttpPost]
        public IActionResult Edit(CustomerEditVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.GetById(model.Id);
                if (customer == null)
                {
                    ViewBag.Message = "No Customer Found!";
                    return View("_NotFound");
                }

                customer.Name = model.Name;
                customer.Code = model.Code;
                customer.PhoneNo = model.PhoneNo;
                customer.Address = model.Address;
                customer.DeliveryLocation = model.DeliveryLocation;
                customer.LastUpdatedBy = "Customer Manager";
                customer.LastUpdatedDate = DateTime.Now;


                var result = _customerService.Update(customer);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }




        public IActionResult Details(CustomerDetailsVM customerDetails)
        {
            
            return View(customerDetails);
        }

       
    }
}
