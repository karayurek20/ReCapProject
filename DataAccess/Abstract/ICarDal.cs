using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityResponsibility<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
