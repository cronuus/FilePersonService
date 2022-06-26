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
        public List<string> ConvertToPerson(string[] persons)
        {
            var list = new List<string>();
            foreach (var item in persons)
            {
                list.Add(item);
            }
            return list;
        }
        public string[] Read()
        {
            string[] persons = new string[] { };
            persons = File.ReadAllLines(fileName);
            return persons;
        }
        public void Print(List<Person> people)
        {
            var list = new List<Person>();
            foreach (var person in people)
            {
                list.Add(person);
            }
        }
    }
}
