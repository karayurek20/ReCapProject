using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from r in context.Rentals
                             join b in context.Brands
                             on r.CarId equals b.Id
                             join user in context.Users
                             on r.CustomerId equals user.Id
                             select new RentalDetailDto { RentalId = r.Id, BrandName = b.BrandName, RentDate = r.RentDate, ReturnDate = r.ReturnDate, FirstName = user.FirstName, LastName = user.LastName };
                return result.ToList();
            }
        }
    }
}
