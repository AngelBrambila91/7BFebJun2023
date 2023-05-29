using Northwind.Shared;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// Add Northwind as a service
builder.Services.AddNorthwindContext();
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure for using Static pages
app.UseDefaultFiles();
app.UseStaticFiles();
// Configure to use Razor Pages
app.MapRazorPages();

// GET
app.MapGet("/hello", () => "Hello World!");

app.MapGet("/Raspados", () => "Que ricos Son"); // return "Que ricos son"

app.Run();
