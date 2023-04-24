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
            IQueryable<Category> categories = db.Categories;
            foreach (var c in categories)
            {
                WriteLine($"{c.CategoryName}");
            }
        }
    }
}