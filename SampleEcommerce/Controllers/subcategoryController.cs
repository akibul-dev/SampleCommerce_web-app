using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions;
using SampleEcommerce.Models.SubCategory;

namespace SampleEcommerce.Controllers
{
    public class subcategoryController : Controller
    {
        ISubCategoryService _subCategory;
        ICategoryService _CategoryService;
        public subcategoryController(ISubCategoryService subCategory, ICategoryService categoryService)
        {
            _subCategory = subCategory;
            _CategoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Create()
        {
            var categories = _CategoryService.Get();

            var selectedCategorylist = categories.Select(c => new SelectListItem()
            {
                Text = c.Name+ " "+ c.Code +" "+ c.Id,
                Value = c.Id.ToString(),
            }).ToList();

            var categoryCreateVM = new SubCategoryVM();

            categoryCreateVM.CategoryList = selectedCategorylist;

            return View(categoryCreateVM);
        }


        [HttpPost]
        public IActionResult Create(SubCategoryVM model)
        {
            

            if (ModelState.IsValid)
            {
               

                var subCategory = new SubCategory()
                {
                    Name = model.Name,
                    Code= model.Code,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    
                };

                var result = _subCategory.Add(subCategory);
                if (result.IsSucceed)
                {
                    Console.WriteLine("SubCategory has Created");
                }

            }
            var categories = _CategoryService.Get();

            var selectedCategorylist = categories.Select(c => new SelectListItem()
            {
                Text = c.Name + " " + c.Code + " " + c.Id,
                Value = c.Id.ToString(),
            }).ToList();

            var categoryCreateVM = new SubCategoryVM();

            categoryCreateVM.CategoryList = selectedCategorylist;


            return View(categoryCreateVM);
        }

        [HttpGet("/api/categories/{Categoryid}/subcategories")]
        public IActionResult GetByCategpryId(int Categoryid)
        {

            var subCategory = _subCategory.Get(c=>c.CategoryId== Categoryid);
            if (subCategory != null)
            {
                return Ok(subCategory);
            }

            return NotFound();
        }

    }
}
