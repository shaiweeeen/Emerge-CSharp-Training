using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class CarRepository : BaseRepository, ICarRepository
    {
        private readonly AsiBasecodeDBContext asiBasecodeDBContext;
        public CarRepository(IUnitOfWork unitOfWork, AsiBasecodeDBContext asiBasecodeDBContext) : base(unitOfWork)
        {
            this.asiBasecodeDBContext = asiBasecodeDBContext;
        }
        public IQueryable<CarModel> RetrieveAll()
        {
            return this.GetDbSet<CarModel>();
        }

        public void CreateCar(CarModel carModel)
        {
            asiBasecodeDBContext.CarModel.Add(carModel);
            asiBasecodeDBContext.SaveChanges();
        }
    }
}
