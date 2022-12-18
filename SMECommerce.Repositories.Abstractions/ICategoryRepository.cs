using SampleCommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMECommerce.Repositories.Abstractions
{
    public interface ICategoryRepository : IRepository <Category>
    {
        ICollection<Category> GetByCriteria();
    }
}
