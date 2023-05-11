using WorkingWithEFCore;
using static System.Console;
namespace WorkingWithEFCore;

partial class Program
{
    private static void Main(string[] args)
    {
        // Northwind db = new();
        // WriteLine($"Data Provider = {db.Database.ProviderName}");
        //QueryingCategories();
        //FilterIncludes();
        //QueryingProducts();
        //QueryingWithLike();
        //GetRandomProduct();
        JoinCategoriesAndProducts();
        GroupJoinCategoriesAndproducts();

        //Eager Loading : Load data early
        //Lazy Loading : Load data just before it is needed
        //Explicit Loading : Load Data manually
    }
}