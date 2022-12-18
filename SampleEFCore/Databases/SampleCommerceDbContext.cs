using Microsoft.EntityFrameworkCore;
using SampleEFCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEFCore.Databases
{
    public class SampleCommerceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = "Server=(local);Database=SampleCommerceDb; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
