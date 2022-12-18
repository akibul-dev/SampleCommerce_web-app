using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleCommerce.Services.Abstractions;
using SampleEcommerce.Models.Category;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System.Diagnostics;

namespace SampleEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IMapper _mapper; 

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper; 
            

           
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _categoryService.Get();

            var categoryListItemVms = categories.Select(c => new CategoryListItemVM()
            {
                Id = c.Id, 
                Name = c.Name,
                Code = c.Code,
                Description = c.Description
            });

            return View(categoryListItemVms);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreateVM model)
        {
            if (ModelState.IsValid)
            {
                

                //var category = new Category()
                //{
                //    Name = model.Name,
                //    Code = model.Code,
                //    Description = model.Description
                //};

                var category = _mapper.Map<Category>(model);

               var result =  _categoryService.Add(category);

                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");

                }

                if (result.ErrorMessages.Any()) 
                { 
                    foreach(var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError("", error);
                    }
                    
                }

            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
