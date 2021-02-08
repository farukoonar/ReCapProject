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
            //InMemoryProductTest();
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void InMemoryProductTest()
        {
            ICarService carService = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 6, BrandId = 2, ColorId = 5, DailyPrice = 130, ModelYear = "2020", Description = "Otomatik Hibrit" };
            carService.Add(car1);

            foreach (var car in carService.GetAll())
            {
                Console.WriteLine("Açıklama: {0} --- Fiyat: {1}", car.Description, car.DailyPrice);
            }

            carService.Delete(car1);

            Console.WriteLine("------------------------------");

            foreach (var car in carService.GetAll())
            {
                Console.WriteLine("Açıklama: {0} --- Fiyat: {1}", car.Description, car.DailyPrice);
            }
        }
    }
}