using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icarDal;
        public CarManager(ICarDal icarDal)
        {
            _icarDal = icarDal;
        }
        public List<Car> GetAll()
        {
            return _icarDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _icarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _icarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }
    }
}
