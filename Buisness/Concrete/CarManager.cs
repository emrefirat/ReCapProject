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
        ICarDal _iCarDal;
        public CarManager(ICarDal  iCarDal)
        {
            _iCarDal = iCarDal;
        }
        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public void Add(Car car)
        {
            _iCarDal.Add(car);
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }
    }
}
