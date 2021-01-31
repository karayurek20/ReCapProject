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
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> { new Car { Id = 1, BrandId = "BMW", ColorId = "Kırmızı", DailyPrice = 350, ModelYear = 2014, Description = "Kırmızı BMW" },
                new Car { Id = 1, BrandId = "Mercedes", ColorId = "Beyaz", DailyPrice = 500, ModelYear = 2017, Description = "Beyaz Mercedes" },
                new Car { Id = 2, BrandId = "Ford", ColorId = "Mavi", DailyPrice = 250, ModelYear = 2013, Description = "Mavi Ford" },
                new Car { Id = 3, BrandId = "Opel", ColorId = "Kırmızı", DailyPrice = 350, ModelYear = 2014, Description = "Kırmızı Opel" },
                new Car { Id = 4, BrandId = "Volvo", ColorId = "Gri", DailyPrice = 750, ModelYear = 2020, Description = "Gri Volvo" },
                new Car { Id = 5, BrandId = "Toyota", ColorId = "Bej", DailyPrice = 350, ModelYear = 2016, Description = "Bej Toyota" },
            };
            
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Delete(Car car)
        {
           var deleteToCar= _car.SingleOrDefault(c => c.BrandId == car.BrandId);
            _car.Remove(deleteToCar);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            var uptadeToCar = _car.SingleOrDefault(c => c.BrandId == car.BrandId);
            uptadeToCar.BrandId = car.BrandId;
            uptadeToCar.ColorId = car.ColorId;
            uptadeToCar.DailyPrice = car.DailyPrice;
            uptadeToCar.Description = car.Description;
            uptadeToCar.Id = car.Id;
            uptadeToCar.ModelYear = car.ModelYear;
        }
    }
}
