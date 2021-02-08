using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new CarDetailDto {
                                 CarId = c.Id, CarName = c.Name,
                                 BrandId = b.Id, BrandName = b.BrandName,
                                 ColorId = col.Id, ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();




            }
        }
    }
}
