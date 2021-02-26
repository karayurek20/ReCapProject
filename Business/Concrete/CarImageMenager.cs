using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageMenager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageMenager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        
        

        public IResult Add(CarImage carImages)
        {
            var result = BusinessRules.Run(CheckCountPicturesOfCar(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCountPicturesOfCar(int carID)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carID).Count;
            if (result >= 5)
            {
                return new ErrorResult("kontol edildi");
            }
            return new SuccessResult();
        }
    }
}
