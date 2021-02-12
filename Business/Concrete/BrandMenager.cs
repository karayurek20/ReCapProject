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
    public class BrandMenager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandMenager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.BrandErrorMessage);
            }
             _brandDal.Add(brand);
            return new SuccessResult( Messages.BrandAddedMessage);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.BrandErrorMessage);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeletedMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==13)
            {
                return new ErrorDataResult<List<Brand>>(Messages.DataResultErrorMessage);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.DataResultListMessage);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id),Messages.DataResultListMessage);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandErrorMessage);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdateMessage);
        }
    }
}
