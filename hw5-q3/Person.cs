using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_q3
{
    public class Person
    {
        private static int userId = 100;
        public int Id { get; set; } 
        public int NationalId { get; set; } 
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Address { get; set; }

        public static Faker<Person> FakeData { get; } =
            new Faker<Person>()
                .RuleFor(p => p.Id, f => userId++)
                .RuleFor(p => p.NationalId, f => f.Random.Number(10000, 50000))
                .RuleFor(p => p.Name, f => f.Name.FirstName())
                .RuleFor(p => p.Family, f => f.Name.LastName())
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.Age, f => f.Random.Number(1,70))                               
                .RuleFor(p => p.BirthDate, f => f.Date.Past(18));
    }
}
