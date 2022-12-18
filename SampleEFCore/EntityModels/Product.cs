using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEFCore.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string GetInfo()
        {
            return $"Product Name: {Name}, Product Code: {Code}, Price: {Price}";
        }

    }
}
