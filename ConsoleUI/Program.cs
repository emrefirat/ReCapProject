using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Car eklenecekaraba = new Car{BrandId = 1, ColorId = 3, DailyPrice = 600, ModelYear = "2021", Name = "Yeni Araba", Description = "Yeni Gelen Araba"};
            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(eklenecekaraba);
            CarManager carManager2 = new CarManager(new EfCarDal());

            foreach (var a600lukaraba in carManager2.GetByDailyPrice(600,600))
            {
                Console.WriteLine(a600lukaraba.Name);
                carManager2.Delete(a600lukaraba);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("Gunluk Kira Bedeli" + ":  " + car.DailyPrice);
            }
            BrandManager brandMananger = new BrandManager(new EfBrandDal());
            foreach (var brand in brandMananger.GetAll())
            {
                Console.WriteLine(brand.Id + ": " + brand.BrandName);
            }

        }
    }
}
