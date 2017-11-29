using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public Person(string aName, int anId, int anAge)
        {
            Name = aName;
            Id = anId;
            Age = anAge;
        }
    }
}
