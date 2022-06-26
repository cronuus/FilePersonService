using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid Id { get; set; }
    }
}
