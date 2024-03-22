using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> RetrieveAll()
        {
            //var list = new List<CarModel>();
            return _personRepository.RetrieveAll().ToList();
        }

        public void CreatePerson(Person personModel)
        {

            _personRepository.CreatePerson(personModel);
            //var list = new List<CarModel>();
            //return _carRepository.RetrieveAll().ToList();
        }

        public Person GetPerson(string id)
        {
            var person = _personRepository.RetrieveAll().Where(person => person.Id == id).FirstOrDefault();
            return person;
        }

        public void EditPerson(Person personModel)
        {
            _personRepository.EditPerson(personModel);
        }

        public void DeletePerson(Person person)
        {
            _personRepository.DeletePerson(person);
        }
    }
}
