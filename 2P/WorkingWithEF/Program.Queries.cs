using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.Models;
using static System.Console;
namespace WorkingWithEFCore;

partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            SectionTitle("Categories and how many products they have");
            // IQueryable
            IQueryable<Category>? categories = db.Categories;
                                                //.Include(c => c.Products);
            if((categories is null) ||  (!categories.Any()))
            {
                Fail("No categories found");
                return;
            }
            foreach (var c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products");
            }
        }
    }

    static void FilterIncludes()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products with a minimum number of units in stock");
            string? input;
            int stock;
            do
            {
                Write("Enter a mnimum units in stock :");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));
            IQueryable<Category>? categories = db.Categories?
                                                    .Include(c => c.Products.Where(p => p.Stock >= stock));
            if((categories is null) || (!categories.Any()))
            {
                Fail("No categories found");
                return;
            }
            Info($"ToQueryString : {categories.ToQueryString()}");
            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock}");
            foreach (Product product in c.Products)
            {
                WriteLine($"{product.ProductName} has {product.Stock} units in stock");
            }   
            }
        }
    }

    static void QueryingProducts()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products that cost more than a price, highest at top");
            string? input;
            decimal price;
            do
            {
                Write("Enter a product price");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));
            IQueryable<Product>? products = db.Products?
                                                .Where(p => p.Cost >= price)
                                                .OrderByDescending(p => p.Cost);
            if(products is null)
            {
                Fail("No products found");
                return;
            }
            foreach (Product p in products)
            {
                WriteLine($"{p.ProductId} : {p.ProductName} cost {p.Cost:$#,##0.00} and has {p.Stock} in stock");
            }
        }
    }
    
    //LIKE
    // %a
    static void QueryingWithLike()
    {
        using (Northwind db = new())
        {
            SectionTitle("Pattern matching with LIKE");
            Write("Enter part of the paroduct name :");
            string? input = ReadLine();
            if(string.IsNullOrWhiteSpace(input))
            {
                Fail("You did not enter part of a product name");
                return;
            }
            IQueryable<Product>? products = db.Products?
                                            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
            if((products is null) || (!products.Any()))
            {
                Fail("No products found");
                return;
            }
            foreach (Product product in products)
            {
                WriteLine($"{product.ProductName} has {product.Stock} units in stock. Discontinued? {product.Discontinued}");
            }
        }
    }
    
    static void GetRandomProduct()
    {
        using (Northwind db = new())
        {
            SectionTitle("Get a random product");
            // how many rows are on Products
            int? rowCount = db.Products?.Count();
            if(rowCount == null)
            {
                Fail("Products table is empty");
                return;
            }
            Product? p = db.Products?.FirstOrDefault(p => p.ProductId == (int) (EF.Functions.Random() * rowCount));
            if(p == null)
            {
                Fail("Product not found");
                return;
            }
            WriteLine($"Random product : {p.ProductId} {p.ProductName}");
        }
    }
}