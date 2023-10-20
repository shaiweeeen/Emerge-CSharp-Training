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
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)  
        {
            _carRepository = carRepository;
        }

        public List<CarModel> RetrieveAll()
        {
            //var list = new List<CarModel>();
            return _carRepository.RetrieveAll().ToList();
        }

        public void CreateCar(CarModel carModel)
        {
            var count = RetrieveAll().Count();
            _carRepository.CreateCar(carModel);
            //var list = new List<CarModel>();
            //return _carRepository.RetrieveAll().ToList();
        }

    }
}
