using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarMenager carMenager = new CarMenager(new InMemoryCarDal());
            foreach (var cars in carMenager.GetAll())
            {
                Console.WriteLine(cars.BrandId+"--"+cars.ModelYear+"--"+cars.Description);
            }
        }
    }
}
