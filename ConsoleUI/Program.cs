using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarMenager carMenager = new CarMenager(new EfCarDal());
            foreach (var details in carMenager.GetCarDetails())
            {
                Console.WriteLine(details.CarId+"--"+details.BrandName+"--"+details.ColorName+"--"+details.DailyPrice);
            }
        }

        private static void ColorTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            colorMenager.Add(new Color { ColorName = "Kırmızı" });
            foreach (var colors in colorMenager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
            brandMenager.Add(new Brand { BrandName = "Volvo" });
            foreach (var brands in brandMenager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void CarTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            carMenager.Delete(new Car { BrandId = 2 });
            foreach (var cars in carMenager.GetAll())
            {
                Console.WriteLine(cars.CarId);
            }
        }
    }
}
