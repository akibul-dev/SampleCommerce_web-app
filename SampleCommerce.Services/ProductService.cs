using SampleCommerce.Models;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions;
using SampleCommerce.Services.Base;
using SMECommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }


        public override Result Add(Product entity)
        {
            var result = new Result();
            //Check Product if Product Code Unique
            var existingProduct = _productRepository.GetFirstOrDefault(c => c.Code == entity.Code);

            if (existingProduct!=null)
            {
               
                result.ErrorMessages.Add("Product code already exists");
            }

            if (result.ErrorMessages.Any())
            {
                result.IsSucceed = false;
                return result;
            }


            return base.Add(entity);
        }
    }
}
