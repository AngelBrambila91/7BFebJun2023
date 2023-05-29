using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Shared;

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
private NorthwindContext db;
public SuppliersModel(NorthwindContext injectedContext)
{
    db = injectedContext;
}
public IEnumerable<Supplier>? Suppliers { get; set; }
public void OnGet()
{
    ViewData["Title"] = "Raspados - Suppliers";
    Suppliers = db.Suppliers.OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
}
}