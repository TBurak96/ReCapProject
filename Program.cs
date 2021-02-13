﻿using System;
using System.Collections.Generic;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //CarAddition();              
            //CarUpdate();           
            //CarDeregistration();
            // DisplayingCarDetails();
            //DisplayingCarsByPrice();   
            //DisplayingCarsByBrand();
            //DisplayingCarsByColor();
            //NonFilterListing();



            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Update(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 2, 15),
                ReturnDate = new DateTime(2021, 3, 12)
            });
            System.Console.WriteLine(result.Message);













            Console.ReadKey();
        }

        private static void NonFilterListing()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultOne = carManager.GetAll();
            if (resultOne.Success == true)
            {
                foreach (var car in resultOne.Data)
                {
                    Console.WriteLine("Car name: {0} / Daily price: {1}", car.Name, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(resultOne.Message);
            }
        }

        private static void DisplayingCarsByColor()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultFour = carManager.GetCarsByColorId(5);
            if (resultFour.Success == true)
            {
                foreach (var car in resultFour.Data)
                {
                    Console.WriteLine("Car by color: {0}", car.Name);
                }
            }
            else
            {
                Console.WriteLine(resultFour.Message);
            }
        }

        private static void DisplayingCarsByBrand()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultTwo = carManager.GetCarsByBrandId(1);
            if (resultTwo.Success == true)
            {
                foreach (var car in resultTwo.Data)
                {
                    Console.WriteLine("Car and its model year by brand: {0} - {1}", car.Name, car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(resultTwo.Message);
            }
        }

        private static void DisplayingCarsByPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultFive = carManager.GetByDailyPrice(100, 600);
            if (resultFive.Success == true)
            {
                foreach (var car in resultFive.Data)
                {
                    Console.WriteLine("Car in the specified price range: {0}", car.Name);
                }
            }
            else
            {
                Console.WriteLine(resultFive.Message);
            }
        }

        private static void DisplayingCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultSix = carManager.GetCarDetails(2);
            if (resultSix.Success == true)
            {
                foreach (var car in resultSix.Data)
                {
                    Console.WriteLine("Car name: {0}\nDaily price: {1}\nModel year: {2}", car.Name, car.DailyPrice,
                        car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(resultSix.Message);
            }
        }

        private static void CarDeregistration()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var resultSeven = carManager.Delete(carManager.GetById(1).Data);
            Console.WriteLine(Messages.Deleted);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car carToUpdate = carManager.GetById(1002).Data;
            carToUpdate.Name = "El Arabası";
            var resultThree = carManager.Update(carToUpdate);
            Console.WriteLine(Messages.Updated);
        }

        private static void CarAddition()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car carToAdd = new Car()
            {
                BrandId = 1,
                Name = "TOGG",
                ColorId = 2,
                ModelYear = 2022,
                DailyPrice = 710,
                Description = "Best in class."
            };
            carManager.Add(carToAdd);
            Console.WriteLine(Messages.Added);
        }
    }
}
