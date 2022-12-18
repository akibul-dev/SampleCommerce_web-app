using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleCommerce.Services.Abstractions;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.DependencyResolve
{
    public class AppConfig
    {
        public static void ConfigureDependency(IServiceCollection services)
        {

            services.AddDbContext<SampleCommerceDbContext>(options =>
            {

                string connectionString = "Server=(local);Database=SampleCommerceDb; Integrated Security=true";
                options.UseSqlServer(connectionString);
            });



            // dependency resolving mechanisms

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();


        }
    }
}
