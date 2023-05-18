using static System.Console;
using SelectionStatements;
#region If
string password = "veggie";
if (password.Length < 8)// Expression
{
    WriteLine("Your password is too short.");
}
else
{
    WriteLine("Your password is strong.");
}
#endregion

#region Pattern Match with if
object o = 3;
int j = 4;
if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so i can't multiply them.");
}
#endregion

#region Switch
    int number = Random.Shared.Next(1,7);
    WriteLine($"My random number is {number}");
    switch (number)
    {
        case 1:
        WriteLine("One");
        break;
        
        case 2:
        WriteLine("Two");
        goto case 1;// Spaghetti Code

        case 3:
        case 4:
        WriteLine("Three or Four");
        goto case 1;

        case 5:
        WriteLine("Five");
        goto A_Label;
    }
        A_Label:
        WriteLine("A Label ... D:");
#endregion

#region Pattern Matching Swtich
    Animal?[] animals = new Animal[]
    {
        new Cat
        {
            Name = "Karen",
            Born = new(year:2022, month: 02, day: 14),
            Legs = 4,
            Lives = 7,
            IsDomestic = true
        },
        new Spider
        {
            Name = "Tu Ex",
            Born = DateTime.Today,
            IsPoisonous = true,
        },
        new Animal
        {
            Name = "Tiger",
            Born = DateTime.Today,
            Legs = 4
        }
    };

    foreach (var animal in animals)
    {
        string message = String.Empty;
        switch(animal)
        {
            case Cat elHijoDeKaren when elHijoDeKaren.Legs == 4:
            message = $"The cat named {elHijoDeKaren.Name} has four legs";
            break;

            case Cat wildCat when wildCat.IsDomestic == false:
            message = $"The cat named {wildCat.Name} is not domestic";
            break;

            case Cat:
            message = $"It's a plain, boring , stupid cat";
            break;

            default:
            message = $"Another unknown animal";
            break;
        }
        WriteLine(message);
    }
#endregion