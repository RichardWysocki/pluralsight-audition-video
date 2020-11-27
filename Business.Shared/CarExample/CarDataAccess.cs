using System.Collections.Generic;

namespace Business.Shared.CarExample
{
    public class CarDataAccess : ICarDataAccess
    {
        private readonly string _country;

        public CarDataAccess(string country)
        {
            this._country = country;
        }

        public List<Car> GetCars()
        {
            List<Car> response;
            switch (_country)
            {
                case "US":
                    
                    response = new List<Car>()
                    {
                        new Car() {Brand = "Ford", Make = "Mustang", Model = "EcoBoost FastBack", },
                        new Car() {Brand = "Ford", Make = "Mustang", Model = "GT FastBack", },
                        new Car() {Brand = "Ford", Make = "Mustang", Model = "Shelby GT350", },
                        new Car() {Brand = "Chevrolet", Make = "Equinox", Model = "LS", },
                       new Car() {Brand = "Chevrolet", Make = "Equinox", Model = "LT", },
                       new Car() {Brand = "Chevrolet", Make = "Malibu", Model = "LS", },
                       new Car() {Brand = "Chevrolet", Make = "Malibu", Model = "LT", },
                       new Car() {Brand = "Chevrolet", Make = "Malibu", Model = "Premier", },
                       new Car() {Brand = "Chrysler", Make = "Pacifica", Model = "Touring", },
                       new Car() {Brand = "Chrysler", Make = "Pacifica", Model = "Touring L", }
                    };
                    break;
                case "Europe":
                     response = new List<Car>()
                    {
                        new Car() {Model = "BMW", Make = "i3"},
                        new Car() {Model = "BMW", Make = "M2"},
                        new Car() {Model = "BMW", Make = "M3"},
                        new Car() {Model = "BMW", Make = "X14"},
                        new Car() {Model = "Hyundai", Make = "Accent"},
                        new Car() {Model = "Hyundai", Make = "Elantra"},
                        new Car() {Model = "Hyundai", Make = "Kona"},
                        new Car() {Model = "Honda", Make = "Civic"},
                        new Car() {Model = "Honda", Make = "Odyssey"},
                        new Car() {Model = "Honda", Make = "Pilot"}
                    };
                    break;
                default:
                    response =  new List<Car>();
                    break;
            }

            return response;
        }
    }
}
