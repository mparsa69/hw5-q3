using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_q3
{
    public class PersonRepository:IPersonRepository
    {

        public void DeletePerson(string name)
        {
            var p = DataSource._person.FirstOrDefault(x => x.Name == name);
            if (p != null)
            {
                DataSource._person.RemoveAll(x => x.Name == name);
                Console.WriteLine($"{p.Name} {p.Family} Removed");
            }
            else
            {
                Console.WriteLine("There is No Person Like this ");
            }
        }

        public void FindPerson(string name)
        {
            var p = DataSource._person.FirstOrDefault(n => n.Name == name);
            if (p != null)
            {
                Console.WriteLine($"{p.Name} {p.Family} Founded");
            }
            else
            {
                Console.WriteLine("Person Not Found");
            }
        }

        public IList<Person> GetAll()
        {
            return DataSource._person.ToList();
        }

        public void InsertPerson(Person person)
        {
            DataSource._person.Add(person);
        }

        public void UpdatePerson(string name, string newName, string newFamily)
        {
            var p = DataSource._person.FirstOrDefault(x => x.Name == name);
            if (p != null)
            {
                Console.WriteLine($"{p.Name} {p.Family} Modified To :{newName} {newFamily} ");
                p.Name = newName;
                p.Family = newFamily;


            }
            else
            {

            }
        }


    }
}
