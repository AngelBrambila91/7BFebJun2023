namespace WorkingWithEFCore.Models;

public class Category 
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    // Navigation property
    public virtual ICollection<Product> Products { get; set; }
}