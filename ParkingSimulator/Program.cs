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
                new Dictionary<int, Car.CarType>()
                {
                    { 5,Car.CarType.Truck},
                    { 3,Car.CarType.Passenger},
                    { 2,Car.CarType.Bus},
                    { 1,Car.CarType.Motorcycle},
                },
                0.3 );
            var parking = Parking.Instance;
            parking.AddCar(new Car(600,Car.CarType.Bus));
            parking.AddCar(new Car(600, Car.CarType.Bus));
            parking.AddCar(new Car(600, Car.CarType.Bus));
            parking.AddCar(new Car(600, Car.CarType.Bus));
            parking.AddCar(new Car(600, Car.CarType.Bus));

            parking.GetAmount();
            //var timer = new Timer(
            //    e => Log(""),
            //    null,
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(parking.Settings.Timeout));  
            Console.ReadLine(); 
        }

        public static void Log(string message)
        {
            using (StreamWriter streamWriter = File.AppendText("Transactions.log"))
            {
                streamWriter.Write("\r\nLog Entry : ");
                streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                streamWriter.WriteLine("  :{0}", message);
                streamWriter.WriteLine("-------------------------------");
            }
        }

    }
}
