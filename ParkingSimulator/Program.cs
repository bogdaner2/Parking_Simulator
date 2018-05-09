using System;
using System.IO;
using System.Threading;

namespace ParkingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = Parking.Instance;
            parking.Balance = 500;
            var timer = new Timer(
                e => Log(""),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(3));  
            Car c = new Car(500, Car.CarType.Passenger);
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
