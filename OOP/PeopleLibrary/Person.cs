using System.Collections.Generic;
namespace PeopleLibrary
{
    public class Person
    {
        // Fields
        public string? Name;
        // private can be onlye accessed by class itself
        // protected also as private and also inherited classes
        // Properties
        public string? SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public FavoriteFood favoriteFood;
        // net 6 new()
        public List<Person> Children;
        public static string? PlaceHolder;

        // Constants
        public const string HomePlanet = "Earth";
        // Read only
        public readonly string Species = "Homo Sapiens";
        // Methods
        public string? getSurName()
        {
            return SurName;
        }
        public void setSurname(string surname)
        {
            SurName = surname;
        }

        // Tuples
        // Tuple<int, string>
        public (int grade, string name) GetGrades()
        {
            return (grade: 80, name: $"{Name}");
        }

        // Constructor
        // Must be named the same name of the file
        public Person()
        {

        }

        public Person(string firstName)
        {
            Name = firstName;
            Children = new();
        }

        public Person(string firstName, string surName, string species)
        {
            Name = firstName;
            SurName = surName;
            Species = species;
        }
    }
}