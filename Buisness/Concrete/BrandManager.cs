using Buisness.Abstract;
using Buisness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _ibrandDal;
        public BrandManager(IBrandDal ibrandDal)
        {
            _ibrandDal = ibrandDal;
        }

        public IResult Add(Brand brand)
        {
            _ibrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _ibrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_ibrandDal.GetAll(),Messages.AllBrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_ibrandDal.Get(p => p.Id == id),Messages.BrandListedById);
        }

        public IResult Update(Brand brand)
        {
            _ibrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
