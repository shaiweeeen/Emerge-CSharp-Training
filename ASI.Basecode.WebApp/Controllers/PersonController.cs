using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace ASI.Basecode.WebApp.Controllers
{
    public class PersonController : ControllerBase<PersonController>
    {
        private readonly IPersonService _personService;
        private readonly IConfiguration _appConfiguration;
        public PersonController(
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IMapper mapper,
            IPersonService personService) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {

            this._appConfiguration = configuration;
            _personService = personService;
        }
        [Authorize]
        // GET: PersonController
        public ActionResult Index()
        {
            var list = _personService.RetrieveAll();
            return View(list);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(string id)
        {
            var personModel = _personService.GetPerson(id);
            return View(personModel);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                var newPerson = new Person
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = person.Name,
                    Address = person.Address,
                    Age = person.Age
                };

                _personService.CreatePerson(newPerson);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(string id)
        {
            var personModel = _personService.GetPerson(id);
            return View(personModel);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Person model)
        {
            try
            {
                var person = _personService.GetPerson(id);

                person.Name = model.Name;
                person.Address = model.Address;
                person.Age = model.Age;

                _personService.EditPerson(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(string id)
        {
            var person = _personService.GetPerson(id);
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string id)
        {
            
                try
                {
                    var person = _personService.GetPerson(id);
                    _personService.DeletePerson(person);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
           
            
     
        }
    }
}
