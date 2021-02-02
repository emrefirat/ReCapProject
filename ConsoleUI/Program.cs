using Buisness.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
            
            Console.WriteLine("---------------------------");
            Car eklenecekaraba = new Car { Id = 10, BrandId = 2, ColorId = 1, DailyPrice = 300, Description = "Yeni Eklenen Araba", ModelYear = 2021 };
            carManager.Add(eklenecekaraba);

            Console.WriteLine("-------------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
