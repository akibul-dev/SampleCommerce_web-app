using Microsoft.EntityFrameworkCore;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SampleCommerce.Services.Abstractions;
using SampleCommerce.Services.Base;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        ICategoryRepository _categoryRepository; 

        public CategoryService(ICategoryRepository categoryRepository):base(categoryRepository)
        {
            _categoryRepository = categoryRepository;         
            
        }       
    }
}
