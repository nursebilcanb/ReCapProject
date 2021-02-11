using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();


            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"CarId: {car.CarId}" + " / " + car.BrandName + " / " + car.ColorName + " / " + $"Daily price: {car.DailyPrice}");

                }
            }
            

            //BrandManagerTest();
            //ColorManagerTest();

        }

        private static void ColorManagerTest()
        {
            Console.WriteLine("---------------------------------------------------------------------");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
           
        }

        private static void BrandManagerTest()
        {
            Console.WriteLine("----------------------------------------------------------------------");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();

            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            
        }
    }
}
