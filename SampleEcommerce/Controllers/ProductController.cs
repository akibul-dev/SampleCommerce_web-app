using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions;
using SampleEcommerce.Models;
using SampleEcommerce.Models.Product;
using SampleEcommerce.Utilities;

namespace SampleEcommerce.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        IMapper _mapper; 
        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper; 
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var product = _productService.Get();
            if (product.Any())
            {
                var products = new List<ProductVM>();

                foreach (var _product in product)
                {
                    var productvm = new ProductVM()
                    {
                        Id= _product.Id,
                        Name = _product.Name,
                        Price = _product.Price.ToString()
                        
                    };

                    products.Add(productvm);
                    
                }

                return View(products);


            }




            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = _categoryService.Get();

            var categoriesSelectListItems = categories.Select(c => new SelectListItem()
            {
                Text = c.Code +" "+c.Name,
                Value = c.Id.ToString()

            }).ToList();

            var productCreateVm = new ProductCreateVM();

            productCreateVm.Categories = categoriesSelectListItems;


            return View(productCreateVm);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product()
                    {
                        Name =model.Name,
                        Code =model.Code,
                        SubCategoryId=model.SubCategoryId,
                        Price= model.Price,
                    };

                    var result = _productService.Add(product); 

                    if(result.IsSucceed)
                    {
                        return RedirectToAction("Create");
                    }

                }

                var categories = _categoryService.Get();

                var categoriesSelectListItems = categories.Select(c => new SelectListItem()
                {

                    Text = c.Code + " " + c.Name,
                    Value = c.Id.ToString()


                }).ToList();

                var productsCreateVm = new ProductCreateVM();

                productsCreateVm.Categories = categoriesSelectListItems;


                return View(productsCreateVm);


            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
