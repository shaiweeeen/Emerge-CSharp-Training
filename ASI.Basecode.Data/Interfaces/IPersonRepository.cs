using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IPersonRepository
    {
        public IQueryable<Person> RetrieveAll();
        void CreatePerson(Person person);
        void EditPerson(Person person);
        void DeletePerson(Person person);
    }
}
