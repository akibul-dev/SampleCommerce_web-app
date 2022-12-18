using Microsoft.AspNetCore.Mvc;
using SampleCommerce.API.ApiModel.Product;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions;

namespace SampleCommerce.API.Controllers
{

    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.Get();

            if (products == null && !products.Any())
            {
                return NotFound();
            }
            return Ok(products);

        }
        [HttpGet("{id}")]
        //api/products/id
        public IActionResult Get(int id)
        {
            var product = _productService.GetFirstOrDefault(c=>c.Id==id);
            if (product == null)
            {
                return NotFound();
            }
           return Ok(product);

        }
        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateDTO model )
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name= model.Name,
                    Price= model.Price,
                    Code   =model.Code,
                    SubCategoryId=model.SubCategoryId,

                };

               var result = _productService.Add(product);

                if (result.IsSucceed)
                {
                    return Ok(product);
                }

            }

            return BadRequest();
        }


    }
}
