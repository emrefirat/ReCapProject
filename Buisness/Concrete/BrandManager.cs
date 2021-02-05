using Buisness.Abstract;
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
        public List<Brand> GetAll()
        {
            return _ibrandDal.GetAll();
        }

        public List<Brand> GetAllByBrandId(int id)
        {
            return _ibrandDal.GetAll(p => p.Id == id);
        }

    }
}
