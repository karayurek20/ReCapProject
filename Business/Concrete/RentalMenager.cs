using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        private IRentalDal _RentalDal;

        public RentalMenager(IRentalDal rentalDal)
        {
            _RentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            var lastEntry = _RentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (lastEntry == null)
            {
                _RentalDal.Add(rental);
                return new SuccessResult("Rent Added");


            }
            return new ErrorResult("Rent failled");
        }

        public IResult Delete(Rental rental)
        {
            _RentalDal.Delete(rental);
            return new SuccessResult("rent deleted");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_RentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_RentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_RentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _RentalDal.Update(rental);
            return new SuccessResult("rent updated");
        }
    }
}
