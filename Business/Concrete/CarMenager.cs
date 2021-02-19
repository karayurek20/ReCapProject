using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarMenager : ICarService
    {
        ICarDal _carDal;

        public CarMenager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddedMessage);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeletedMessage);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==13)
            {
                return new ErrorDataResult<List<Car>>(Messages.DataResultErrorMessage);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.DataResultListMessage);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),Messages.DataResultListMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.DataResultErrorMessage);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.DataResultListMessage);
        }

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdatedMessage);
        }
    }
}
