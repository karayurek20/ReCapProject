using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        IRentalDal _rental;
        Rental rental;

        public RentalMenager(Rental rental)
        {
            this.rental = rental;
        }

        public RentalMenager(IRentalDal rental)
        {
            _rental = rental;
        }

        public IResult Add(Rental rental)
        {
            _rental.Add(rental);
            return new SuccessResult(Messages.RentalAddedMessage);
        }

        public IResult Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.RentalDeletedMessage);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(), Messages.DataResultListMessage);

        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rental.Get(c => c.Id == id), Messages.DataResultListMessage);
        }

        public IResult Update(Rental rental)
        {
            _rental.Update(rental);
            return new SuccessResult(Messages.RentalUpdatedMessage);
        }
    }
}
