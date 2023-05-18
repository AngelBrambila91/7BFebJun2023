using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.Models;
using static System.Console;

namespace WorkingWithEFCore;

partial class Program
{
    static void OutputTableOfProducts(Product [] products, int currentPage, int totalPages)
    {
        string line = new('-', count : 73);
        string lineHalf = new('-', count : 30);
        WriteLine(line);
        WriteLine("{0,4} {1,40} {2,12} {3,-15}",
        "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);
        foreach (Product p in products)
        {
            WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}",
            p.ProductId, p.ProductName, p.Cost, p.Discontinued) ;
        }
        WriteLine("{0} Page {1} of {2} {3}",
        lineHalf, currentPage + 1, totalPages + 1, lineHalf);
    }

    static void OutputPageOfProducts (IQueryable<Product> products, int pageSize, int currentPage, int totalPages)
    {
        var pagingQuery = products.OrderBy(p => p.ProductId)
        .Skip(currentPage * pageSize)
        .Take(pageSize);
        SectionTitle(pagingQuery.ToQueryString());
        OutputTableOfProducts(pagingQuery.ToArray(), currentPage, totalPages);
    }

    static void PagingProducts()
    {
        SectionTitle("Paging products");
        using (Northwind db = new())
        {
            int pageSize = 10;
            int currentPage = 0;
            int productCount = db.Products!.Count();
            int totalPages = productCount / pageSize;
            while(true)
            {
                OutputPageOfProducts(db.Products!, pageSize, currentPage, totalPages);
                Write("Press <- to page back, press -> to page forward any key to exit");
                ConsoleKey key = ReadKey().Key;
                if(key == ConsoleKey.LeftArrow)
                {
                    if(currentPage == 0)
                    currentPage = totalPages;
                    else
                    currentPage --;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (currentPage == totalPages)
                    currentPage = 0;
                    else
                    currentPage ++;
                }
                else
                {
                    break;
                }
                WriteLine();
            }
        }
    }
}