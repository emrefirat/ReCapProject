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
            //EskiCalismalar();
            //CarEklemeveListeleme();
            //CarDeletedById();
            //-----
            //ColorListeler();
            //AddNewColorandShowList();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                if (car.CarName == null) {
                    Console.WriteLine("<Car Name is Null>" + " | " + car.BrandName + " | " + car.ColorName + " | " + car.DailyPrice + " TL ");
                }
                else { 
                Console.WriteLine(car.CarName + " | " + car.BrandName +" | " + car.ColorName +" | " + car.DailyPrice + " TL ");
                    };
            }
        }

        private static void AddNewColorandShowList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Grey" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " : " + color.ColorName);

            }
        }

        private static void ColorListeler()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " : " + color.ColorName);
            }
        }

        private static void CarDeletedById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(carManager.GetById(2003));
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name + "/" + car.Id + "/" + car.Description);
            }
        }

        private static void CarEklemeveListeleme()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 1500, Description = "02.08.2020 tarihinde gelen araba", ModelYear = "2015", Name = "Eski Araba" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name + "/" + car.Id + "/" + car.Description);
            }
        }

        private static void EskiCalismalar()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());

            foreach (var a600lukaraba in carManager2.GetByDailyPrice(600, 600))
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
