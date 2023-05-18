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
        //JoinCategoriesAndProducts();
        //GroupJoinCategoriesAndproducts();
        //AggregateProducts();
        //PagingProducts();
        //ListProducts();

        #region Insert
            // var resultAdd = AddProduct(categoryId: 6, productName:"Mazapan Tia Rosa", price:10M);
            // if(resultAdd.affected == 1)
            // {
            //     WriteLine($"Added product successful with ID {resultAdd.productId}.");
            // }
            // ListProducts(productIdToHighlight: new int?[] {resultAdd.productId});
        #endregion

        #region Update Price
            var resultUpdate = IncreaseProductPrice(ProductNameStartsWith: "Maz", amount: 20M);
            if(resultUpdate.affected == 1)
            {
                WriteLine($"Increase price successful for ID : {resultUpdate.productId}");
            }
            ListProducts(productIdToHighlight: new int?[] {resultUpdate.productId});
        #endregion


        #region Delete
            WriteLine("About to delete all products whose name starts with Lou");
            Write("Please Enter to continue or any other to exit.");
            if(ReadKey(intercept: true).Key == ConsoleKey.Enter)
            {
                int deleted = DeleteProducts(productNameStartsWith: "Maz");
                WriteLine($"{deleted} product(s) were deleted");
            }
            else
            {
                WriteLine("DeleteProducts was canceled");
            }
            ListProducts();
        #endregion

        //Eager Loading : Load data early
        //Lazy Loading : Load data just before it is needed
        //Explicit Loading : Load Data manually
    }
}