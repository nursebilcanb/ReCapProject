using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

          

            //CustomerTest();

            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
        }

        private static void CustomerTest()
        {
            Customer customer = new Customer { UserId = 5, CompanyName = "Halkbank" };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
        }

        private static void CarManagerTest()
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
