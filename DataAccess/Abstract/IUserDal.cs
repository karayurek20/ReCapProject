using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityResponsibility<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
