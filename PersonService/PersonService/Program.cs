using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersonService personService = new PersonService();
            Random rnd = new Random();
            personService.Create(new Person()
            {
                Name = "Valod",
                LastName = "Valodyan",
                Age = rnd.Next(10, 80)
            }, 50);
            string[] arr = File.ReadAllLines(personService.fileName);
            personService.ConvertToPerson(arr);
            personService.Read();
            var people = new List<Person>();
            object[] persons = people.ToArray();
            persons = File.ReadAllLines(personService.fileName);
            personService.Print(persons);
        }
    }
}
