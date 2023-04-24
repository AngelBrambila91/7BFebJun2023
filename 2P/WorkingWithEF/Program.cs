using WorkingWithEFCore;
using static System.Console;
namespace WorkingWithEFCore;

partial class Program
{
    private static void Main(string[] args)
    {
        // Northwind db = new();
        // WriteLine($"Data Provider = {db.Database.ProviderName}");
        QueryingCategories();
    }
}