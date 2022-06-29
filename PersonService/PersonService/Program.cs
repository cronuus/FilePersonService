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
            List<Person> people = new List<Person>();
            Random rnd = new Random();
            personService.Create(new Person()
            {
                Name = "Firstame",
                LastName = "Lastname",
                Age = rnd.Next(10, 80)
            }, 50);
            people = personService.ConvertToPerson(personService.Read());
            personService.Print(people);
        }
    }
}
