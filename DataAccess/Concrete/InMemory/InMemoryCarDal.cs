using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> { new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 350, ModelYear =" 2014", Descriptions = "Kırmızı BMW" },
               new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 350, ModelYear =" 2014", Descriptions = "Kırmızı BMW" }
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var uptadeToCar = _car.SingleOrDefault(c => c.BrandId == car.BrandId);
            uptadeToCar.BrandId = car.BrandId;
            uptadeToCar.ColorId = car.ColorId;
            uptadeToCar.DailyPrice = car.DailyPrice;
            uptadeToCar.Descriptions = car.Descriptions;
            uptadeToCar.CarId = car.CarId;
            uptadeToCar.ModelYear = car.ModelYear;
        }
    }
}
