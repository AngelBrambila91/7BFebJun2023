using PeopleLibrary;
using static System.Console;

Person dante = new Person();
dante.Name = "Dante";
dante.SurName = "Cruz";
Person luis = new Person("Luis");
luis.favoriteFood = FavoriteFood.Mole;
WriteLine($"Hello {dante.Name}");
WriteLine($"Val of Mole is {(int)FavoriteFood.Mole}");
WriteLine($"Hi {luis.Name} : your favorite food is {luis.favoriteFood}");
Person cristian = new("Cristian");
cristian.Children.Add(
    new Person // Implicit Instance
    {
        Name = "Christian",
        SurName = "Con H",
        DateOfBirth = new DateTime(2002, 12, 19)
    }
);

foreach (var item in cristian.Children)
{
    WriteLine($"Name of children {item.Name}");
}

BankAccount danielAccount = new BankAccount();
danielAccount.AccountName = "Daniel Jimenez";
danielAccount.Balance = 1000M;


WriteLine($"{dante.Species}");
Person Luan = new("Luan", "Esteban", "Reptile");
WriteLine($"Luan Species is : {Luan.Species}");

// Explicit Return
(int grade, string name) grade = Luan.GetGrades();
// easy AF\
var grade2 = Luan.GetGrades();
WriteLine($"{grade.name} has a score of : {grade.grade}");