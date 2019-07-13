using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public interface ICarRepo
    {
        IEnumerable<Car> GetCars();
        Car GetCar(int carId);

        void AddCar(Car car);
        void EditCar(Car car);
        void DeleteCar(Car car);
        int GetNewCarId();
    }
}
