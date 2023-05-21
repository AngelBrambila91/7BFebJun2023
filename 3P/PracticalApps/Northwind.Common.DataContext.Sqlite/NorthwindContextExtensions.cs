using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
namespace Northwind.Shared;

public static class NorthwindContextExtensions
{
    public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");
        services.AddDbContext<NorthwindContext> (options => 
        {
            options.UseSqlite($"Data Source={databasePath}");
            options.LogTo(WriteLine,
                            new[] {Microsoft.EntityFrameworkCore
                                    .Diagnostics.RelationalEventId
                                    .CommandExecuting});
        });
        return services;
    }
}