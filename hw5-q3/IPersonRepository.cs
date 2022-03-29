using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_q3
{
    public interface IPersonRepository
    {
        void InsertPerson(Person person);
        IList<Person> GetAll();
        public void FindPerson(string name);
        public void DeletePerson(string name);
        void UpdatePerson(string name, string newName, string newFamily);
    }
}
