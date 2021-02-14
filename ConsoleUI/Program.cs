using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Text;

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
            //GetCarDeetails();
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User {FirstName ="Emre",LastName = "FIRAT",Email = "emrefirat93@gmail.com",Password = "1234567890" });
            //userManager.Add(new User { FirstName = "Adrian", LastName = "Robinson",  Email = "Adrian@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Alex", LastName = "Jackson",  Email = "Alex@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Andrew", LastName = "Wright",  Email = "Andrew@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Brandon", LastName = "Johnson",  Email = "Brandon@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Chuck", LastName = "Taylor",  Email = "Chuck@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Eric", LastName = "Adams",  Email = "Eric@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Jacob", LastName = "Smith",  Email = "Jacob@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Juan", LastName = "Rodriguez",  Email = "Juan@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Peter", LastName = "Nelson",  Email = "Peter@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Stuart", LastName = "Thomson", Email = "Stuart@test.com", Password = "Test2020"});
            //userManager.Add(new User { FirstName = "Vincent", LastName = "Lee",  Email = "Vincent@test.com", Password = "Test2020"});

            //AddRental();
            //RentalDetails();

        }

        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal(), new EfCustomerDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rental.CustomerName + "|" + rental.CompanyName + "|" + rental.RentDate + "|" + rental.ReturnDate);
            }
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal(), new EfCustomerDal());
            var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(5) });
            Console.WriteLine(result.Message);
        }

        private static void GetCarDeetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
        }

        private static void AddNewColorandShowList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Grey" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " : " + color.ColorName);

            }
        }

        private static void ColorListeler()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " : " + color.ColorName);
            }
        }

        private static void CarDeletedById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(carManager.GetById(2003).Data);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name + "/" + car.Id + "/" + car.Description);
            }
        }

        private static void CarEklemeveListeleme()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 1500, Description = "02.08.2020 tarihinde gelen araba", ModelYear = "2015", Name = "Eski Araba" });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name + "/" + car.Id + "/" + car.Description);
            }
        }

        private static void EskiCalismalar()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());

            foreach (var a600lukaraba in carManager2.GetByDailyPrice(600, 600).Data)
            {
                Console.WriteLine(a600lukaraba.Name);
                carManager2.Delete(a600lukaraba);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetAll().Data)
            {
                Console.WriteLine("Gunluk Kira Bedeli" + ":  " + car.DailyPrice);
            }
            BrandManager brandMananger = new BrandManager(new EfBrandDal());
            foreach (var brand in brandMananger.GetAll().Data)
            {
                Console.WriteLine(brand.Id + ": " + brand.BrandName);
            }
        }
    }
}
