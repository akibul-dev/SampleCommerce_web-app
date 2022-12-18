using SampleCommerce.Models.EntityModels;
using SampleCommerce.Services.Abstractions;
using SampleCommerce.Services.Base;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class SubCategoryService : Service<SubCategory>, ISubCategoryService
    {
        ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository) : base(subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

      
    }
}
