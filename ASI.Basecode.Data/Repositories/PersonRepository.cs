using ASI.Basecode.Data.Interfaces;
//using ASI.Basecode.Data.Migrations;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        private readonly AsiBasecodeDBContext asiBasecodeDBContext;
        public PersonRepository(IUnitOfWork unitOfWork, AsiBasecodeDBContext asiBasecodeDBContext) : base(unitOfWork)
        {
            this.asiBasecodeDBContext = asiBasecodeDBContext;
        }
        public void CreatePerson(Person person)
        {
            asiBasecodeDBContext.PersonModel.Add(person);
            asiBasecodeDBContext.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            asiBasecodeDBContext.PersonModel.Remove(person);
            asiBasecodeDBContext.SaveChanges();
        }

        public void EditPerson(Person person)
        {
            asiBasecodeDBContext.PersonModel.Update(person);
            asiBasecodeDBContext.SaveChanges();
        }

        public IQueryable<Person> RetrieveAll()
        {
            return this.GetDbSet<Person>();
        }
    }
}
