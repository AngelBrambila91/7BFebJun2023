using WorkingWithEFCore;

Northwind db = new();
Console.WriteLine($"Data Provider = {db.Database.ProviderName}");