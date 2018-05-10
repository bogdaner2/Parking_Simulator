using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace ParkingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = Settings.Instance;
            settings.SetSettings(3,20,
                new Dictionary<Car.CarType,int>()
                {
                    { Car.CarType.Truck,5},
                    { Car.CarType.Passenger,3},
                    { Car.CarType.Bus,2},
                    { Car.CarType.Motorcycle,1}
                },
                0.3 );
            var parking = Parking.Instance;
            parking.AddCar(new Car(600,Car.CarType.Bus));
            parking.AddCar(new Car(600, Car.CarType.Motorcycle));
            parking.AddCar(new Car(600, Car.CarType.Passenger));
            parking.AddCar(new Car(600, Car.CarType.Truck));
            //var timerCharge = new Timer(
            //    e => Console.WriteLine(DateTime.Now),
            //    null,
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(parking.Settings.Timeout));
            while (true)
            {
                try
                {
                    Menu.GetMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please, enter any key for continue");
                    Console.ReadKey();
                }
            }
        }

        public static void ChargeAFee(Parking parking)
        {
            foreach (var car in parking.Cars)
            {
                double fee;
                if (car.CarBalance > 0)
                {
                    fee = parking.Settings.Prices[car.TypeOfTransport];
                    car.Withdraw(fee);
                }
                else
                {
                    fee = parking.Settings.Prices[car.TypeOfTransport]* parking.Settings.Fine;
                    car.Withdraw(fee);
                }
                parking.Balance += fee;            
            }
        }
    }
}
