using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Database;

namespace CarDealer.Models
{
    public class CarRepo : ICarRepo
    {
        private readonly DatabaseContext _databaseContext;

        public CarRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Car GetCar(int carId)
        {
            return _databaseContext.Cars.FirstOrDefault(s => s.Id == carId);
        }

        public IEnumerable<Car> GetCars()
        {
            var temp = _databaseContext.Cars.OrderBy(x=>x.Title).ToList();
            return temp;
        }

        public void AddCar(Car car)
        {
            _databaseContext.Cars.Add(car);
            _databaseContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _databaseContext.Cars.Remove(car);
            _databaseContext.SaveChanges();
        }

        public void EditCar(Car car)
        {
            _databaseContext.Cars.Update(car);
            _databaseContext.SaveChanges();
        }

        public int GetNewCarId()
        {
            if (_databaseContext.Cars.Any())
            {
                return _databaseContext.Cars.Max(x => x.Id) + 1;
            }
            else
            {
                return 1;
            }
            
        }
    }
}
