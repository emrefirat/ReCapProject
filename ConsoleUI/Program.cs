using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(500,500))
            {
                Console.WriteLine(car.Description);
            }
            BrandManager brandMananger = new BrandManager(new EfBrandDal());
            foreach (var brand in brandMananger.GetAll())
            {
                Console.WriteLine(brand.Id + ": " + brand.BrandName);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
