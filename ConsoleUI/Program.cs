using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarTest();
            //EfCarTest();
            //EfColorTest();
            //EfBrandTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now });

            Console.WriteLine(result.Message);
        }

        private static void EfBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { Name = "Tesla" };

            brandManager.Add(brand);
            brandManager.Update(new Brand { Id = 3, Name = "Kia" });
            foreach (var b in brandManager.GetAll().Data)
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine("--------------------");

            brandManager.Delete(brand);
            foreach (var b in brandManager.GetAll().Data)
            {
                Console.WriteLine(b.Name);
            }
        }

        private static void EfColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { Name = "Red" };
            colorManager.Add(color);
            colorManager.Update(new Color { Id = 1, Name = "Blue" });
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("-----------------------------");
            colorManager.Delete(color);
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.Name);
            }
        }

        private static void EfCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { BrandId = 6, DailyPrice = 125, ColorId = 1, ModelYear = "2017", Description = "Astra" };

            var result= carManager.GetCarDetails();

            carManager.Add(car);
            foreach (var c in result.Data)
            {
                Console.WriteLine("Brand: {0} - Color: {1} - Daily Price: {2} - Description: {3}", c.BrandName, c.ColorName, c.DailyPrice, c.CarDescription);
            }
            Console.WriteLine("---------------------------------------------------");

            carManager.Update(new Car { Id = 5, BrandId = 6, DailyPrice = 125, ColorId = 1, ModelYear = "2017", Description = "Astra" });
            foreach (var c in result.Data)
            {
                Console.WriteLine("Brand: {0} - Color: {1} - Daily Price: {2} - Description: {3}", c.BrandName, c.ColorName, c.DailyPrice, c.CarDescription);
            }
            Console.WriteLine("---------------------------------------------------");

            carManager.Delete(car);
            foreach (var c in result.Data)
            {
                Console.WriteLine("Brand: {0} - Color: {1} - Daily Price: {2} - Description: {3}", c.BrandName, c.ColorName, c.DailyPrice, c.CarDescription);
            }
            Console.WriteLine("---------------------------------------------------");


            
            foreach (var c in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine("---------------------------------------------------");
        }

        private static void InMemoryCarTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 6, BrandId = 2, ColorId = 5, DailyPrice = 130, ModelYear = "2020", Description = "Otomatik Hibrit" };
            carManager.Add(car1);

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Açıklama: {0} --- Fiyat: {1}", car.Description, car.DailyPrice);
            }

            carManager.Delete(car1);

            Console.WriteLine("------------------------------");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Açıklama: {0} --- Fiyat: {1}", car.Description, car.DailyPrice);
            }
        }
    }
}