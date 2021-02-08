using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=90,ModelYear="2018",Description="Otomatik Dizel"},
                new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=160,ModelYear="2019",Description="Otomatik Hibrit"},
                new Car{Id=3,BrandId=1,ColorId=1,DailyPrice=70,ModelYear="2012",Description="Manuel Benzinli"},
                new Car{Id=4,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2016",Description="Otomatik Dizel"},
                new Car{Id=5,BrandId=1,ColorId=1,DailyPrice=120,ModelYear="2019",Description="Otomatik Benzinli"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToUpdate);
        }
    }
}
