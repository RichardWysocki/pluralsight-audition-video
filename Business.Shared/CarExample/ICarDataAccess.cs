

using System.Collections.Generic;

namespace Business.Shared.CarExample
{
    public interface ICarDataAccess
    {
        List<Car> GetCars();
    }
}