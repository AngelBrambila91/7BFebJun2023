using static System.Console;

#region Try Catch
    
WriteLine("Before Parsing");
Write("What is your age?");
string input = ReadLine();

try
{
    int age = int.Parse(input);
    WriteLine($"You are {age} years old");
}
catch( FileNotFoundException fnfe)
{

}
catch (FormatException fe)
{
    WriteLine("I can't format the input your provide");
}
catch (Exception ex)
{
    WriteLine("You should only enter numbers please...");
    // Logging
    WriteLine($"The exception is : {ex.Message} and is type {ex.GetType()}");
}
WriteLine("After Try");
#endregion

#region checked and unchecked
try
{
    checked
    {
    int x = int.MaxValue;
    WriteLine($"Initial value is {x}");
    x++;
    WriteLine($"Value is {x}");
    x++;
    WriteLine($"Value is {x}");
    x++;
    }
}
catch (System.OverflowException)
{
    WriteLine("Whoops, overflow");
}
#endregion