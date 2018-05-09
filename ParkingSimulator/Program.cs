using System;
using System.Collections.Generic;
using System.IO;
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

            Menu.GetMenu();
            //var timerCharge = new Timer(
            //    e => ChargeAFee(parking),
            //    null,
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(parking.Settings.Timeout));
        }

        public static void ChargeAFee(Parking parking)
        {
            foreach (var car in parking.Cars)
            {
                double fee;
                if (car.CarBalance > 0)
                {
                    fee = parking.Settings.Prices[car.TypeOfTransport];
                    car.CarBalance -= fee;
                }
                else
                {
                    fee = parking.Settings.Prices[car.TypeOfTransport]* parking.Settings.Fine;
                    car.CarBalance -= fee;
                }

                parking.Balance += fee;
                Parking.Instance.Transactions.Add(new Transaction(car.Id,fee));
            }
        }
    }
}
