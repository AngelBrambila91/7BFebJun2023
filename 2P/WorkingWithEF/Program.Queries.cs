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
    
    static void JoinCategoriesAndProducts()
    {
        SectionTitle("Join categories and Products");
        using(Northwind db = new())
        {
            // Join every product to list of categories
            var queryJoin = db.Categories!.Join(
                inner: db.Products!,
                outerKeySelector: category => category.CategoryId, // ON Categories.Id = Products.Id
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId}
            );

            foreach(var item in queryJoin)
            {
                WriteLine($"{item.ProductId} {item.ProductName} {item.CategoryName}");
            }
        }
    }

    static void GroupJoinCategoriesAndproducts()
    {
        using(Northwind db = new ())
        {
            var queryGroup = db.Categories?.AsEnumerable().GroupJoin(
                inner: db.Products!,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c, matchingProducts) => new {
                    c.CategoryName,
                    Products = matchingProducts.OrderBy(p => p.ProductName)
                }
            );

            foreach (var category in queryGroup!)
            {
                WriteLine($"{category.CategoryName} {category.Products.Count()}");
                foreach (var product in category.Products)
                {
                    WriteLine($" {product.ProductName}");
                }
            }
        }
    }

    static void AggregateProducts()
    {
        SectionTitle("Aggegate Products");
        using(Northwind db = new())
        {
            // Try to get an efficient Count of Products ...
            // db Set??
            if(db.Products!.TryGetNonEnumeratedCount(out int CountDBSet))
            {
                WriteLine("{0, -25} {1, 10}",
                arg0: "Product count from DbSet: ",
                arg1: CountDBSet);
            }
            else
            {
                WriteLine("Products DBset does not have Count property");
            }
            // Another form of Count is from List<T>
            List<Product> products = db.Products!.ToList();
            if(products.TryGetNonEnumeratedCount(out int countList))
            {
                WriteLine("{0, -25} {1, 10}",
                arg0: "Product count from List: ",
                arg1: countList);
            }
            else
            {
                WriteLine("Products List does not have Count property");
            }
                WriteLine("{0, -25} {1, 10}",
                arg0: "Products count: ",
                arg1: products.Count());

                WriteLine("{0, -27} {1, 8}",
                arg0: "Discontinued Product count: ",
                arg1: products.Count(product => product.Discontinued));

                WriteLine("{0, -25} {1,10:$#,##0.00}",
                arg0: "Highest product price:",
                arg1: db.Products!.Max(p => p.Cost));

                WriteLine("{0, -25} {1,10:N0}",
                arg0: "Sum of units in stock:",
                arg1: db.Products!.Sum(p => p.Stock));

                WriteLine("{0, -25} {1,10:$#,##0.00}",
                arg0: "Average unit Price:",
                arg1: db.Products!.Average(p => p.Cost));

                WriteLine("{0, -25} {1,10:$#,##0.00}",
                arg0: "Value of units in stocks:",
                arg1: db.Products!.Sum(p => p.Cost * p.Stock));
        }
    }
}