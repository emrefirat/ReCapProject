﻿using Buisness.Abstract;
using Buisness.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null) //hata varsa null olmaz
            {
                return result;
            }
            
            var fileUpload = FileHelper.Add(file);
            if (fileUpload.Success)
            {
                carImage.ImagePath = fileUpload.Data;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImagesAdded);
            }
            return new ErrorResult(Messages.CarImageNotAdded);
        }


        //public IResult Add(CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
        //    if (result != null ) //hata varsa null olmaz
        //    {
        //        return result;
        //    }
        //    _carImageDal.Add(carImage);

        //    return new SuccessResult(Messages.CarImagesAdded);
        //}

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.AllCarImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }


        public IResult Update(IFormFile file, CarImage carImage)
        {
            var fileUpload = FileHelper.Update(_carImageDal.Get(cim => cim.Id == carImage.Id).ImagePath, file);
            if (fileUpload.Success)
            {
                CarImage carImagetoUpdate = _carImageDal.Get(cim => cim.Id == carImage.Id);
                if (carImagetoUpdate == null)
                {
                    return new ErrorResult();
                }
                carImagetoUpdate.ImagePath = fileUpload.Data;
                carImagetoUpdate.Date = DateTime.Now;
                _carImageDal.Update(carImagetoUpdate);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            return new ErrorResult();

        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
