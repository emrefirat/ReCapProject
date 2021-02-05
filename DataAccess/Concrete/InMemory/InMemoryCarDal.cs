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
                new Car {Id=1,BrandId =1,ColorId=0001,DailyPrice = 150,  ModelYear = "2019", Description = "Kiralik Arabalar"},
                new Car {Id=2,BrandId =2,ColorId=0002,DailyPrice = 250,  ModelYear = "2020", Description = "Kiralik Arabalar"},
                new Car {Id=3,BrandId =2,ColorId=0002,DailyPrice = 450,  ModelYear = "2021", Description = "Kiralik Arabalar"},
                new Car {Id=4,BrandId =4,ColorId=0004,DailyPrice = 550,  ModelYear = "2018", Description = "Kiralik Arabalar"},
                new Car {Id=5,BrandId =3,ColorId=0003,DailyPrice = 1000, ModelYear ="2021", Description = "Kiralik Arabalar"}
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

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
