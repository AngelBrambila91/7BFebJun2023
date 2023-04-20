using System.Xml.Serialization;
using Serialization;
using static System.Envxironment;
using static System.IO.Path;
using static System.Console;
using FastJson = System.Text.Json.JsonSerializer;


#region XML
// List of persons to serialize
List<Person> people = new()
{
    new (3000M)
    {
        FirstName = "Alfred",
        LastName = "Anaya",
        DateOfBirth = new(year: 2001, month: 02, day:14)
    },

    new(5000M)
    {
        FirstName = "Minerva",
        LastName = "Rivera",
        DateOfBirth = new (year: 2000, month: 08, day: 23)
    },

    new(20000M)
    {
        FirstName = "Daniel",
        LastName = "Jimenez",
        DateOfBirth = new(year: 2003, month: 04, day:30)
    },

    new(60000M)
    {
        FirstName = "Luan",
        LastName = "Martinez",
        DateOfBirth = new(year: 2003, month: 04, day:30),
        Children =  new ()
        {
            new (0M)
            {
                FirstName = "Chong",
                LastName = "Chang",
                DateOfBirth = new(year: 2020, month: 04, day:01)
            }
        }
    }
};

// XML Serializer
XmlSerializer xs = new(type: people.GetType());
// create path File
string path = Combine(CurrentDirectory, "people.xml");
// Create FILE .. just create
using (FileStream stream = File.Create(path))
{
    // serialize this shit
    xs.Serialize(stream, people);
}

WriteLine($"Written {new FileInfo(path).Length:N0} Bytes of XML to {path}");

WriteLine(File.ReadAllText(path));
#endregion

#region JSON
string jsonPath = Combine(CurrentDirectory, "people.json");
using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();
    jss.Serialize(jsonStream, people);
}
WriteLine();
WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to :  {jsonPath} ");
WriteLine(File.ReadAllText(jsonPath));

// Deserialize
WriteLine();
WriteLine("Deserialize Json");
using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    // Deserialize The entire Object
    List<Person> loadedPeople =
    await FastJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;
    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine($"{p.LastName} has {p.Children?.Count ?? 0} children");
        }
    }
}

void Add(ref int x)
{

}
#endregion