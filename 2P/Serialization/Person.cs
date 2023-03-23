
using System.Xml.Serialization;
namespace Serialization;


public class Person
{
    [XmlAttribute("Salary")]
    public decimal Salary { get; set; }
    [XmlAttribute("FName")]
    public string? FirstName { get; set; }
    [XmlAttribute("LName")]
    public string? LastName { get; set; }
    [XmlAttribute("DoB")]
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person>? Children { get; set; }
    public Person()
    {
    }
    public Person(decimal initialSalary)
    {
        Salary = initialSalary;
    }

}