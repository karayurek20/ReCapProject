using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserMenager : IUserService
    {
        private IUserDal _UserDal;

        public UserMenager(IUserDal userDal)
        {
            _UserDal = userDal;
        }

        public IResult Add(User user)
        {
            
            _UserDal.Add(user);
            return new SuccessResult("user added");
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _UserDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_UserDal.GetClaims(user));
        }
    }
}
