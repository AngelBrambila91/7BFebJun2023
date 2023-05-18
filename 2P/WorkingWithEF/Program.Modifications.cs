using WorkingWithEFCore.Models;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WorkingWithEFCore;

partial class Program
{
    static void ListProducts(int? [] productIdToHighlight = null)
    {
        using(Northwind db = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Cost", "Stock", "Disc.");
            foreach (Product p in db.Products)
            {
                ConsoleColor previousColor = ForegroundColor;
                if((productIdToHighlight is not null) && (productIdToHighlight.Contains(p.ProductId)))
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4}",
                p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
                ForegroundColor = previousColor;
            }
        }
    }

    static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using (Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };

            EntityEntry<Product> entity = db.Products.Add(p);
            int affected =db.SaveChanges();
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
            return (affected, p.ProductId);
        }
    }

    static (int affected, int productId) IncreaseProductPrice (string ProductNameStartsWith, decimal amount)
    {
        using (Northwind db = new())
        {
            if(db.Products is null) return (0,0);

            Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(ProductNameStartsWith));
            updateProduct.Cost += amount;
            int affected = db.SaveChanges();
            return (affected, updateProduct.ProductId);
        }
    }

    static int DeleteProducts(string productNameStartsWith)
    {
        using (Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where(p => p.ProductName.StartsWith(productNameStartsWith));
            if((products is null) || (!products.Any()))
            {
                WriteLine("No products were found to delete");
                return 0;
            }
            else
            {
                if(db.Products is null) return 0;
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }

}