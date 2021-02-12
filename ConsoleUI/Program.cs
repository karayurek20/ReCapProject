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
            //CarDetailTest();

            RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
            var result = rentalMenager.GetAll();
            if (result.Success==true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine(rent.CarId+"--"+rent.CustomerId+"--"+rent.RentDate+"--"+rent.ReturnDate);
                }
            }

        }

        private static void CarDetailTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());

            var result = carMenager.GetCarDetails();
            carMenager.Add(new Car { BrandId = 5, ColorId = 3, DailyPrice = 350, Descriptions = "Yeni Araba", ModelYear = "2015" });
            if (result.Success == true)
            {
                foreach (var details in result.Data)
                {
                    Console.WriteLine(details.CarId + "--" + details.BrandName + "--" + details.Descriptions + "--" + details.ColorName + "--" + details.DailyPrice + "$");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void ColorTest()
        //{
        //    ColorMenager colorMenager = new ColorMenager(new EfColorDal());
        //    colorMenager.Add(new Color { ColorName = "Kırmızı" });
        //    foreach (var colors in colorMenager.GetAll())
        //    {
        //        Console.WriteLine(colors.ColorName);
        //    }
        //}

        //private static void BrandTest()
        //{
        //    BrandMenager brandMenager = new BrandMenager(new EfBrandDal());
        //    brandMenager.Add(new Brand { BrandName = "Volvo" });
        //    foreach (var brands in brandMenager.GetAll())
        //    {
        //        Console.WriteLine(brands.BrandName);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarMenager carMenager = new CarMenager(new EfCarDal());
        //    carMenager.Delete(new Car { BrandId = 2 });
        //    foreach (var cars in carMenager.GetAll())
        //    {
        //        Console.WriteLine(cars.CarId);
        //    }
        //}
    }
}
