using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            foreach (var cars in carMenager.GetAll())
            {
                Console.WriteLine(cars.BrandId);
            }
        }
    }
}
