using static System.Console;
using static System.Convert;

// Implicit Conversion
int a = 10;
double b = a;

double c = 9.8;
// Explicit Conversion
// (type of variable to convert) variable to convert
int d = (int)c;
WriteLine(b);
WriteLine(d);

#region Long to int
    long e = 10;
    int f = (int) e;
    WriteLine(f);
    e =  long.MaxValue;
    f = (int) e;
    WriteLine($"e is {e:N0}");
    WriteLine($"f is  {f:N0}");
    e = 5_000_000_000; // 64 Bit
    f = (int) e; // 32 Bit
    WriteLine(f);
#endregion

#region Convert
    double g = 5.6;
    int h = ToInt32(g);
    WriteLine($"g is {g} , h is {h}");

    double [] numbers = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51, 10.50 };
    // foreach ( var number in numbers)
    // {
    //     WriteLine($"ToInt32 {number} is {ToInt32(number)}");
    // }

    // foreach (var number in numbers)
    // {
    //     WriteLine(format: "Math.Round({0}) \t Math.MidPoint({1}) \t Math.AwayFromZero({2})",
    //     arg0: Math.Round(number),
    //     arg1: Math.Round(number, 0, MidpointRounding.AwayFromZero),
    //     arg2: Math.Round(number, 0, MidpointRounding.ToEven));
    // }
#endregion

#region from primitive ToString
    int number = 1;
    WriteLine(number.ToString());
    bool isTrue = true;
    WriteLine(isTrue.ToString());
    object o = new ();
    WriteLine(o.ToString());
#endregion

#region from String to Primitive
    byte [] binaryObject = new byte [128];
    Random.Shared.NextBytes(binaryObject);
    for (int index = 0; index < binaryObject.Length; index++)
    {
        WriteLine($"Binary Object [{index}] : {binaryObject[index]}");
    }
    WriteLine();

    string encoded = ToBase64String(binaryObject);
    WriteLine($"Encoded bytes are: {encoded}");
#endregion

#region Parse
// RunTime
    int age = int.Parse("27");
    WriteLine(age);
    DateTime birthday = DateTime.Parse("December 10 2003");
    WriteLine($"Luis was born on {age} years ago");
    WriteLine($"Luis Birthday is {birthday}");
    WriteLine($"Luis Birthday is {birthday:D}");
#endregion

#region TryParse
    Write("How old are you?");
    string? input = ReadLine();
    if(int.TryParse(input, out int count))
    {
        WriteLine($"I'm too old for this shit {count}");
    }
    else
    {
        WriteLine("I couldn't convert this shit");
    }
#endregion