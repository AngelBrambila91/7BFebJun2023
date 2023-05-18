using static System.Console;
#region While
int x = 0;
while (x < 11)
{
    WriteLine(x);
    x++;
}
#endregion

#region Do While
string? password = String.Empty;
do
{
    Write("Enter your password : ");
    var input = ReadLine();
} while (password == "Pa$$w0rd");
WriteLine("Correct!");
#endregion

#region For
for (int i = 0; i < 11; i++)
{
    WriteLine(i);
}
#endregion

#region For each
// Only works in Collections
// Arrays, Lists, Dicts, Set, Map
// foreach (var in List ) .next != null
List<int> numbers = new();
numbers.Add(1);
numbers.Add(10);
numbers.Add(4);
numbers.Add(667);
numbers.Add(-2);

foreach (int number in numbers)
{
    WriteLine(number);
}
#endregion