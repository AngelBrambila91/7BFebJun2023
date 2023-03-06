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
        // Methods
        public string? getSurName()
        {
            return SurName;
        }
        public void setSurname(string surname)
        {
            SurName = surname;
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

        public Person(string firstName, string surName = "N/A")
        {

        }
    }
}