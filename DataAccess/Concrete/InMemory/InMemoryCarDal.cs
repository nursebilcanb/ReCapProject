using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
              new Car{CarId=1,BrandId=1,ColorId=1,ModelYear="1974",DailyPrice=1250,Description="Enjoy your trip!"},
              new Car{CarId=2,BrandId=1,ColorId=5,ModelYear="2001",DailyPrice=800,Description="Enjoy your trip!"},
              new Car{CarId=3,BrandId=2,ColorId=1,ModelYear="1998",DailyPrice=750,Description="Enjoy your trip!"},
              new Car{CarId=4,BrandId=3,ColorId=4,ModelYear="2001",DailyPrice=900,Description="Enjoy your trip!"},
            };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
