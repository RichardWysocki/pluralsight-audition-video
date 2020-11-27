using System.Collections.Generic;
using System.Linq;

namespace Business.Shared.CarExample
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarDataAccess _carDataAccess;

        public CarRepository(ICarDataAccess carDataAccess)
        {
            _carDataAccess = carDataAccess;
        }

        public List<Car> GetCars()
        {
            //var cars = _carDataAccess.LoadJson().listings;
            var response = _carDataAccess.GetCars().OrderBy(c => c.Make).ToList();
            return response;
        }



    }
}