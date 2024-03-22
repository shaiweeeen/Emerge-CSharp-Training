using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IPersonService
    {
        public List<Person> RetrieveAll();
        public void CreatePerson(Person personModel);
        public Person GetPerson(string id);
        public void EditPerson(Person personModel);
        public void DeletePerson(Person person);
    }
}
