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
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RecapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId = c.Id,
                                 CustomerId = c.Id,
                                 CustomerName = u.FirstName,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }
    }


    
}
/*
 * 
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
 
 
 * 
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

*/
