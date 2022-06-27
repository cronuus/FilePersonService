using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService
{
    public class PersonService
    {
        private readonly string path = @"people";
        public string fileName = string.Empty;
        public PersonService()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            fileName = Path.Combine(path, "person.txt");
        }
        
         public void Create(Person person, int count)
        {
            string[] personstr = new string[4];
            for (int i = 0; i < count; i++)
            {
                personstr[0] = person.Id.ToString();
                personstr[1] = person.Name;
                personstr[2] = person.LastName;
                personstr[3] = person.Age.ToString();
                File.AppendAllLines(fileName, personstr);
            }
        }
        public List<Person> ConvertToPerson(string[] persons)

        {

            List<Person> people = new List<Person>();

            for (int i = 0; i < persons.Length; i = i + 4)
            {
                people.Add(new Person()
                {
                    Id = Guid.Parse(persons[i]),
                    Age = Convert.ToInt16(persons[i + 1]),
                    LastName = persons[i + 2],
                    Name = persons[i + 3]
                });
            }
            return people;
        }
        public string[] Read()
        {
            string[] persons = new string[] { };
            persons = File.ReadAllLines(fileName);
            return persons;
        }
        public void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id.ToString()}\n" +
                    $"AGE: {person.Age}\n" +
                    $"LAST NAME: {person.LastName}\n" +
                    $"FIRST NAME: {person.Name}\n" +
                    $"{new string('_', 15)}");
            }
        }
    }
}
