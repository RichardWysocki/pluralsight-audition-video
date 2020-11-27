using Business.Shared.CarExample;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Customer.Blazor.Server.UI.Lamar.Pages
{
    public partial class CarList
    {
        [Inject]
        public ICarRepository _carRepository { get; set; }

        public List<Car> cars { get; set; }

        protected override void OnInitialized()
        {
            cars = _carRepository.GetCars();
        }
    }
}
