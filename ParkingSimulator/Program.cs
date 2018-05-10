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
            parking.Cars.Add(new Car(600,Car.CarType.Bus));
            parking.Cars.Add(new Car(600, Car.CarType.Motorcycle));
            parking.Cars.Add(new Car(600, Car.CarType.Passenger));
            parking.Cars.Add(new Car(600, Car.CarType.Truck));
            var earnedForOneMinute = 0.0;
            var timerLog = new Timer(
                e => Log(ref earnedForOneMinute),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(1));
            var timerCharge = new Timer(
                e => ChargeAFee(parking,ref earnedForOneMinute),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(parking.Settings.Timeout));
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

        public static void ChargeAFee(Parking parking,ref double earned)
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
                earned += fee;
                parking.AddTransaction(car.Id,fee);
            }
        }

        public static void Log(ref double earnedAmount)
        {
            using (StreamWriter streamWriter = File.AppendText("Transactions.log"))
            {
                streamWriter.WriteLine("Parking earned : {0} ",earnedAmount);
                streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                streamWriter.WriteLine("-------------------------------");
            }
            earnedAmount = 0;
        }
    }
}


