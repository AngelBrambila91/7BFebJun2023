using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.Models;
using static System.Console;

namespace WorkingWithEFCore;

public class Northwind : DbContext
{
    // DBSets
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        string connection = $"Filename={path}";
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection : {connection}");
        ForegroundColor = previousColor;
        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

        if(Database.ProviderName?.Contains("Sqlite")  ?? false)
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        } 
    }
}