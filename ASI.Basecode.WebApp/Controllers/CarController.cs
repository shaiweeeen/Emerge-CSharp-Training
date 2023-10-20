using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASI.Basecode.WebApp.Controllers
{
    public class CarController : ControllerBase<CarController>
    {
        private readonly ICarService _carService;
        private readonly IConfiguration _appConfiguration;
        public CarController(
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IMapper mapper,
            ICarService carService) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {

            this._appConfiguration = configuration;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _carService.RetrieveAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateCar(CarModel carModel)
        {
            _carService.CreateCar(carModel);

            return RedirectToAction("Index", "Car");
        }


    }
}
