using System.Collections.Generic;

namespace Business.Shared.CarExample
{
    public interface ICarRepository
    {
        List<Car> GetCars();
    }
}
