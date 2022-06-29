using System;
using System.Collections.Generic;
using System.IO;
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
            path = Path.Combine(path, "person.txt");
        }
        public void Create(Person person, int count)
        {
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                byte[] buffer;
                for (int i = 0; i < count; i++)
                {
                    buffer = Encoding.Default.GetBytes(person.Id.ToString() + "\n"
                        + person.Age.ToString() + "\n"
                        + person.LastName + "\n"
                        + person.Name + "\n");
                    fstream.Write(buffer, 0, buffer.Length);
                }
            }
        }
        public List<Person> ConvertToPerson(string[] persons)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < persons.Length; i = i + 4)
            {
                try
                {
                    people.Add(new Person()
                    {
                        Id = Guid.Parse(persons[i]),
                        Age = Convert.ToInt16(persons[i + 1]),
                        LastName = persons[i + 2],
                        Name = persons[i + 3]
                    });
                }
                catch(Exception ex)
                {

                }
            }
            return people;
        }
        public string[] Read()
        {
            string[] persons;
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                persons = textFromFile.Split('\n');
            }
            return persons;
        }
        public void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(
                    $"Firstname:{person.Name}\n" +
                    $"LastName:{person.LastName}\n" +
                    $"Age:{person.Age}\n" +
                    $"ID: {person.Id.ToString()}\n" +
                    $"{new string('_', 15)}"

                    );
            }
        }
    }
}
