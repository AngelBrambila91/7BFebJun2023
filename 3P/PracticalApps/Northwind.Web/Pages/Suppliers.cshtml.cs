using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // RedirectPage("/Suppliers")
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

    [BindProperty]
    public Supplier? Supplier { get; set; }
    public IActionResult OnPost()
    {
        if ((Supplier is not null) && ModelState.IsValid)
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page();
        }
    }
}