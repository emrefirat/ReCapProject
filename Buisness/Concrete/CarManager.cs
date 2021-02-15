using Buisness.Abstract;
using Buisness.Constants;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal icarDal)
        {
            _carDal = icarDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                Console.WriteLine("Arabanın Ismi 2 karakterden kisa veya Günlük fiyatı 0'dan küçük.");
                return new ErrorResult(Messages.CarNameInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            var carExist = _carDal.Get(c => c.Id == car.Id);
            if (carExist != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);

            }
            return new ErrorResult(Messages.CarNotFound);
        }
        public IResult Update(Car car)
        {
            var carExist = _carDal.Get(c => c.Id == car.Id);
            if (carExist != null)
            {
                var carObj = _carDal.Get(x => x.Id == car.Id);

                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarNotFound);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllCarListed);
            
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListedByBrandId);

        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
            //return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
                //return _carDal.Get(p => p.Id == id);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        /*public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }*/
    }
}
