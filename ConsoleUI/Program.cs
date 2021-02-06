using Business.Abstract;
using Business.Concrete;
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
            ICarService carService = new ICarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 6, BrandId = 2, ColorId = 5, DailyPrice = 130, ModelYear = 2020, Description = "Otomatik Hibrit" };
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

            Console.WriteLine(carService.GetById(2).Id);


        }
    }
}