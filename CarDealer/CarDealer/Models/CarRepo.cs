using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDBContext _appDBContext;

        public CarRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Car GetCar(int carId)
        {
            return _appDBContext.Cars.FirstOrDefault(s => s.Id == carId);
        }

        public IEnumerable<Car> GetCars()
        {
            return _appDBContext.Cars;
        }

        public void AddCar(Car car)
        {
            _appDBContext.Cars.Add(car);
            _appDBContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _appDBContext.Cars.Remove(car);
            _appDBContext.SaveChanges();
        }

        public void EditCar(Car car)
        {
            _appDBContext.Cars.Update(car);
            _appDBContext.SaveChanges();
        }
    }
}
