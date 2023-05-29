using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
public IEnumerable<string>? Suppliers { get; set; }
public void OnGet()
{
    ViewData["Title"] = "Raspados - Suppliers";
    Suppliers = new[]
    {
        "MiAlegria", "La suerga", "Abuelita Tota"
    };
}
}