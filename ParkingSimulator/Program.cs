using System;
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
                e => Log(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(1));   
            Console.ReadLine(); 
        }

        public static void Log()
        {

        }
    }
}
