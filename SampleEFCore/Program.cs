// See https://aka.ms/new-console-template for more information

// Customer Create 

using Microsoft.EntityFrameworkCore;
using SampleEFCore.Databases;
using SampleEFCore.EntityModels;
using SampleEFCore.Repository;

SampleCommerceDbContext db = new SampleCommerceDbContext();

//category create 
//var category = new Category()
//{
//    Name = "Electronics",
//    Code = "ELEC",
//    Description = "Electronics Management Category"
//};

//var existingCategory = db.Categories
//                        .Include(c=>c.Products)
//                        .FirstOrDefault(c => c.Id == 2);

//foreach(var p in existingCategory.Products)
//{
//    Console.WriteLine(p.GetInfo());
//}

//// product create 

//var product = new Product()
//{
//    Name = "Apple Mac Book",
//    Code = "Mac",
//    Price = 234335   
//};

//existingCategory.Products.Add(product);

//db.Categories.Update(existingCategory);

////db.Product.Add(product);


//var product = new Product()
//{
//    Name = "Hatil Table",
//    Code = "HT",
//    Price = 8238,
//    CategoryId = 3
//};

//db.Products.Add(product);

//int successCount = db.SaveChanges();


//if (successCount > 0)
//{
//    Console.WriteLine("Operation Successful!");
//}


// LINQ 

// Language Integrate Query C# 4.0 --> C# 10+ 

// select * from products where products.Price > 9230923 AND product.Price <823938

//var products = db.Products.ToList();

//List<Product> resultProducts = new List<Product>(); 
//foreach (var item in products)
//{
//    if(item.Price>20000 && item.Price <= 50000)
//    {
//        resultProducts.Add(item);
//    }

//}

//// select Name,Price from products where products.Price > 9230923 AND product.Price <823938
//var retrieveProducts = from p in products
//                        where p.Price > 20000 && p.Price <= 50000
//                        //orderby p.Name
//                        select new {Name=p.Name, Price=p.Price, CategoryName = p.Category.Name};

//var allproduct = products;

////LINQ Method Chain/Lamda Style 
//int quantity = 5; 
//var retrieveProductLambda = products
//                            .Where(p => p.Price > 200 && p.Price <= 50000)
//                            .Select(p=> {

//                                var quantityFactor = 5 / 20;

//                                return new
//                                {
//                                    Name = p.Name,
//                                    UnitPrice = p.Price,
//                                    QuantityFactor = quantityFactor,
//                                    TotalPrice = quantity * p.Price

//                                };
                                
                            
//                            })
//                            .Where(p=> p.TotalPrice > 5000);



var productsInSampleDb = db.Products.Include(c => c.Category)
                        .Select(p => new { CategoryName = p.Category.Name, ProductName = p.Name, Price = p.Price }); 



foreach(var product in productsInSampleDb)
{
    Console.WriteLine($" Category: {product.CategoryName} Product: {product.ProductName} Price: {product.Price}");
}

var groupByProduct = productsInSampleDb
                    .GroupBy(c => c.CategoryName)
                    .Select(g => new { Category = g.Key, Products=g.ToList() }) ; 


foreach(var group in groupByProduct)
{
    Console.WriteLine($"Group: {group.Category}"); 

    foreach(var product in group.Products)
    {
        Console.WriteLine($" \t Product: {product.ProductName} Price: {product.Price}");
    }
}

// Generic Examples

//List<string> numbers = new List<string>(); 

                       


