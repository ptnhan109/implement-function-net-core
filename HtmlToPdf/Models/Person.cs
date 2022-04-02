using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlToPdf.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DoB { get; set; }
        public static List<Person> GetData() => new List<Person>()
        {
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                DoB = new DateTime(1990,10,12),
                Name = "Frank"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                DoB = new DateTime(1990,10,12),
                Name = "Fiona"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                DoB = new DateTime(1990,10,12),
                Name = "Lip"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                DoB = new DateTime(1990,10,12),
                Name = "Ian"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                DoB = new DateTime(1990,10,12),
                Name = "Deb"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 16,
                DoB = new DateTime(2004,10,12),
                Name = "Card"
            }
        };
    }
}
